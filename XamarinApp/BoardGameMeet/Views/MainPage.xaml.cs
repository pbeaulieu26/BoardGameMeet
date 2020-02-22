using BoardGameMeet.ViewModels;
using Xamarin.Forms;

namespace BoardGameMeet
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}
