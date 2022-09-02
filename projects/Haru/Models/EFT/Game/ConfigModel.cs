using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Game
{
    public struct ConfigModel
    {
        [JsonProperty("aid")]
        public int AccountId;

        [JsonProperty("lang")]
        public string Language;

        [JsonProperty("languages")]
        public Dictionary<string, string> Languages;

        [JsonProperty("ndaFree")]
        public bool IsNdaFree;

        [JsonProperty("taxamony")]
        public int Taxamony;

        [JsonProperty("activeProfileId")]
        public string ProfileId;

        [JsonProperty("backend")]
        public Dictionary<string, string> Backends;

        [JsonProperty("utc_time")]
        public long LoginTime;

        [JsonProperty("totalInGame")]
        public int TotalPlayersOnline;

        [JsonProperty("reportAvailable")]
        public bool CanReportPlayers;

        [JsonProperty("twitchEventMember")]
        public bool IsTwitchEventMember;
    }
}