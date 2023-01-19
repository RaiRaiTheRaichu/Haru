using Newtonsoft.Json;

namespace Haru.Models.EFT.Hideout
{
    public struct ScavcaseModel
    {
        [JsonProperty("_id")]
        public string ScavcaseId;

        [JsonProperty("ProductionTime")]
        public int ProductionTime;

        [JsonProperty("Requirements")]
        public RequirementModel[] Requirements;

        [JsonProperty("EndProducts")]
        public EndProductsModel EndProducts;
    }
}