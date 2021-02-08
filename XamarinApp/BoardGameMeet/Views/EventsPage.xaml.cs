using BoardGameMeet.ViewModels;
using MenuApplication.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage
    {
        private EventsViewModel _viewModel;

        public EventsPage()
        {
            InitializeComponent();
            _viewModel = ViewModelLocator.Resolve<EventsViewModel>();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            _viewModel?.UpdateActivitiesCommand?.Execute(null);
        }

        protected override void OnDisappearing()
        {
            _viewModel?.Activities?.CancelRunningTaskCommand?.Execute(null);
        }
    }
}