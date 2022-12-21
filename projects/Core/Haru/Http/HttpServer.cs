using System.Net;
using System.Threading.Tasks;
using Haru.Utils;

namespace Haru.Http
{
    public class HttpServer
    {
        private readonly Log _log;
        private readonly HttpListener _listener;
        public readonly Router Router;
        public string Address { get; private set; }
        public bool IsRunning { get; private set; }

        public HttpServer(string address)
        {
            _log = new Log();
            _listener = new HttpListener();
            _listener.Prefixes.Add(address);
            Router = new Router();
            Address = address;
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
            await _log.Write($"Starting server on {Address}");
            await Task.Run(() => HandleRequest());
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}