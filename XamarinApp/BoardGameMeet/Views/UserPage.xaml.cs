using BoardGameMeet.ViewModels;
using MenuApplication.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.Resolve<UserViewModel>();
        }
    }
}