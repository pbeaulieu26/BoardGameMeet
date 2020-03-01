using BoardGameMeet.Network.Helpers;

namespace BoardGameMeet.Network.Requests
{
    [RequestObject]
    public class GameListRequest : BaseRequest
    {
        [RequestProperty("list_id")]
        public string ListId { get; set; }

        [RequestProperty("limit")]
        public int? Limit { get; set; }
    }
}
