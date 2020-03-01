using BoardGameMeet.Network.Responses.Elements;
using Newtonsoft.Json;

namespace BoardGameMeet.Network.Responses
{
    [JsonObject]
    public class SearchResponse : BaseResponse
    {
        [JsonProperty("games")]
        public BoardGameElement[] Games { get; set; }
    }
}
