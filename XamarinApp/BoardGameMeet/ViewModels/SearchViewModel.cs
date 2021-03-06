﻿using BoardGameMeet.Models;
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
        private IBoardGameAtlasService _boardGameAtlasService;

        public CustomListViewModel<BoardGame> BoardGameList { get; private set; }

        public string SearchInput
        {
            get { return _searchInput; }
            set { SetValue(ref _searchInput, value); }
        }

        public ICommand SearchCommand => new Command(async () => await BoardGameList.UpdateList(Search));

        public SearchViewModel(IBoardGameAtlasService boardGameAtlasService)
        {
            _boardGameAtlasService = boardGameAtlasService;
            BoardGameList = new CustomListViewModel<BoardGame>()
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

            BoardGameList.ItemCollection.Clear();

            AddItems(response.Games);
        }

        private void AddItems(IList<BoardGameElement> boardGameElements)
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
