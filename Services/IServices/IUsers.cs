using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Models;

namespace Events.Services.IServices
{
    public interface IUsers
    {
        Task<string> CreateUsersAsync(User newUser);
        Task<string> DeleteUserAsync(User newUser);
        Task<List<User>> GetUsersAsync();
        Task<User> GetOneUserAsync(Guid Id);
        Task<string> UpdateUserAsync(User newUser);
        // Task<List<User>> GetAllUsersInAnEvent(Guid id);
    }
}