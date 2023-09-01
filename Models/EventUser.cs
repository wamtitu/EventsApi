using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Models
{
    public class EventUser
    {
        public Guid EventUserId { get; set; }
        public Event Event { get; set; }
        public Guid EventID { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}