using Xamarin.Forms;

using MenuApplication.ViewModels.Base;
using BoardGameMeet.ViewModels;

namespace BoardGameMeet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ViewModelLocator.Initialize();

            MainPage = new NavigationPage(new MainPage(ViewModelLocator.Resolve<MainViewModel>()));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
