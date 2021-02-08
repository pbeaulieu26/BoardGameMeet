using System.Collections.Generic;

namespace BoardGameMeet.Network.Responses
{
    public class GameListResponse : SearchResponse
    {
        public IEnumerable<object> Lists { get; internal set; }
    }
}
