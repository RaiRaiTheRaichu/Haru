using Haru.Models.EFT.Friend;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Mail
{
    public struct MailModel
    {
        [JsonProperty("attachmentsNew")]
        public int NewAttachments;

        [JsonProperty("new")]
        public int New;

        [JsonProperty("type")]
        public int Type;

        [JsonProperty("Users")]
        public FriendModel[] Users;

        [JsonProperty("pinned")]
        public bool Pinned;

        [JsonProperty("message")]
        public MessageModel Message;

        [JsonProperty("_id")]
        public string MailId;
    }
}
