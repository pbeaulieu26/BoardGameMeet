using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BoardGameMeet.Models;
using BoardGameMeet.Services.Interfaces;
using BoardGameMeet.ViewModels.Grouping;
using Xamarin.Forms.Internals;

namespace BoardGameMeet.Services.Mock
{
    public class ScheduleServiceMock : IScheduleService
    {
        private List<DailyActivities> _lastCreatedActivities;
        private IPageService _pageService;

        public ScheduleServiceMock(IPageService pageService)
        {
            _pageService = pageService;
            _lastCreatedActivities = new List<DailyActivities>();
        }

        public Task<Activity> GetDetailedActivity(int activityId, int teamId, CancellationToken token)
        {
            var activities = new List<Activity>();
            _lastCreatedActivities.ForEach(da => da.ForEach(a => activities.Add(a)));
            return Task.FromResult(activities.FirstOrDefault(a => a.ActivityId == activityId));
        }

        public Task<List<DailyActivities>> GetActivitiesByMonthOfYear(int month, int year, CancellationToken token)
        {
            _lastCreatedActivities = new List<DailyActivities>
            {
                GenerateDailyActivities(new DateTime(year, month, 11)),
                GenerateDailyActivities(new DateTime(year, month, 12))
            };

            return Task.FromResult(_lastCreatedActivities);
        }

        public List<DailyActivities> GetActivitiesByWeek(DateTime date)
        {
            var firstDayOfWeek = date.AddDays(-(int)date.DayOfWeek);

            _lastCreatedActivities = new List<DailyActivities>
            {
                GenerateDailyActivities(firstDayOfWeek),
                GenerateDailyActivities(firstDayOfWeek.AddDays(2)),
                GenerateDailyActivities(firstDayOfWeek.AddDays(5))
            };

            return _lastCreatedActivities;
        }

        public Task<List<DailyActivities>> GetActivitiesForNextDays(int days, CancellationToken token)
        {
            _lastCreatedActivities = new List<DailyActivities>
            {
                GenerateDailyActivities(DateTime.Now.Date),
                GenerateDailyActivities(DateTime.Now.Date.AddDays(new Random().Next(1, days)))
            };
            return Task.FromResult(_lastCreatedActivities);
        }

        private DailyActivities GenerateDailyActivities(DateTime date)
        {
            return new DailyActivities
            {
                new Activity
                {
                    ActivityId = 1,
                    Name = "Brass",
                    EventTime = new EventTime
                    {
                        Date = date.AddHours(9).AddMinutes(30),
                        Duration = new TimeSpan(1, 30, 0)
                    },
                    Location = "WeWork",
                    GroupName = "Bitconnect",
                    Status = Availability.Absent
                },

                new Activity
                {
                    ActivityId = 2,
                    Name = "Clank! in! Space!",
                    EventTime = new EventTime
                    {
                        Date = date.AddHours(10).AddMinutes(30),
                        Duration = new TimeSpan(1, 30, 0)
                    },
                    Location = "WeWork",
                    GroupName = "Bitconnect",
                    Status = Availability.None
                },

                new Activity
                {
                    ActivityId = 3,
                    Name = "Catan",
                    EventTime = new EventTime
                    {
                        Date = date.AddHours(12).AddMinutes(30),
                        Duration = new TimeSpan(1, 0, 0)
                    },
                    Location = "WeWork",
                    GroupName = "Bitconnect",
                    Status = Availability.Unspecified,
                }
            };
        }
    }
}
