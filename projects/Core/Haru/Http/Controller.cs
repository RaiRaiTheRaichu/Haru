using System.Text;
using Haru.Helpers;
using Haru.Models;
using Haru.Utils;

namespace Haru.Http
{
    public abstract class Controller
    {
        protected readonly RequestHelper _requestHelper;
        protected readonly Json _json;
        private readonly Zlib _zlib;

        public Controller()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _zlib = new Zlib();
        }

        public abstract bool IsMatch(RouterContext context);

        public abstract void Run(RouterContext context);

        public void Send(RouterContext context, byte[] data, string mime = null)
        {
            var response = context.Response;
            var bytes = _zlib.Compress(data, ZlibCompression.Maximum);
            response.ContentType = mime ?? Mime.DEFAULT;
            response.ContentLength64 = bytes.LongLength;
            response.OutputStream.Write(bytes, 0, bytes.Length);
            response.Close();
        }

        public void SendJson(RouterContext context, string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            Send(context, data, Mime.JSON);
        }
    }
}