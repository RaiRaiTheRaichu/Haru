using Haru.Helpers;
using Haru.Models.EFT;
using Haru.Servers;

namespace Haru.Services
{
    public class ServerService
    {
        public ServerInfoModel[] GetServers()
        {
            var url = GeneralServer.Instance.Server.Address;

            return new ServerInfoModel[]
            {
                new ServerInfoModel()
                {
                    Ip = HttpHelper.GetHost(url),
                    Port = HttpHelper.GetPort(url)
                }
            };
        }
    }
}