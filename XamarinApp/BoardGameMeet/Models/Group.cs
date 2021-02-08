using System.Collections.Generic;

namespace BoardGameMeet.Models
{
    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<User> Members { get; set; }
    }
}
