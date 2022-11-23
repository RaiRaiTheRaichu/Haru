using Newtonsoft.Json;

namespace Haru.Models.EFT.Friend
{
    public struct FriendListModel
    {
        [JsonProperty("Friends")]
        public FriendModel[] Friends;
    }
}
