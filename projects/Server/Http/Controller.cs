using System.Net;
using System.Text;
using System.Threading.Tasks;
using Haru.Models;
using Haru.Server.Utils;

namespace Haru.Server.Http
{
    public abstract class Controller
    {
        public abstract bool IsMatch(RouterContext context);

        public abstract Task Run(RouterContext context);

        public async Task Send(HttpListenerResponse response,
            byte[] data,
            string mime = null)
        {
            var bytes = Zlib.Compress(data, ZlibCompression.Maximum);
            response.ContentType = mime ?? Mime.DEFAULT;
            response.ContentLength64 = bytes.LongLength;

            await response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
            response.Close();
        }

        public async Task SendJson(HttpListenerResponse response, string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            await Send(response, data, Mime.JSON);
        }
    }
}