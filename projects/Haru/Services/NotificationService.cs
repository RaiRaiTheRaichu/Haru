using Haru.Models.EFT.Notification;
using Haru.Http;
using Haru.Servers;

namespace Haru.Services
{
    public static class NotificationService
    {
        public static NotifierModel GetNotifier(string sessionId)
        {
            var httpUrl = HttpConfig.GetUrl();
            var wsUrl = ServerManager.NotificationServer.Server.Address;
            return new NotifierModel(sessionId, httpUrl, wsUrl);
        }

        public static ProfileSelectModel SelectProfile(string sessionId)
        {
            var url = HttpConfig.GetUrl();

            // note: dumped EFT server data
            return new ProfileSelectModel()
            {
                Status = "ok",
                NotificationServer = GetNotifier(sessionId)
            };
        }

        public static PingModel GetPing()
        {
            return new PingModel();
        }
    }
}