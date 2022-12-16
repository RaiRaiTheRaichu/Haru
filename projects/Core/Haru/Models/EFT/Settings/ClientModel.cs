using Newtonsoft.Json;

namespace Haru.Models.EFT.Settings
{
    public struct ClientModel
    {
        [JsonProperty("config")]
        public ClientConfigModel Config;
    }
}