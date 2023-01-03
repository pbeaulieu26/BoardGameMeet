using BoardGameMeet.Models;
using BoardGameMeet.Network.Requests;
using BoardGameMeet.Network.Responses.Elements;
using BoardGameMeet.Services.Interfaces;
using BoardGameMeet.ViewModels.Base;
using BoardGameMeet.ViewModels.CustomControllers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public CustomListViewModel<BoardGame> OwnedBoardGameList { get; private set; }

        public CustomListViewModel<BoardGame> WishedBoardGameList { get; private set; }

        public ICommand GetOwnedBoardGamesCommand => new Command(async () => await OwnedBoardGameList.UpdateList(GetOwnedBoardGames));

        public ICommand GetWishedBoardGamesCommand => new Command(async () => await WishedBoardGameList.UpdateList(GetWishedBoardGames));

        public UserViewModel(IBoardGameAtlasService boardGameAtlasService)
        {
            _boardGameAtlasService = boardGameAtlasService;
            OwnedBoardGameList = new CustomListViewModel<BoardGame>()
            {
                SelectItemExecutionFunc = SelectedOwnedBoardGame
            };
            WishedBoardGameList = new CustomListViewModel<BoardGame>()
            {
                SelectItemExecutionFunc = SelectedWishedBoardGame
            };
        }

        private async Task GetOwnedBoardGames(CancellationToken token)
        {
            var games = await GetListBoardGames("Owned", token);
            OwnedBoardGameList.ItemCollection.Clear();
            AddItems(OwnedBoardGameList, games);
        }

        private async Task GetWishedBoardGames(CancellationToken token)
        {
            var games = await GetListBoardGames("Wishlist", token);
            WishedBoardGameList.ItemCollection.Clear();
            AddItems(WishedBoardGameList, games);
        }

        private async Task<List<BoardGameElement>> GetListBoardGames(string listName, CancellationToken token)
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
                if (list.Name != listName)
                {
                    continue;
                }
                
                var listRequest = new GameListRequest
                {
                    ClientId = "6XH5yEJAag",
                    ListId = list.Id
                };

                var listResponse = await _boardGameAtlasService.GameList(listRequest, token);
                games.AddRange(listResponse.Games);
            }

            return games;
        }

        private void AddItems(CustomListViewModel<BoardGame> boardGameList, IEnumerable<BoardGameElement> boardGameElements)
        {
            foreach (var boardGameResp in boardGameElements)
            {
                boardGameList.ItemCollection.Add(new BoardGame
                {
                    Name = boardGameResp.Name,
                    MinPlayerCount = boardGameResp.MinPlayers,
                    MaxPlayerCount = boardGameResp.MaxPlayers,
                    ImageUrl = boardGameResp.Images.Medium,
                    DetailsUrl = boardGameResp.Url
                });
            }
        }

        private async Task SelectedOwnedBoardGame()
        {
            await Launcher.OpenAsync(new Uri(OwnedBoardGameList.SelectedItem.DetailsUrl));
        }

        private async Task SelectedWishedBoardGame()
        {
            await Launcher.OpenAsync(new Uri(WishedBoardGameList.SelectedItem.DetailsUrl));
        }
    }
}
