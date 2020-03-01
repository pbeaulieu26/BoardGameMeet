using Newtonsoft.Json;

namespace BoardGameMeet.Network.Responses
{
    [JsonObject]
    public class ListElement
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gameCount")]
        public int? GameCount { get; set; }
    }

    [JsonObject]
    public class UserGameListsResponse : BaseResponse
    {
        [JsonProperty("lists")]
        public ListElement[] Lists { get; set; }
    }
}
