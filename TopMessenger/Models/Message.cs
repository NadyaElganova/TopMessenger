using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMessenger.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateOfSend { get; set; } = DateTime.Now;
        public string PhotoOfUser { get; set; }
        public User Dender { get; set; }
        public User Receiver { get; set; }
    }
}
