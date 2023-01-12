using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct BotModifierModel
    {
        [JsonProperty("AccuracySpeed")]
        public float AccuracySpeed;

        [JsonProperty("Scattering")]
        public float Scattering;

        [JsonProperty("GainSight")]
        public float GainSight;

        [JsonProperty("MarksmanAccuratyCoef")]
        public int MarksmanAccuratyCoef;

        [JsonProperty("VisibleDistance")]
        public float VisibleDistance;
    }
}