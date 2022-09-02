using Haru.Models.EFT;
using Haru.Server.Http;

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