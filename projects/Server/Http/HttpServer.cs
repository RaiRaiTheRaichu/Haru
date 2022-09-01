using System.Net;
using System.Threading.Tasks;
using Haru.Server.Utils;

namespace Haru.Server.Http
{
    public class HttpServer
    {
        private readonly HttpListener _listener;
        public readonly Router Router;
        public bool IsRunning { get; private set; }

        public HttpServer(Router router)
        {
            Router = router;
            _listener = new HttpListener();
            _listener.Prefixes.Add(HttpConfig.Uri.ToString());
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
            Log.Write($"Starting server on {HttpConfig.GetUrl()}");
            await Task.Run(() => HandleRequest());
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}