using BoardGameMeet.ViewModels.CustomControllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views.CustomControllers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomList : ContentView
    {
        public static readonly BindableProperty ItemTemplateProperty =
           BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CustomList));

        public static readonly BindableProperty GroupHeaderTemplateProperty =
           BindableProperty.Create(nameof(GroupHeaderTemplate), typeof(DataTemplate), typeof(CustomList));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public DataTemplate GroupHeaderTemplate
        {
            get { return (DataTemplate)GetValue(GroupHeaderTemplateProperty); }
            set { SetValue(GroupHeaderTemplateProperty, value); }
        }

        public CustomList()
        {
            InitializeComponent();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            BaseListViewModel model = (BaseListViewModel)BindingContext;

            if (model?.SelectItemCommand?.CanExecute(e.SelectedItem) ?? false)
            {
                model?.SelectItemCommand?.Execute(e.SelectedItem);
            }
        }
    }
}