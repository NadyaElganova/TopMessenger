using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopMessenger.Models;

namespace TopMessenger.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
