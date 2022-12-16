using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Haru.Models.EFT;
using Haru.Utils;

namespace Haru.Helpers
{
    public class RequestHelper
    {
        private readonly Zlib _zlib;

        public RequestHelper()
        {
            _zlib = new Zlib();
        }

        public string GetPath(HttpListenerRequest request)
        {
            var url = request.Url;
            var path = url.PathAndQuery;

            if (path.Contains("?"))
            {
                path = path.Split('?')[0];
            }

            return path;
        }

        public string GetSessionId(HttpListenerRequest request)
        {
            return request.Headers["SessionId"];
        }

        public async Task<string> GetBody(HttpListenerRequest request)
        {
            if (!request.HasEntityBody)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                await request.InputStream.CopyToAsync(ms);
                var zlibbed = ms.ToArray();
                var bytes = await _zlib.Decompress(zlibbed);
                return Encoding.UTF8.GetString(bytes);
            }
        }

        public ResponseModel<object> GetEmptyResponse()
        {
            return new ResponseModel<object>(null);
        }

        public ResponseModel<object[]> GetEmptyArrayResponse()
        {
            return new ResponseModel<object[]>(new object[0]);
        }
    }
}