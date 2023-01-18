using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using WebSocketSharp.Server;
using Haru.Helpers;
using Haru.Models;
using Haru.Utils;

namespace Haru.Http
{
    public class Server
    {
        private readonly Log _log;
        private readonly VFS _vfs;
        private readonly HttpServer _httpsv;
        private readonly RequestHelper _requestHelper;
        public Dictionary<string, Controller> Controllers;
        public readonly string Address;

        public Server(string address)
        {
            // utilities
            _log = new Log();
            _vfs = new VFS();

            // server
            var uri = new Uri(address);
            _httpsv = new HttpServer(uri.Port, true);
            Address = address;
            
            // controllers
            _requestHelper = new RequestHelper();
            Controllers = new Dictionary<string, Controller>();
        }

        public void OnRequest(object sender, HttpRequestEventArgs e)
        {
            // log path
            var path = _requestHelper.GetPath(e.Request);

            // run controller
            if (Controllers.TryGetValue(path, out var controller))
            {
                var context = new RouterContext()
                {
                    Request = e.Request,
                    Response = e.Response
                };

                _log.Write(path);
                controller.Run(context);
            }
            else
            {
                _log.Write($"No controller found for {path}");
                e.Response.Close();
            }
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