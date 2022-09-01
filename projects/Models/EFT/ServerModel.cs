using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct ServerModel
    {
        [JsonProperty("ip")]
        public string Ip;

        [JsonProperty("port")]
        public int Port;
    }
}