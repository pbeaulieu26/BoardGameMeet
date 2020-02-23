using BoardGameMeet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
