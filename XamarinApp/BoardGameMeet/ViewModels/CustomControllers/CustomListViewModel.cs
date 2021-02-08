using BoardGameMeet.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoardGameMeet.ViewModels.CustomControllers
{
    public class BaseListViewModel : CancellableTaskViewModel
    {
        public ICommand SelectItemCommand { get; protected set; }
    }

    public class CustomListViewModel<TItem, TGroup> : CustomListViewModel<TItem>
    {
        public new ObservableCollection<TGroup> ItemCollection { get; private set; }

        public new bool IsGroupingEnabled => true;

        public CustomListViewModel()
        {
            ItemCollection = new ObservableCollection<TGroup>();
        }
    }

    public class CustomListViewModel<TItem> : BaseListViewModel
    {
        private const string ErrorString = "Error while loading data";
        private const string EmptyListString = "No data to display";

        private TItem _selectedItem;
        private bool _isRefreshing;
        private bool _isUpdateError;
        private string _emptyListMessage;

        public ObservableCollection<TItem> ItemCollection { get; private set; }

        public bool IsGroupingEnabled => false;

        public TItem SelectedItem
        {
            get { return _selectedItem; }
            set { SetValue(ref _selectedItem, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetValue(ref _isRefreshing, value); }
        }

        public bool IsUpdateError
        {
            get { return _isUpdateError; }
            set { SetValue(ref _isUpdateError, value); }
        }

        public string EmptyListMessage
        {
            get { return _emptyListMessage; }
            set { SetValue(ref _emptyListMessage, value); }
        }

        public Func<Task> SelectItemExecutionFunc { get; set; }

        public CustomListViewModel()
        {
            ItemCollection = new ObservableCollection<TItem>();
            SelectItemCommand = new Command<TItem>(async i => await SelectItem(i));
            IsUpdateError = false;
        }

        private async Task SelectItem(TItem viewModel)
        {
            if (viewModel == null)
                return;

            try
            {
                await (SelectItemExecutionFunc?.Invoke() ?? Task.FromResult(0));
            }
            finally
            {
                SelectedItem = default;
            }
        }

        public async Task UpdateList(Func<CancellationToken,Task> updateFunc)
        {
            try
            {
                IsRefreshing = true;

                await _uniqueExecutionTaskQueue.ExecuteAsync(updateFunc);

                EmptyListMessage = EmptyListString;
                IsUpdateError = false;
            }
            catch (Exception)
            {
                EmptyListMessage = ErrorString;
                IsUpdateError = true;
            }
            finally
            {
                if (!_uniqueExecutionTaskQueue.IsExecuting())
                {
                    IsRefreshing = false;
                }
            }
        }
    }
}
