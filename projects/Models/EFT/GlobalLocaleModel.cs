using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct GlobalLocaleModel
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
        public Dictionary<string, QuestLocaleModel> Quest;

        [JsonProperty("preset")]
        public Dictionary<string, NameLocaleModel> Preset;

        [JsonProperty("handbook")]
        public Dictionary<string, string> Handbook;

        [JsonProperty("season")]
        public Dictionary<string, string> Season;

        [JsonProperty("customization")]
        public Dictionary<string, NameLocaleModel> Customization;

        [JsonProperty("repeatableQuest")]
        public Dictionary<string, string> RepeatableQuest;

        [JsonProperty("templates")]
        public Dictionary<string, NameLocaleModel> Templates;

        [JsonProperty("locations")]
        public Dictionary<string, NameLocaleModel> Locations;

        [JsonProperty("banners")]
        public Dictionary<string, NameLocaleModel> Banners;

        [JsonProperty("trading")]
        public Dictionary<string, TraderLocaleModel> Trading;
    }
}