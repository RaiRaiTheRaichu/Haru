using Haru.Models.EFT.Bundle;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct LocationModel
    {
        [JsonProperty("Enabled")]
        public bool Enabled;

        [JsonProperty("EnabledCoop")]
        public bool EnabledCoop;

        [JsonProperty("Locked")]
        public bool Locked;

        [JsonProperty("Insurance")]
        public bool Insurance;

        [JsonProperty("SafeLocation")]
        public bool SafeLocation;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("Description")]
        public string Description;
        
        [JsonProperty("Scene")]
        public ResourceModel Scene;

        [JsonProperty("Area")]
        public float Area;

        [JsonProperty("RequiredPlayerLevel")]
        public int RequiredPlayerLevel;

        [JsonProperty("PmcMaxPlayersInGroup")]
        public int PmcMaxPlayersInGroup;

        [JsonProperty("ScavMaxPlayersInGroup")]
        public int ScavMaxPlayersInGroup;

        [JsonProperty("MinPlayers")]
        public int MinPlayers;

        [JsonProperty("MaxCoopGroup")]
        public int MaxCoopGroup;

        [JsonProperty("MaxPlayers")]
        public int MaxPlayers;

        [JsonProperty("exit_count")]
        public int exit_count;

        [JsonProperty("exit_access_time")]
        public int exit_access_time;

        [JsonProperty("exit_time")]
        public int exit_time;
        
        [JsonProperty("Preview")]
        public ResourceModel Preview;

        [JsonProperty("IconX")]
        public int IconX;

        [JsonProperty("IconY")]
        public int IconY;

        // todo, always empty array
        [JsonProperty("filter_ex")]
        public object[] filter_ex;

        [JsonProperty("waves")]
        public WaveModel[] Waves;

        // todo, always empty array
        [JsonProperty("limits")]
        public object[] Limits;

        [JsonProperty("AveragePlayTime")]
        public int AveragePlayTime;

        [JsonProperty("AveragePlayerLevel")]
        public int AveragePlayerLevel;

        [JsonProperty("escape_time_limit")]
        public int EscapeTimeLimit;

        [JsonProperty("EscapeTimeLimitCoop")]
        public int EscapeTimeLimitCoop;

        [JsonProperty("Rules")]
        public string Rules;

        [JsonProperty("IsSecret")]
        public bool IsSecret;

        // todo, always empty array
        [JsonProperty("doors")]
        public object[] Doors;

        // todo, unknown value
        [JsonProperty("tmp_location_field_remove_me")]
        public int tmp_location_field_remove_me;

        [JsonProperty("MinDistToExitPoint")]
        public int MinDistToExitPoint;

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

        [JsonProperty("GlobalLootChanceModifier")]
        public float GlobalLootChanceModifier;

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

        [JsonProperty("BotMaxTimePlayer")]
        public int BotMaxTimePlayer;

        [JsonProperty("BotSpawnTimeOnMin")]
        public int BotSpawnTimeOnMin;

        [JsonProperty("BotSpawnTimeOnMax")]
        public int BotSpawnTimeOnMax;

        [JsonProperty("BotSpawnTimeOffMin")]
        public int BotSpawnTimeOffMin;

        [JsonProperty("BotSpawnTimeOffMax")]
        public int BotSpawnTimeOffMax;

        [JsonProperty("BotMaxPlayer")]
        public int BotMaxPlayer;

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

        [JsonProperty("AccessKeys")]
        public string[] AccessKeys;

        [JsonProperty("UnixDateTime")]
        public long UnixDateTime;

        [JsonProperty("users_gather_seconds")]
        public int users_gather_seconds;

        [JsonProperty("users_spawn_seconds_n")]
        public int users_spawn_seconds_n;

        [JsonProperty("users_spawn_seconds_n2")]
        public int users_spawn_seconds_n2;

        [JsonProperty("users_summon_seconds")]
        public int users_summon_seconds;

        [JsonProperty("sav_summon_seconds")]
        public int sav_summon_seconds;

        [JsonProperty("matching_min_seconds")]
        public int matching_min_seconds;

        [JsonProperty("MinMaxBots")]
        public BotLimitModel[] MinMaxBots;

        [JsonProperty("BotLocationModifier")]
        public BotModifierModel BotLocationModifier;

        [JsonProperty("exits")]
        public ExitsModel[] Exits;

        [JsonProperty("DisabledForScav")]
        public bool DisabledForScav;

        [JsonProperty("BossLocationSpawn")]
        public BossLocationSpawnModel[] BossLocationSpawn;

        [JsonProperty("SpawnPointParams")]
        public SpawnPointParamsModel[] SpawnPointParams;

        [JsonProperty("maxItemCountInLocation")]
        public ItemLimitModel[] MaxItemCount;

        [JsonProperty("Id")]
        public string Id;

        [JsonProperty("_Id")]
        public string LocationId;
        
        [JsonProperty("Loot")]
        public LootModel[] Loot;

        [JsonProperty("Banners")]
        public BannerModel[] Banners;

        [JsonProperty("GenerateLocalLootCache")]
        public bool GenerateLocalLootCache;

        [JsonProperty("AirdropParameters")]
        public AirdropParametersModel[] AirdropParameters;
    }
}