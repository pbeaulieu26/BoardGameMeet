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
    public class SearchViewModel : BaseViewModel
    {
        private string _searchInput;
        private string _name;
        private string _players;
        private IBoardGameAtlasService _boardGameAtlasService;

        public CustomListViewModel<BoardGame> CustomListViewModel { get; private set; }

        public string SearchInput
        {
            get { return _searchInput; }
            set { SetValue(ref _searchInput, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        public string Players
        {
            get { return _players; }
            set { SetValue(ref _players, value); }
        }

        public ICommand SearchCommand => new Command(async () => await CustomListViewModel.UpdateList(Search));

        public ICommand GetMyGamesCommand => new Command(async () => await CustomListViewModel.UpdateList(GetMyGames));

        public SearchViewModel(IBoardGameAtlasService boardGameAtlasService)
        {
            _boardGameAtlasService = boardGameAtlasService;
            CustomListViewModel = new CustomListViewModel<BoardGame>()
            {
                SelectItemExecutionFunc = SelectItem
            };
        }

        private async Task Search(CancellationToken token)
        {
            var request = new SearchRequest
            {
                ClientId = "6XH5yEJAag",
                Name = SearchInput,
                FuzzyMatch = true,
                Limit = 10
            };

            var response = await _boardGameAtlasService.Search(request, token);

            CustomListViewModel.ItemCollection.Clear();

            AddItems(response.Games);
        }

        private async Task GetMyGames(CancellationToken token)
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

            CustomListViewModel.ItemCollection.Clear();

            AddItems(games);
        }

        private void AddItems(IList<BoardGameElement> boardGameElements)
        {
            foreach (var boardGameResp in boardGameElements)
            {
                CustomListViewModel.ItemCollection.Add(new BoardGame
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
            await Launcher.OpenAsync(new Uri(CustomListViewModel.SelectedItem.DetailsUrl));
        }
    }
}
