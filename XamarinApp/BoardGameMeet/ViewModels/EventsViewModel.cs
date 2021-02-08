using BoardGameMeet.Models;
using BoardGameMeet.Services.Interfaces;
using BoardGameMeet.ViewModels.Base;
using BoardGameMeet.ViewModels.CustomControllers;
using BoardGameMeet.ViewModels.Grouping;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoardGameMeet.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {
        private IScheduleService _scheduleService;
        private DateTime _monthOfYear;

        public CustomListViewModel<Activity, DailyActivities> Activities { get; private set; }

        public DateTime MonthOfYear
        {
            get { return _monthOfYear; }
            set { SetValue(ref _monthOfYear, value); }
        }

        public ICommand PreviousMonthCommand => new Command(async () => await PreviousMonth());

        public ICommand NextMonthCommand => new Command(async () => await NextMonth());

        public ICommand UpdateActivitiesCommand => new Command(async () => await UpdateActivitySchedule());

        public EventsViewModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
            MonthOfYear = DateTime.Now;
            Activities = new CustomListViewModel<Activity, DailyActivities>
            {
                SelectItemExecutionFunc = PreviousMonth
            };
        }

        private async Task PreviousMonth()
        {
            MonthOfYear = MonthOfYear.AddMonths(-1);
            await UpdateActivitySchedule();
        }

        private async Task NextMonth()
        {
            MonthOfYear = MonthOfYear.AddMonths(1);
            await UpdateActivitySchedule();
        }

        protected async Task UpdateActivitySchedule()
        {
            await Activities.UpdateList(async (token) =>
            {
                var activities = await _scheduleService.GetActivitiesByMonthOfYear(_monthOfYear.Month, _monthOfYear.Year, token);

                Activities.ItemCollection.Clear();
                foreach (var activity in activities)
                {
                    Activities.ItemCollection.Add(activity);
                }
            });
        }
    }
}
