using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Locale
{
    public struct QuestModel
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("Description")]
        public string Description;

        [JsonProperty("note")]
        public string Note;

        [JsonProperty("failMessageText")]
        public string FailMessageId;

        [JsonProperty("startedMessageText")]
        public string StartedMessageId;

        [JsonProperty("successMessageText")]
        public string SuccessMessageId;

        [JsonProperty("conditions")]
        public Dictionary<string, string> Conditions;

        [JsonProperty("location")]
        public string LocationId;
    }
}