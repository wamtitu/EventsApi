using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Requests
{
    public class BookEvent
    {
        public Guid UserId { get; set; }
        public Guid EventId{ get; set; }
    }
}