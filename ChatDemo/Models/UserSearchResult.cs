using ChatDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Models
{
    public class UserSearchResult
    {
        public AppUser User { get; set; }

        public FriendRequestStatus FriendRequestStatus { get; set; }
    }
}
