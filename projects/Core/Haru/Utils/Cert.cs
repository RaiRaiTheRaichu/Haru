using System;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Haru.Utils
{
    public class Cert
    {
        private readonly Log _log;
        private readonly VFS _vfs;
        private readonly DateTime _date;
        private readonly string _path;

        public Cert(string path)
        {
            _log = new Log();
            _vfs = new VFS();
            _date = DateTime.UtcNow;
            _path = path;
        }

        public bool IsValid(string password)
        {
            if (!_vfs.Exists(_path))
            {
                return false;
            }

            using (var cert = new X509Certificate2(_path, password))
            {
                if (cert.NotAfter < _date.AddDays(1))
                {
                    return false;
                }
            }

            return true;
        }

        public void CreateCertificate(string subject)
        {
            _log.Write("Generating new certificate...");

            var start = _date.AddDays(-1);
            var end = _date.AddMonths(1);

            using (var cert = GenerateSelfSigned(subject, start, end))
            {
                var bytes = cert.Export(X509ContentType.Pfx);
                _vfs.WriteBytes(_path, bytes);
                _log.Write($"Certificate thumbprint: {cert.Thumbprint}");
            }
        }

        // NET::ERR_CERT_AUTHORITY_INVALID
        private X509Certificate2 GenerateSelfSigned(string subject, DateTime start, DateTime end)
        {
            using (RSA rsa = RSA.Create(2048))
            {
                // allow multiple lookups
                var builder = new SubjectAlternativeNameBuilder();
                builder.AddIpAddress(IPAddress.Loopback);
                builder.AddDnsName("localhost");

                // create request for SSL server
                var distinguishedName = new X500DistinguishedName($"CN={subject}");
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
                cert.FriendlyName = subject;

                // export certificate
                var password = string.Empty;
                var bytes = cert.Export(X509ContentType.Pfx, password);
                return new X509Certificate2(bytes, password, X509KeyStorageFlags.Exportable);
            }
        }
    }
}