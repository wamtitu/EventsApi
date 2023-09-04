using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.DBConnection;
using Events.Models;
using Events.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Events.Services
{
    public class UserServices : IUsers
    {
        private readonly ApiDbConnection _context;
        public UserServices(ApiDbConnection context){
            _context = context;
        }
        public async Task<string> CreateUsersAsync(User newUser)
        {
             _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return "User added successfully";
        }

        public async Task<string> DeleteUserAsync(User newUser)
        {
            _context.Users.Remove(newUser);
            await _context.SaveChangesAsync();
            return "user removed successfully";
        }

        public async Task<User> GetOneUserAsync(Guid Id)
        {
            return await _context.Users.Where(u=>u.UserId == Id).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<string> UpdateUserAsync(User newUser)
        {
            _context.Users.Update(newUser);
            await _context.SaveChangesAsync();
            return "user updated successfully";
        }

        public async Task<string> BookAnEventAsync(Guid UserId, Guid EventId)
        {
            var user = await _context.Users.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
            var events = await _context.Events.Where(x => x.EventId == EventId).FirstOrDefaultAsync();
            if (events == null)
            {
                return "Event not found";
            }
            if (user == null )
            {
                return "User not found";
            }
            events.Users.Add(user);
            await _context.SaveChangesAsync();
            return "Event booked successfully";
        }

        public async Task<User> GetUserByEmail(string email)
        {
           return await _context.Users.Where(u=>u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
           
        }
    }
}