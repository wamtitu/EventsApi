using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Requests
{
    public class CreateEvent
    {
        [Required]
        public string Name { get; set;}
        [Required]
        public string Description { get; set;}
        [Required]
        public string Location {get; set;}
        [Required]
        public int Capacity { get; set;}
        [Required]
        public int Ticket {get; set;}
        [Required]
        public DateTime Date { get; set;}
    }
}