using BoardGameMeet.Helpers;
using BoardGameMeet.Models;
using System;
using System.Collections.ObjectModel;

namespace BoardGameMeet.ViewModels.Grouping
{
    public class DailyActivities : ObservableCollection<Activity>
    {
        public DateTime Date { get; set; }

        public string DayOfWeek => DateTimeFormatHelper.GetDayOfWeek(Date).ToUpper();

        public string FormatedDate => DateTimeFormatHelper.GetFormatedDate(Date);

        public new void Add(Activity activity)
        {
            if (Date == default)
            {
                Date = activity.EventTime.Date;
            }
            else if (!Date.Date.Equals(activity.EventTime.Date.Date))
            {
                throw new ArgumentException("Trying to add an activity on a different day");
            }

            base.Add(activity);
        }

        public new void Clear()
        {
            Date = default;
            base.Clear();
        }
    }
}
