using Newtonsoft.Json;

namespace BoardGameMeet.Network.Requests
{
    [JsonObject]
    public class AuthentificationRequest
    {
        [JsonProperty("status")]
        public string email { get; set; }

        [JsonProperty("status")]
        public string password { get; set; }
    }
}
