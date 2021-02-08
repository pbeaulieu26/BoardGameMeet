using System;

namespace BoardGameMeet.Models
{
    public class Activity : IComparable<Activity>
    {
        public int ActivityId { get; set; }

        public string Name { get; set; }

        public EventTime EventTime { get; set; }

        public string Location { get; set; }

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public Availability Status { get; set; }

        public int CompareTo(Activity other)
        {
            return EventTime.CompareTo(other.EventTime);
        }
    }
}
