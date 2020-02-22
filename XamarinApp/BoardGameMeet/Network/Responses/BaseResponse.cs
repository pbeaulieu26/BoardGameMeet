using BoardGameMeet.Network.Client;

namespace BoardGameMeet.Network.Responses
{
    public class BaseResponse
    {
        public ApiStatus status { get; set; }
        public string message { get; set; }
    }
}
