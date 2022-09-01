using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;

namespace Haru.Server.Services
{
    public static class ServerService
    {
        public ServerModel[] GetServers()
        {
            return new ServerModel[]
            {
                new ServerModel()
                {
                    Ip = HttpServerConfig.GetHost(),
                    Port = HttpServerConfig.GetPort()
                }
            };
        }
    }
}