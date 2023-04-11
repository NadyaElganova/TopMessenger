using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMessenger.Models
{
    public class FriendList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Friends { get; set; }

    }
}
