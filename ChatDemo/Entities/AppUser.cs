using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            SentFriendRequests = new List<FriendRequest>();
            ReceivedFriendRequests = new List<FriendRequest>();
        }

        public ICollection<FriendRequest> SentFriendRequests { get; set; }

        public ICollection<FriendRequest> ReceivedFriendRequests { get; set; }

        public ICollection<AppUser> Friends
        {
            get
            {
                var friends = ReceivedFriendRequests
                    .Where(x => x.IsAccepted)
                    .Select(x => x.Sender)
                    .ToList();

                friends.AddRange(SentFriendRequests
                    .Where(x => x.IsAccepted)
                    .Select(x => x.Receiver));

                return friends;
            }
        }

        public ICollection<Chat> Chats { get; set; }
    }
}
