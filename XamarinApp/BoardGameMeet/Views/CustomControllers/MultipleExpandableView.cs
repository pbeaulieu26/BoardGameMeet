using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoardGameMeet.Views.CustomControllers
{
    public class MultipleExpandableView : StackLayout
    {
        private List<ExpandableViewCustom> _expandableViews = new List<ExpandableViewCustom>();
        private Dictionary<ExpandableViewCustom, ICommand> _updateCommands = new Dictionary<ExpandableViewCustom, ICommand>();
        private Mutex mutex = new Mutex();

        public ICommand ExpendCommand => new Command<ExpandableViewCustom>(async view => await HandleExpend(view));
        public ICommand CollapseCommand => new Command<ExpandableViewCustom>(HandleCollapse);

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            foreach (var view in Children.Where(child => child is ExpandableViewCustom).Select(view => view as ExpandableViewCustom))
            {
                _updateCommands[view] = view.ExpandCommand;
                view.ExpandCommand = ExpendCommand;
                view.CollapseCommand = CollapseCommand;
                _expandableViews.Add(view);
            }
        }

        private async Task HandleExpend(ExpandableViewCustom expendingView)
        {
            if (mutex.WaitOne(0))
            {
                foreach (var view in _expandableViews.Where(view => view != expendingView))
                {
                    view.IsExpanded = false;
                    view.IsTouchToExpandEnabled = false;
                    view.ForceUpdateSize();
                }

                if (!expendingView.IsTouchToExpandEnabled)
                {
                    await Task.Delay((int)(expendingView.ExpandAnimationLength * 1.25));
                    expendingView.IsTouchToExpandEnabled = true;
                    expendingView.IsExpanded = true;
                    await Task.Delay((int)(expendingView.ExpandAnimationLength * 1.25));
                }

                _updateCommands[expendingView]?.Execute(this);

                foreach (var view in _expandableViews.Where(view => view != expendingView))
                {
                    view.IsExpanded = false;
                    view.IsTouchToExpandEnabled = false;
                    view.ForceUpdateSize();
                }

                expendingView.ForceUpdateSize();

                mutex.ReleaseMutex();
            }     
        }

        private void HandleCollapse(ExpandableViewCustom collapsingView)
        {
            collapsingView.IsTouchToExpandEnabled = true;
        }
    }
}
