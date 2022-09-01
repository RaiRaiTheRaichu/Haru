using System.Net;
using System.Threading.Tasks;
using Haru.Server.Utils;

namespace Haru.Server.Http
{
    public class HttpServer : IHttpServer
    {
        private readonly ILog _log;
        private readonly HttpListener _listener;
        private readonly HttpServerConfig _httpServerConfig;
        public readonly Router Router;
        public bool IsRunning { get; private set; }

        public HttpServer(ILog log, Router router, HttpServerConfig httpServerConfig)
        {
            _log = log;
            _httpServerConfig = httpServerConfig;
            _listener = new HttpListener();
            Router = router;
            _listener.Prefixes.Add(_httpServerConfig.Uri.ToString());
        }

        private async Task HandleRequest()
        {
            _listener.Start();

            while (IsRunning)
            {
                var context = await _listener.GetContextAsync();
                await Router.Run(context.Request, context.Response);
            }

            _listener.Stop();
        }

        public async void Start()
        {
            IsRunning = true;
            await _log.Write($"Starting server on {_httpServerConfig.GetUrl()}");
            await Task.Run(() => HandleRequest());
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}