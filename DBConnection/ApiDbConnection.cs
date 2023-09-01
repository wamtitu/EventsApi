using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.DBConnection
{
    public class ApiDbConnection :DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<EventUser> EventUsers { get; set; }

        public ApiDbConnection(DbContextOptions<ApiDbConnection> options):base(options){}
        
    }
}