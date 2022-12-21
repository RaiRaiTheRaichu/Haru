using Haru.Models.EFT.Notification;
using Haru.Http;
using Haru.Servers;

namespace Haru.Services
{
    public class NotificationService
    {
        public NotifierModel GetNotifier(string sessionId)
        {
            var httpUrl = HttpConfig.GetUrl();
            var wsUrl = NotificationServer.Instance.Server.Address;
            return new NotifierModel(sessionId, httpUrl, wsUrl);
        }

        public ProfileSelectModel SelectProfile(string sessionId)
        {
            var url = HttpConfig.GetUrl();

            // note: dumped EFT server data
            return new ProfileSelectModel()
            {
                Status = "ok",
                NotificationServer = GetNotifier(sessionId)
            };
        }

        public PingModel GetPing()
        {
            return new PingModel();
        }
    }
}