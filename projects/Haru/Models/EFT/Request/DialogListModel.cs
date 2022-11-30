using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct DialogListModel
    {
        [JsonProperty("limit")]
        public int Limit;

        [JsonProperty("offset")]
        public int Offset;
    }
}