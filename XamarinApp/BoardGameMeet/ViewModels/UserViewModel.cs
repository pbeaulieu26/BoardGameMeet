using BoardGameMeet.Models;
using BoardGameMeet.Network.Requests;
using BoardGameMeet.Network.Responses.Elements;
using BoardGameMeet.Services.Interfaces;
using BoardGameMeet.ViewModels.Base;
using BoardGameMeet.ViewModels.CustomControllers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoardGameMeet.ViewModels
{
    public class UserViewModel : CancellableTaskViewModel
    {
        private IBoardGameAtlasService _boardGameAtlasService;

        public CustomListViewModel<BoardGame> BoardGameList { get; private set; }

        public ICommand GetBoardGamesCommand => new Command(async () => await BoardGameList.UpdateList(GetBoardGames));

        public UserViewModel(IBoardGameAtlasService boardGameAtlasService)
        {
            _boardGameAtlasService = boardGameAtlasService;
            BoardGameList = new CustomListViewModel<BoardGame>()
            {
                SelectItemExecutionFunc = SelectItem
            };
        }

        private async Task GetBoardGames(CancellationToken token)
        {
            var listsRequest = new UserGameListsRequest
            {
                ClientId = "6XH5yEJAag",
                Username = "mathieu.favreau@usherbrooke.ca"
            };

            var listsResponse = await _boardGameAtlasService.UserGameLists(listsRequest, token);

            var games = new List<BoardGameElement>();

            foreach (var list in listsResponse.Lists)
            {
                var listRequest = new GameListRequest
                {
                    ClientId = "6XH5yEJAag",
                    ListId = list.Id
                };

                var listResponse = await _boardGameAtlasService.GameList(listRequest, token);
                games.AddRange(listResponse.Games);
            }

            BoardGameList.ItemCollection.Clear();

            AddItems(games);
        }

        private void AddItems(IEnumerable<BoardGameElement> boardGameElements)
        {
            foreach (var boardGameResp in boardGameElements)
            {
                BoardGameList.ItemCollection.Add(new BoardGame
                {
                    Name = boardGameResp.Name,
                    MinPlayerCount = boardGameResp.MinPlayers,
                    MaxPlayerCount = boardGameResp.MaxPlayers,
                    ImageUrl = boardGameResp.Images.Medium,
                    DetailsUrl = boardGameResp.Url
                });
            }
        }

        private async Task SelectItem()
        {
            await Launcher.OpenAsync(new Uri(BoardGameList.SelectedItem.DetailsUrl));
        }
    }
}
