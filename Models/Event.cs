using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Models
{
    public class Event
    {
        public Guid EventId { get; set; } 
        public string Name { get; set;}= string.Empty;
        public string Description { get; set;} = string.Empty;
        public string Location {get; set;}=string.Empty;
        public int Capacity { get; set;}=0;
        public int Ticket {get; set;}=0;
        public DateTime Date { get; set;}
        public List<User> Users { get; set;} = new List<User>();
    }
}