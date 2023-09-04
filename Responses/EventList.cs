using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Responses
{
    public class EventList
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public IEnumerable<Attendees> Attendees{ get; set; }
    }

    public class Attendees{
        public string Name { get; set;}
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}