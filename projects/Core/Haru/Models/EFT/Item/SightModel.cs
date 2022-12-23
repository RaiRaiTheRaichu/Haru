using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct SightModel
    {
        [JsonProperty("ScopesCurrentCalibPointIndexes")]
        public int[] ScopesCurrentCalibPointIndexes;

        [JsonProperty("ScopesSelectedModes")]
        public int[] ScopesSelectedModes;

        [JsonProperty("SelectedScope")]
        public int SelectedScope;
    }
}
