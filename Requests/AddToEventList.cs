using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Requests
{
    public class AddToEventList
    {
        public Guid EventID { get; set; }
        public Guid UserId { get; set; }
    }
}