using System;

namespace BoardGameMeet.Models
{
    public struct EventTime : IComparable<EventTime>
    {
        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }

        public int CompareTo(EventTime other)
        {
            if (!Date.Equals(other.Date))
            {
                return Date.CompareTo(other.Date);
            }
            else
            {
                return Duration.CompareTo(other.Duration);
            }
        }
    }
}
