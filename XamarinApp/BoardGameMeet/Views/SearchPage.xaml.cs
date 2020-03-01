using BoardGameMeet.ViewModels;
using MenuApplication.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.Resolve<SearchViewModel>();
        }
    }
}
