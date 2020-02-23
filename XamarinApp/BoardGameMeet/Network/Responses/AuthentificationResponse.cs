using Newtonsoft.Json;

namespace BoardGameMeet.Network.Responses
{
    [JsonObject]
    public class AuthentificationResponse : BaseResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
