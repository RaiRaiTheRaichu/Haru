using Haru.Models.EFT.Notification;
using Haru.Servers;

namespace Haru.Services
{
    public class NotificationService
    {
        public NotifierModel GetNotifier(string sessionId)
        {
            var host = GeneralServer.Instance.Server.Address
                .Replace("https://", string.Empty)
                .Replace("/", string.Empty);

            return new NotifierModel(sessionId, host);
        }

        public ProfileSelectModel SelectProfile(string sessionId)
        {
            // note: dumped EFT server data
            return new ProfileSelectModel()
            {
                Status = "ok",
                NotificationServer = GetNotifier(sessionId),
                Unused = string.Empty
            };
        }

        public PingModel GetPing()
        {
            return new PingModel();
        }
    }
}