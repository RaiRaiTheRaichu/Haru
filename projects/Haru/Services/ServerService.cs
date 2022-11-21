using Haru.Models.EFT;
using Haru.Http;

namespace Haru.Services
{
    public static class ServerService
    {
        public static ServerInfoModel[] GetServers()
        {
            return new ServerInfoModel[]
            {
                new ServerInfoModel()
                {
                    Ip = HttpConfig.GetHost(),
                    Port = HttpConfig.GetPort()
                }
            };
        }
    }
}