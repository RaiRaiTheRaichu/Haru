using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct PropertyModel
    {
        [JsonProperty("StackObjectsCount")]
        public int? StackObjectsCount;

        [JsonProperty("SpawnedInSession")]
        public bool? SpawnedInSession;

        [JsonProperty("BuyRestrictionCurrent")]
        public int? BuyRestrictionCurrent;

        [JsonProperty("BuyRestrictionMax")]
        public int? BuyRestrictionMax;


        [JsonProperty("Dogtag")]
        public DogtagModel? Dogtag;

        [JsonProperty("FireMode")]
        public FireModeModel? FireMode;

        [JsonProperty("FoodDrink")]
        public FoodDrinkModel? FoodDrink;

        [JsonProperty("Foldable")]
        public FoldableModel? Foldable;

        [JsonProperty("Key")]
        public KeyModel? Key;

        [JsonProperty("Light")]
        public LightModel? Light;

        [JsonProperty("Map")]
        public MapModel? Map;

        [JsonProperty("MedKit")]
        public MedKitModel? MedKit;

        [JsonProperty("Repairable")]
        public RepairableModel? Repairable;

        [JsonProperty("RepairKit")]
        public RepairKitModel? RepairKit;

        [JsonProperty("Resource")]
        public ResourceModel? Resource;

        [JsonProperty("SideEffect")]
        public ResourceModel? SideEffect;

        [JsonProperty("Sight")]
        public SightModel? Sight;

        [JsonProperty("Tag")]
        public TagModel? Tag;
    }
}
