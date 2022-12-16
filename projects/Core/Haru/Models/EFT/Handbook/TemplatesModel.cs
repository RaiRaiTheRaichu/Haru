using Newtonsoft.Json;

namespace Haru.Models.EFT.Handbook
{
    public struct TemplatesModel
    {
        [JsonProperty("Categories")]
        public CategoryModel[] Categories;

        [JsonProperty("Items")]
        public ItemModel[] Items;
    }
}