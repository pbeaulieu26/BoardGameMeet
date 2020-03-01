using BoardGameMeet.Network.Helpers;

namespace BoardGameMeet.Network.Requests
{
    [RequestObject]
    public class AuthentificationRequest
    {
        [RequestProperty("email")]
        public string Email { get; set; }

        [RequestProperty("password")]
        public string Password { get; set; }
    }
}
