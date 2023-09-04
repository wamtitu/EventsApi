using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.DBConnection;
using Events.Models;
using Events.Requests;
using Events.Responses;
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

        public async Task<List<EventList>> GetEventsAsync(string? location)
        {
            // if(string.IsNullOrWhiteSpace(location) || string.IsNullOrEmpty(location)){

            //    return await _context.Events.ToListAsync();
            // }
            // return await _context.Events.Where(u => u.Location == location).ToListAsync();


            if(string.IsNullOrEmpty(location) || string.IsNullOrEmpty(location)){
                return await _context.Events.Select(i => new EventList(){
                Id = i.EventId,
                Name = i.Name,
                Attendees = i.Users.Select(c => new Attendees(){
                    Name = c.Name,
                    Email =c.Email,
                    Phone = c.PhoneNumber,
                }).ToList()
            }).ToListAsync();
            }
            return await _context.Events.Where(u => u.Location == location).Select(i => new EventList(){
                Name = i.Name,
                Attendees = i.Users.Select(c => new Attendees(){
                    Name = c.Name,
                    Email =c.Email,
                    Phone = c.PhoneNumber,
                }).ToList()
            }).ToListAsync();
        }

        public async Task<Event> GetOneEventAsync(Guid Id)
        {
            return await _context.Events.Where(u=>u.EventId == Id).FirstOrDefaultAsync();
        }

        public async Task<string> GetRemainingSlotsAsync(Guid Id)
        {
             var events = await _context.Events.Where(u=>u.EventId == Id).FirstOrDefaultAsync();
             var totalBooking = events.Users.Count;
             var availableslots = events.Capacity - totalBooking;
            return $"{availableslots} available slots";
        }

        public async Task<string> UpdateEventAsync(Event newEvent)
        {
            _context.Events.Update(newEvent);
            await _context.SaveChangesAsync();
            return "Event updated successfully";
        }
    }
}