using Newtonsoft.Json;

namespace Haru.Models.EFT.Friend
{
    public struct FriendModel
    {
        [JsonProperty("_id")]
        public string FriendId;

        [JsonProperty("Info")]
        public InfoModel Info;
    }
}
