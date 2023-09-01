using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.DBConnection;
using Events.Models;
using Events.Requests;
using Events.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Events.Services
{
    public class EventsService : IEvents
    {
        private readonly ApiDbConnection _context;

        public EventsService(ApiDbConnection context){
            _context = context;
        }
        public async Task<string> CreateEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return "Event added successfully";
        }

        public async Task<string> DeleteEventAsync(Event newEvent)
        {
            _context.Events.Remove(newEvent);
            await _context.SaveChangesAsync();
            return "Event removed successfully";
        }

        public async Task<List<Event>> GetEventsAsync(string? location)
        {
            if(string.IsNullOrEmpty(location) || string.IsNullOrEmpty(location)){
                return await _context.Events.ToListAsync();
            }
           return await _context.Events.Where(u=>u.Location.ToLower() == location.ToLower()).ToListAsync();
        }

        public async Task<Event> GetOneEventAsync(Guid Id)
        {
            return await _context.Events.Where(u=>u.EventId == Id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateEventAsync(Event newEvent)
        {
            _context.Events.Update(newEvent);
            await _context.SaveChangesAsync();
            return "Event updated successfully";
        }
    }
}