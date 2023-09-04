using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Models;
using Events.Requests;
using Events.Responses;

namespace Events.Services.IServices
{
    public interface IEvents
    {
        Task<string> CreateEventAsync(Event newEvent);
        Task<string> DeleteEventAsync(Event newEvent);
        Task<List<EventList>> GetEventsAsync(string?location);
        Task<Event> GetOneEventAsync(Guid Id);
        Task<string> UpdateEventAsync(Event newEvent);
        // Task<EventList> GetEventListAsync(Guid Id);
        Task<string> GetRemainingSlotsAsync(Guid Id);

    }
}