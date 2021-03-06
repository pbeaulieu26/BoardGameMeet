﻿using BoardGameMeet.Models;
using BoardGameMeet.Network.Responses;
using BoardGameMeet.Services.Interfaces;
using BoardGameMeet.ViewModels.Base;
using BoardGameMeet.ViewModels.CustomControllers;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BoardGameMeet.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private const string SearchUrl = "/search?client_id=6XH5yEJAag&limit=5&fuzzy_match=true&";

        private string _searchInput;
        private string _name;
        private string _players;
        private INetworkService _networkService;

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

        public MainViewModel(INetworkService networkService)
        {
            _networkService = networkService;
            CustomListViewModel = new CustomListViewModel<BoardGame>()
            {
                SelectItemExecutionFunc = SelectItem
            };

            _searchInput = "Catan";
        }

        private async Task Search(CancellationToken token)
        {
            var response = await _networkService.GetAsync<SearchResponse>(SearchUrl + "name=" + _searchInput, token);

            CustomListViewModel.ItemCollection.Clear();

            foreach (var boardGameResp in response.Games)
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
