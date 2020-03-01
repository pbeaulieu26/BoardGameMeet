using BoardGameMeet.Network.Helpers;

namespace BoardGameMeet.Network.Requests
{
    [RequestObject]
    public class BaseRequest
    {
        [RequestProperty("client_id")]
        public string ClientId { get; set; }
    }
}
