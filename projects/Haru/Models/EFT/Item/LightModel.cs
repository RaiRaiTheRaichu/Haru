using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct LightModel
    {
        [JsonProperty("IsActive")]
        public bool IsActive;

        [JsonProperty("SelectedMode")]
        public int SelectedMode;
    }
}
