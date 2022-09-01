using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;

namespace Haru.Server.Services
{
    public class NotifierService
    {
        public NotifierServerModel GetNotifier(string sessionId)
        {
            var url = _HttpServerConfig.GetUrl();
            return new NotifierServerModel(sessionId, url);
        }
    }
}