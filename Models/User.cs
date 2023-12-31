using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role {get; set; } = "User";
        public string Password {get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}