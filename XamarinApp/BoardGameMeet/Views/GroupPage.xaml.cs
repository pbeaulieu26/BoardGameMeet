using BoardGameMeet.ViewModels;
using MenuApplication.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        private GroupViewModel _viewModel;

        public GroupPage()
        {
            InitializeComponent();
            _viewModel = ViewModelLocator.Resolve<GroupViewModel>();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            _viewModel?.GetGroupsCommand?.Execute(null);
        }

        protected override void OnDisappearing()
        {
            _viewModel?.GroupList?.CancelRunningTaskCommand?.Execute(null);
        }
    }
}