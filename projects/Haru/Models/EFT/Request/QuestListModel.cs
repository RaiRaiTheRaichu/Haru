using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct QuestListModel
    {
        [JsonProperty("completed")]
        public bool Completed;
    }
}