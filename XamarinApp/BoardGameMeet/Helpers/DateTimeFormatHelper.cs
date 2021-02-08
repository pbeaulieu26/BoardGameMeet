using BoardGameMeet.Models;
using System;

namespace BoardGameMeet.Helpers
{
    public static class DateTimeFormatHelper
    {
        private enum Months
        {
            January = 1,
            Febuary = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        };

        private enum Day
        {
            Sunday = 0,
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6
        };

        public static string GetDayOfWeek(DateTime date)
        {
            return ((Day)date.DayOfWeek).ToString();
        }

        public static string GetFormatedDate(DateTime date)
        {
            var month = ((Months)date.Month).ToString().ToLower();
            return string.Format($"{date.Day} {month} {date.Year}");
        }

        public static string GetFormatedMonthOfYear(DateTime date)
        {
            var month = ((Months)date.Month).ToString().ToUpper();
            return string.Format($"{month} {date.Year}");
        }

        public static string GetFormatedTimeSpan(EventTime eventTime)
        {
            return GetFormatedTimeSpan(eventTime.Date, eventTime.Duration);
        }

        public static string GetFormatedTimeSpan(DateTime date, TimeSpan timeSpan)
        {
            var startTime = date.TimeOfDay;
            var endTime = startTime + timeSpan;

            var startFormat = startTime.Hours < 10 ? "h':'mm" : "hh':'mm";
            var endFormat = endTime.Hours < 10 ? "h':'mm" : "hh':'mm";

            return $"{startTime.ToString(startFormat)} - {endTime.ToString(endFormat)}";
        }
    }
}
