using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;

namespace Haru.Server.Services
{
    public static class NotifierService
    {
        public static NotifierServerModel GetNotifier(string sessionId)
        {
            var url = HttpConfig.GetUrl();
            return new NotifierServerModel(sessionId, url);
        }
    }
}