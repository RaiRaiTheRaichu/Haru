using System;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Haru.Utils
{
    public class Cert
    {
        private Log _log;
        private VFS _vfs;
        private const string _path = "./Haru/certs/cert.pfx";

        public Cert()
        {
            _log = new Log();
            _vfs = new VFS();
        }

        public void Load(string subject, string password)
        {
            var isValid = true;
            X509Certificate2 cert = null;

            if (_vfs.Exists(_path))
            {
                var bytes = _vfs.ReadBytes(_path);

                try
                {
                    cert = new X509Certificate2(bytes, password);
                }
                catch (CryptographicException ex)
                {
                    _log.Write(ex.ToString());
                }

                if (cert.NotAfter < DateTime.Now.AddDays(1))
                {
                    // certificate expired
                    _log.Write("Certificate expired, marked to regenerate");
                    isValid = false;
                }
            }
            else
            {
                // certificate doesn't exist
                isValid = false;
            }

            if (!isValid)
            {
                _log.Write("Generating new certificate...");
                var start = DateTime.UtcNow.AddDays(-1);
                var end = DateTime.UtcNow.AddMonths(1);

                // generate certificate
                cert = GenerateSelfSigned(subject, start, end);

                // export to file
                var bytes = cert.Export(X509ContentType.Pfx);
                _vfs.WriteBytes(_path, bytes);
            }

            _log.Write($"Certificate thumbprint: {cert.Thumbprint}");
        }

        // NET::ERR_CERT_AUTHORITY_INVALID
        private X509Certificate2 GenerateSelfSigned(string name, DateTime start, DateTime end)
        {
            using (RSA rsa = RSA.Create(2048))
            {
                // allow multiple lookups
                var builder = new SubjectAlternativeNameBuilder();
                builder.AddIpAddress(IPAddress.Loopback);
                builder.AddDnsName("localhost");

                // create request for SSL server
                var distinguishedName = new X500DistinguishedName($"CN={name}");
                var req = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1)
                {
                    CertificateExtensions = {
                        new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.DigitalSignature, false),
                        new X509EnhancedKeyUsageExtension(new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }, false),
                        builder.Build()
                    }
                };
                req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));

                // create certificate with both public and private key
                var cert = req.CreateSelfSigned(start, end);
                cert.FriendlyName = name;

                // export certificate
                var password = string.Empty;
                var bytes = cert.Export(X509ContentType.Pfx, password);
                return new X509Certificate2(bytes, password, X509KeyStorageFlags.Exportable);
            }
        }
    }
}