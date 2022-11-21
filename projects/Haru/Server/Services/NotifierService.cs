using Haru.Models.EFT;
using Haru.Server.Http;
using Haru.Server.Servers;

namespace Haru.Server.Services
{
    public static class NotifierService
    {
        public static NotifierServerModel GetNotifier(string sessionId)
        {
            var httpUrl = HttpConfig.GetUrl();
            var wsUrl = ServerManager.NotificationServer.Server.Address;
            return new NotifierServerModel(sessionId, httpUrl, wsUrl);
        }
    }
}