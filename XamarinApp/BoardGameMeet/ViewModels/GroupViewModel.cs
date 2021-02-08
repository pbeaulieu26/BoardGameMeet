using BoardGameMeet.Models;
using BoardGameMeet.Services.Interfaces;
using BoardGameMeet.ViewModels.Base;
using BoardGameMeet.ViewModels.CustomControllers;

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BoardGameMeet.ViewModels
{
    public class GroupViewModel : BaseViewModel
    {
        private IGroupService _groupService;

        public CustomListViewModel<Group> GroupList { get; private set; }

        public ICommand GetGroupsCommand => new Command(async () => await GroupList.UpdateList(GetGroups));

        public GroupViewModel(IGroupService groupService)
        {
            _groupService = groupService;
            GroupList = new CustomListViewModel<Group>();
        }

        private async Task GetGroups(CancellationToken token)
        {
            var groups = await _groupService.GetMyGroups(token);
            GroupList.ItemCollection.Clear();
            groups.ForEach(group => GroupList.ItemCollection.Add(group));
        }
    }
}
