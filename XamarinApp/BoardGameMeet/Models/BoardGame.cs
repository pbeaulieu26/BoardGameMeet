using Newtonsoft.Json;

namespace BoardGameMeet.Models
{
    public class BoardGame
    {
        public string Name { get; set; }

        public int? MinPlayerCount { get; set; }

        public int? MaxPlayerCount { get; set; }

        public string ImageUrl { get; set; }

        public string DetailsUrl { get; set; }
    }
}
