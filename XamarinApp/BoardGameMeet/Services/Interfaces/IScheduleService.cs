using BoardGameMeet.Models;
using BoardGameMeet.ViewModels.Grouping;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameMeet.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<Activity> GetDetailedActivity(int activityId, int teamId, CancellationToken token);

        Task<List<DailyActivities>> GetActivitiesByMonthOfYear(int month, int year, CancellationToken token);

        List<DailyActivities> GetActivitiesByWeek(DateTime date);

        Task<List<DailyActivities>> GetActivitiesForNextDays(int days, CancellationToken token);
    }
}
