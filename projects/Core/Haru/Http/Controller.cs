using System.Text;
using System.Threading.Tasks;
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

        public abstract Task Run(RouterContext context);

        public async Task Send(RouterContext context, byte[] data, string mime = null)
        {
            var response = context.Response;
            var bytes = await _zlib.Compress(data, ZlibCompression.Maximum);
            response.ContentType = mime ?? Mime.DEFAULT;
            response.ContentLength64 = bytes.LongLength;

            await response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
            response.Close();
        }

        public async Task SendJson(RouterContext context, string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            await Send(context, data, Mime.JSON);
        }
    }
}