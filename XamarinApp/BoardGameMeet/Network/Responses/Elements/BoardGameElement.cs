using Newtonsoft.Json;

namespace BoardGameMeet.Network.Responses.Elements
{
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
}
