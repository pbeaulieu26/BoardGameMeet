namespace BoardGameMeet.Services
{
    public class BoardGameAtlasNetworkService : NetworkService
    {
        private const string RootUrl = "https://api.boardgameatlas.com/api";

        public BoardGameAtlasNetworkService() : base(RootUrl)
        {
        }
    }
}
