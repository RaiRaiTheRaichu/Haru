using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct CrcModel
    {
        [JsonProperty("crc")]
        public int Crc;
    }
}