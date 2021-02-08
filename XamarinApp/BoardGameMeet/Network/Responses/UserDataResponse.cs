using BoardGameMeet.Models;
using Newtonsoft.Json;

namespace BoardGameMeet.Network.Responses
{

    [JsonObject]
    public class UserDataResponse : BaseResponse
    {
        [JsonProperty("user")]
        public User User;
    }
}
