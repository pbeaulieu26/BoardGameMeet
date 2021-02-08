using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BoardGameMeet.Models;
using BoardGameMeet.Network.Helpers;
using BoardGameMeet.Network.Requests;
using BoardGameMeet.Network.Responses;
using BoardGameMeet.Network.Responses.Elements;
using BoardGameMeet.Services.Interfaces;

namespace BoardGameMeet.Services
{
    public class BoardGameService : IBoardGameService
    {
        private const string SearchRoute = "/search?";
        private const string GameListRoute = "/lists?";

        private readonly INetworkService _networkService;

        public BoardGameService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<IEnumerable<BoardGameElement>> UserGameList(User user, CancellationToken token)
        {
            var request = new UserGameListsRequest
            {
                ClientId = "6XH5yEJAag",
                Username = user.Name
            };

            var listsResponse = await QueryAsync<UserGameListsResponse>(request, GameListRoute, token);

            var games = new List<BoardGameElement>();

            foreach (var list in listsResponse.Lists)
            {
                var listRequest = new GameListRequest
                {
                    ClientId = "6XH5yEJAag",
                    ListId = list.Id
                };

                var listResponse = await QueryAsync<GameListResponse>(listRequest, SearchRoute, token);
                games.AddRange(listResponse.Games);
            }

            return games;
        }

        private async Task<TResp> QueryAsync<TResp>(object request, string route, CancellationToken token) where TResp : BaseResponse
        {
            var query = route + request.ToQueryString();
            return await _networkService.GetAsync<TResp>(query, token);
        }
    }
}
