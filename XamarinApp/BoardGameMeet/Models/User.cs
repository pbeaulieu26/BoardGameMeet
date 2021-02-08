using Newtonsoft.Json;

namespace BoardGameMeet.Models
{
    [JsonObject]
    public class User
    {
        [JsonProperty("username")]
        public string Name;

        [JsonProperty("image_url")]
        public string ImageUrl;
    }
}
