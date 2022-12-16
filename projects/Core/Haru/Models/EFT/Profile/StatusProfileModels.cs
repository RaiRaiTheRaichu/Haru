using Newtonsoft.Json;

namespace Haru.Models.EFT.Profile
{
    public struct StatusProfileModel
    {
        [JsonProperty("profileId")]
        public string ProfileId;

        [JsonProperty("profileToken")]
        public string ProfileToken;

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("sid")]
        public string SideId;

        [JsonProperty("ip")]
        public string Host;

        [JsonProperty("port")]
        public int Port;

        public StatusProfileModel(string profileId, string host, int port)
        {
            ProfileId = profileId;
            ProfileToken = null;
            Status = "Free";
            SideId = string.Empty;
            Host = host;
            Port = port;
        }
    }
}