using BoardGameMeet.Network.Helpers;

namespace BoardGameMeet.Network.Requests
{
    [RequestObject]
    public class SearchRequest : BaseRequest
    {
        [RequestProperty("name")]
        public string Name { get; set; }

        [RequestProperty("fuzzy_match")]
        public bool? FuzzyMatch { get; set; }

        [RequestProperty("limit")]
        public int? Limit { get; set; }
    }
}
