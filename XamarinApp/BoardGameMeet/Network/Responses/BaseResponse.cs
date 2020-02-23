using BoardGameMeet.Network.Client;
using Newtonsoft.Json;

namespace BoardGameMeet.Network.Responses
{
    [JsonObject]
    public class BaseResponse
    {
        [JsonProperty("status")]
        public ApiStatus Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
