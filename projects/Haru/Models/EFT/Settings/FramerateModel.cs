using Newtonsoft.Json;

namespace Haru.Models.EFT.Settings
{
    public struct FramerateModel
    {
        [JsonProperty("MinFramerateLimit")]
        public int MinFramerateLimit;

        [JsonProperty("MaxFramerateLobbyLimit")]
        public int MaxFramerateLobbyLimit;

        [JsonProperty("MaxFramerateGameLimit")]
        public int MaxFramerateGameLimit;
    }
}