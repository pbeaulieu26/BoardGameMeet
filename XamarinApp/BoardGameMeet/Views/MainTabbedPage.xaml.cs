using BoardGameMeet.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainTabbedPage : TabbedPage
    {
		public MainTabbedPage()
		{
            InitializeComponent();
        }
	}
}