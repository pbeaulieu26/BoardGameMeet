using BoardGameMeet.Network.Helpers;

namespace BoardGameMeet.Network.Requests
{
    [RequestObject]
    public class UserGameListsRequest : BaseRequest
    {
        [RequestProperty("username")]
        public string Username { get; set; }
    }
}
