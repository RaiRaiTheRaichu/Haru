using Haru.Models.EFT;
using Haru.Server.Http;

namespace Haru.Server.Services
{
    public static class ServerService
    {
        public static ServerModel[] GetServers()
        {
            return new ServerModel[]
            {
                new ServerModel()
                {
                    Ip = HttpConfig.GetHost(),
                    Port = HttpConfig.GetPort()
                }
            };
        }
    }
}