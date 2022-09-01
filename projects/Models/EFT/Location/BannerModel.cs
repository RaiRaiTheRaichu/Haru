using Haru.Models.EFT.Bundle;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct BannerModel
    {
        [JsonProperty("id")]
        public string BannerId;

        [JsonProperty("pic")]
        public ResourceModel Picture;
    }
}