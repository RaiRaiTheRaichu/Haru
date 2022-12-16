using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct BotModifierModel
    {
        [JsonProperty("AccuracySpeed")]
        public int AccuracySpeed;

        [JsonProperty("Scattering")]
        public int Scattering;

        [JsonProperty("GainSight")]
        public int GainSight;

        [JsonProperty("MarksmanAccuratyCoef")]
        public int MarksmanAccuratyCoef;

        [JsonProperty("VisibleDistance")]
        public int VisibleDistance;
    }
}