using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct ItemModel
    {
        [JsonProperty("_id")]
        public string ItemId;

        [JsonProperty("_tpl")]
        public string TemplateId;

        [JsonProperty("parentId")]
        public string? ParentId;

        [JsonProperty("slotId")]
        public string? SlotId;

        [JsonProperty("location")]
        public LocationModel? Location;

        [JsonProperty("upd")]
        public PropertyModel? Property;
    }
}