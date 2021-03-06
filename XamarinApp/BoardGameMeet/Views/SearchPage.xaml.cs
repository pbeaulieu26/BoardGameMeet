﻿using BoardGameMeet.ViewModels;
using MenuApplication.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private SearchViewModel _viewModel;

        public SearchPage()
        {
            InitializeComponent();
            _viewModel = ViewModelLocator.Resolve<SearchViewModel>();
            BindingContext = _viewModel;
        }
    }
}
