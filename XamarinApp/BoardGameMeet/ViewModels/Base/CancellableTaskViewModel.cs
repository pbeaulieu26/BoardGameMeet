using BoardGameMeet.Helpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoardGameMeet.ViewModels.Base
{
    public class CancellableTaskViewModel : BaseViewModel
    {
        protected UniqueExecutionTaskQueue _uniqueExecutionTaskQueue;

        public ICommand CancelRunningTaskCommand => new Command(async () => await _uniqueExecutionTaskQueue.CancelAsync());

        public CancellableTaskViewModel()
        {
            _uniqueExecutionTaskQueue = new UniqueExecutionTaskQueue();
        }
    }
}
