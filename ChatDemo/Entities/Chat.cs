using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatDemo.Entities
{
    public class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
            Users = new List<AppUser>();
        }

        public int Id { get; set; }

        [NotMapped]
        public string Name { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<AppUser> Users { get; set; }
    }
}
