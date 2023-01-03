using Haru.Models.EFT.Bundle;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct ExitsModel
    {
		[JsonProperty("Name")]
        public string Name;

		[JsonProperty("EntryPoints")]
        public string EntryPoints;

		[JsonProperty("Chance")]
        public int Chance;

		[JsonProperty("MinTime")]
        public int MinTime;

		[JsonProperty("MaxTime")]
        public int MaxTime;

		[JsonProperty("PlayersCount")]
        public int PlayersCount;

		[JsonProperty("ExfiltrationTime")]
        public int ExfiltrationTime;

		[JsonProperty("PassageRequirement")]
        public string PassageRequirement;

		[JsonProperty("ExfiltrationType")]
        public string ExfiltrationType;

		[JsonProperty("Id")]
        public string Id;

		[JsonProperty("Count")]
        public int Count;

		[JsonProperty("RequirementTip")]
        public string RequirementTip;
	}

}