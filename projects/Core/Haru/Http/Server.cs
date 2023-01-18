using System;
using System.Security.Cryptography.X509Certificates;
using WebSocketSharp.Server;
using Haru.Utils;

namespace Haru.Http
{
    public class Server
    {
        private readonly Log _log;
        private readonly VFS _vfs;
        private readonly HttpServer _httpsv;
        public readonly Router Router;
        public readonly string Address;

        public Server(string address)
        {
            _log = new Log();
            _vfs = new VFS();

            var uri = new Uri(address);
            _httpsv = new HttpServer(uri.Port, true);
            
            Router = new Router();
            Address = address;
        }

        public void OnRequest(object sender, HttpRequestEventArgs e)
        {
            Router.Run(e.Request, e.Response);
        }

        public void Start()
        {
            // load certificate
            var filepath = "./Haru/certs/cert.pfx";
            _httpsv.SslConfiguration.ServerCertificate = new X509Certificate2(filepath);

            // set request handlers
            _httpsv.OnGet += OnRequest;
            _httpsv.OnPost += OnRequest;

            // start the server
            _httpsv.Start();
            _log.Write($"Starting server on {Address}");
        }
    }
}