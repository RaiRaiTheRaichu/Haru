using Haru.Models.EFT;
using Haru.Http;

namespace Haru.Services
{
    public class ServerService
    {
        public ServerInfoModel[] GetServers()
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