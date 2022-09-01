using Haru.Models.EFT.Bundle;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct LocationModel
    {
        [JsonProperty("Enabled")]
        public bool Enabled;

        [JsonProperty("Locked")]
        public bool Locked;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("Scene")]
        public ResourceModel Scene;

        [JsonProperty("Area")]
        public int Area;

        [JsonProperty("RequiredPlayerLevel")]
        public int RequiredPlayerLevel;

        [JsonProperty("MinPlayers")]
        public int MinPlayers;

        [JsonProperty("MaxPlayers")]
        public int MaxPlayers;

        [JsonProperty("IconX")]
        public int IconX;

        [JsonProperty("IconY")]
        public int IconY;

        [JsonProperty("waves")]
        public WaveModel[] Waves;

        // todo
        [JsonProperty("limits")]
        public object[] Limits;

        [JsonProperty("AveragePlayTime")]
        public int AveragePlayTime;

        [JsonProperty("AveragePlayerLevel")]
        public int AveragePlayerLevel;

        [JsonProperty("escape_time_limit")]
        public int EscapeTimeLimit;

        [JsonProperty("Rules")]
        public string Rules;

        [JsonProperty("IsSecret")]
        public bool IsSecret;

        // todo
        [JsonProperty("doors")]
        public object[] Doors;

        [JsonProperty("MaxDistToFreePoint")]
        public int MaxDistToFreePoint;

        [JsonProperty("MinDistToFreePoint")]
        public int MinDistToFreePoint;

        [JsonProperty("MaxBotPerZone")]
        public int MaxBotPerZone;

        [JsonProperty("OpenZones")]
        public string openZones;

        [JsonProperty("OcculsionCullingEnabled")]
        public bool OcculsionCullingEnabled;

        [JsonProperty("OldSpawn")]
        public bool OldSpawn;

        [JsonProperty("NewSpawn")]
        public bool NewSpawn;

        [JsonProperty("BotMax")]
        public int BotMax;

        [JsonProperty("BotStart")]
        public int BotStart;

        [JsonProperty("BotStop")]
        public int BotStop;

        [JsonProperty("BotSpawnTimeOnMin")]
        public int BotSpawnTimeOnMin;

        [JsonProperty("BotSpawnTimeOnMax")]
        public int BotSpawnTimeOnMax;

        [JsonProperty("BotSpawnTimeOffMin")]
        public int BotSpawnTimeOffMin;

        [JsonProperty("BotSpawnTimeOffMax")]
        public int BotSpawnTimeOffMax;

        [JsonProperty("BotEasy")]
        public int BotEasy;

        [JsonProperty("BotNormal")]
        public int BotNormal;

        [JsonProperty("BotHard")]
        public int BotHard;

        [JsonProperty("BotImpossible")]
        public int BotImpossible;

        [JsonProperty("BotAssault")]
        public int BotAssault;

        [JsonProperty("BotMarksman")]
        public int BotMarksman;

        [JsonProperty("DisabledScavExits")]
        public string DisabledScavExits;

        // todo
        [JsonProperty("AccessKeys")]
        public object[] AccessKeys;

        [JsonProperty("UnixDateTime")]
        public long UnixDateTime;

        // todo
        [JsonProperty("MinMaxBots")]
        public object[] MinMaxBots;

        [JsonProperty("BotLocationModifier")]
        public BotModifierModel BotLocationModifier;

        // todo
        [JsonProperty("exits")]
        public object[] Exits;

        [JsonProperty("DisabledForScav")]
        public bool DisabledForScav;

        // wooopwooooop

        [JsonProperty("maxItemCountInLocation")]
        public ItemLimitModel[] MaxItemCount;

        [JsonProperty("_id")]
        public string LocationId;

        [JsonProperty("Id")]
        public string Id;

        // todo
        [JsonProperty("Loot")]
        public object[] Loot;

        [JsonProperty("Banners")]
        public BannerModel[] Banners;

        // todo
        [JsonProperty("BossLocationSpawn")]
        public object[] BossLocationSpawn;
    }
}