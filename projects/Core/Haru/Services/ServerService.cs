using System;
using Haru.Models.EFT;
using Haru.Servers;

namespace Haru.Services
{
    public class ServerService
    {
        public ServerInfoModel[] GetServers()
        {
            var uri = new Uri(GeneralServer.Instance.Server.Address);

            return new ServerInfoModel[]
            {
                new ServerInfoModel()
                {
                    Ip = uri.Host,
                    Port = uri.Port
                }
            };
        }
    }
}