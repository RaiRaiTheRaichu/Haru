using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Locale
{
    public struct GlobalModel
    {
        [JsonProperty("interface")]
        public Dictionary<string, string> Interface;

        [JsonProperty("enum")]
        public object[] Enum;

        [JsonProperty("error")]
        public Dictionary<string, string> Error;

        [JsonProperty("mail")]
        public Dictionary<string, string> Mail;

        [JsonProperty("quest")]
        public Dictionary<string, QuestModel> Quest;

        [JsonProperty("preset")]
        public Dictionary<string, NameModel> Preset;

        [JsonProperty("handbook")]
        public Dictionary<string, string> Handbook;

        [JsonProperty("season")]
        public Dictionary<string, string> Season;

        [JsonProperty("customization")]
        public Dictionary<string, NameModel> Customization;

        [JsonProperty("repeatableQuest")]
        public Dictionary<string, string> RepeatableQuest;

        [JsonProperty("templates")]
        public Dictionary<string, NameModel> Templates;

        [JsonProperty("locations")]
        public Dictionary<string, NameModel> Locations;

        [JsonProperty("banners")]
        public Dictionary<string, NameModel> Banners;

        [JsonProperty("trading")]
        public Dictionary<string, TraderModel> Trading;
    }
}