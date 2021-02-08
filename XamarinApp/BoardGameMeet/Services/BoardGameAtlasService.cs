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
            return await GetQueryAsync<SearchResponse>(request, SearchRoute, token);
        }

        public async Task<UserGameListsResponse> UserGameLists(UserGameListsRequest request, CancellationToken token)
        {
            return await GetQueryAsync<UserGameListsResponse>(request, GameListRoute, token);
        }

        public async Task<GameListResponse> GameList(GameListRequest request, CancellationToken token)
        {
            return await GetQueryAsync<GameListResponse>(request, SearchRoute, token);
        }

        public async Task<BaseResponse> AddGameList(BaseRequest request, CancellationToken token)
        {
            return await PostQueryAsync<BaseRequest, BaseResponse>(request, request, GameListRoute, token);
        }

        private async Task<TResp> GetQueryAsync<TResp>(object request, string route, CancellationToken token) where TResp : BaseResponse
        {
            var query = route + request.ToQueryString();
            return await _networkService.GetAsync<TResp>(query, token);
        }

        private async Task<TResp> PostQueryAsync<TReq, TResp>(BaseRequest client, TReq body, string route, CancellationToken token) where TResp : BaseResponse
        {
            var query = route + client.ToQueryString();
            return await _networkService.PostAsync<TReq, TResp>(query, body, token);
        }
    }
}
