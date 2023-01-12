using Haru.Framework.Utils;
using WebSocketSharp.Server;

namespace Haru.Framework.Http
{
    public class Server
    {
        private readonly Log _log;
        private readonly HttpServer _httpsv;
        public readonly Router Router;
        public string Address { get; private set; }

        public Server(string address)
        {
            _log = new Log();
            _httpsv = new HttpServer(address);
            Router = new Router();
            Address = address;
        }

        public async void OnRequest(object sender, HttpRequestEventArgs e)
        {
            await Router.Run(e.Request, e.Response);
        }

        public async void Start()
        {
            await _log.Write($"Starting server on {Address}");
            _httpsv.OnGet += OnRequest;
            _httpsv.OnPost += OnRequest;
        }
    }
}