using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Locale
{
    public struct MenuModel
    {
        [JsonProperty("menu")]
        public Dictionary<string, string> Menu;
    }
}