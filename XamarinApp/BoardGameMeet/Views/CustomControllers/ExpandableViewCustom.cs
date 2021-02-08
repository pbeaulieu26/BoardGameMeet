using Expandable;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoardGameMeet.Views.CustomControllers
{
    public class ExpandableViewCustom : ExpandableView
    {
        public static readonly BindableProperty ExpandCommandProperty =
            BindableProperty.Create(nameof(ExpandCommand), typeof(ICommand), typeof(ExpandableViewCustom));

        public static readonly BindableProperty CollapseCommandProperty =
            BindableProperty.Create(nameof(CollapseCommand), typeof(ICommand), typeof(ExpandableViewCustom));

        public ICommand ExpandCommand
        {
            get { return (ICommand)GetValue(ExpandCommandProperty); }
            set { SetValue(ExpandCommandProperty, value); }
        }

        public ICommand CollapseCommand
        {
            get { return (ICommand)GetValue(CollapseCommandProperty); }
            set { SetValue(CollapseCommandProperty, value); }
        }

        public ExpandableViewCustom()
        {
            Command = new Command(UpdateState);
            Spacing = 1;
        }

        private void UpdateState()
        {
            if (Status == ExpandStatus.Collapsed || Status == ExpandStatus.Expanding)
            {
                ExpandCommand?.Execute(this);
            }
            else
            {
                CollapseCommand?.Execute(this);
            }

            ForceUpdateSize();
        }
    }
}

