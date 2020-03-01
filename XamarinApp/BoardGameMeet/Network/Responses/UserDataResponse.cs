using Newtonsoft.Json;

namespace BoardGameMeet.Network.Responses
{
    [JsonObject]
    public class User
    {
        [JsonProperty("username")]
        public string Username;

        [JsonProperty("image_url")]
        public string ImageUrl;
    }

    [JsonObject]
    public class UserDataResponse : BaseResponse
    {
        [JsonProperty("user")]
        public User User;
    }
}
