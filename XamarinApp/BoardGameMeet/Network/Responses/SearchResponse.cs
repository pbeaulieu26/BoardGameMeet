using Newtonsoft.Json;

namespace BoardGameMeet.Network.Responses
{
    [JsonObject]
    public class ImagesElement
    {
        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }
    }

    [JsonObject]
    public class BoardGameElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("min_players")]
        public int? MinPlayers { get; set; }

        [JsonProperty("max_players")]
        public int? MaxPlayers { get; set; }

        [JsonProperty("images")]
        public ImagesElement Images { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    [JsonObject]
    public class SearchResponse : BaseResponse
    {
        [JsonProperty("games")]
        public BoardGameElement[] Games { get; set; }
    }
}
