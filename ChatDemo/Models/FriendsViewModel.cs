using ChatDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Models
{
    public class FriendsViewModel
    {
        public FriendsViewModel()
        {
            Friends = new List<AppUser>();
        }

        public ICollection<AppUser> Friends { get; set; }
    }
}
