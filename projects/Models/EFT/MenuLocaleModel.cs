using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct MenuLocaleModel
    {
        [JsonProperty("menu")]
        public Dictionary<string, string> Menu;
    }
}