namespace BoardGameMeet.Services
{
    public class BoardGameAtlasNetworkService : NetworkService
    {
        private const string RootUrl = "https://www.boardgameatlas.com/api";

        public BoardGameAtlasNetworkService() : base(RootUrl)
        {
        }
    }
}
