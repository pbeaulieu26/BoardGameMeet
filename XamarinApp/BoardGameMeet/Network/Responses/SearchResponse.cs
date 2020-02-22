namespace BoardGameMeet.Network.Responses
{
    public class ImagesElement
    {
        public string thumb;
        public string small;
        public string medium;
        public string large;
        public string original;
    }

    public class BoardGameElement
    {
        public string name;
        public int? min_players;
        public int? max_players;
        public ImagesElement images;
        public string url;
    }

    public class SearchResponse : BaseResponse
    {
        public BoardGameElement[] games;
    }
}
