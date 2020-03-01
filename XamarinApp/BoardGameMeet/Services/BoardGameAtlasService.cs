using System.Threading;
using System.Threading.Tasks;
using BoardGameMeet.Network.Helpers;
using BoardGameMeet.Network.Requests;
using BoardGameMeet.Network.Responses;
using BoardGameMeet.Services.Interfaces;

namespace BoardGameMeet.Services
{
    public class BoardGameAtlasService : IBoardGameAtlasService
    {
        private const string SearchRoute = "/search?";
        private const string GameListRoute = "/lists?";

        private readonly INetworkService _networkService;

        public BoardGameAtlasService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<SearchResponse> Search(SearchRequest request, CancellationToken token)
        {
            return await QueryAsync<SearchResponse>(request, SearchRoute, token);
        }

        public async Task<UserGameListsResponse> UserGameLists(UserGameListsRequest request, CancellationToken token)
        {
            return await QueryAsync<UserGameListsResponse>(request, GameListRoute, token);
        }

        public async Task<GameListResponse> GameList(GameListRequest request, CancellationToken token)
        {
            return await QueryAsync<GameListResponse>(request, SearchRoute, token);
        }

        private async Task<TResp> QueryAsync<TResp>(object request, string route, CancellationToken token) where TResp : BaseResponse
        {
            var query = route + request.ToQueryString();
            return await _networkService.GetAsync<TResp>(query, token);
        }
    }
}
