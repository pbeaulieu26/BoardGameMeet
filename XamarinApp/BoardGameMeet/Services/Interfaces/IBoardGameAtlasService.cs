using BoardGameMeet.Network.Requests;
using BoardGameMeet.Network.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameMeet.Services.Interfaces
{
    public interface IBoardGameAtlasService
    {
        Task<SearchResponse> Search(SearchRequest request, CancellationToken token);
        Task<UserGameListsResponse> UserGameLists(UserGameListsRequest request, CancellationToken token);
        Task<GameListResponse> GameList(GameListRequest request, CancellationToken token);
    }
}
