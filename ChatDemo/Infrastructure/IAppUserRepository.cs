using ChatDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Infrastructure
{
    public interface IAppUserRepository
    {
        public AppUser GetUserById(string userId);

        public ICollection<AppUser> FindUsersByUserName(string userName, int startIndex = 0, int count = 10);

        public bool AreFriends(AppUser user, AppUser friend);

        public bool HaveSentFriendRequest(AppUser sender, AppUser receiver);

        public bool HaveReceivedFriendRequest(AppUser receiver, AppUser sender);

        public ICollection<FriendRequest> GetUnacceptedSentFriendRequest(AppUser sender);

        public ICollection<FriendRequest> GetUnacceptedReceivedFriendRequest(AppUser receiver);

        public Task SendFriendRequest(AppUser sender, AppUser receiver);

        public Task AcceptFriendRequest(AppUser receiver, AppUser sender);

        public Task DeclineFriendRequest(AppUser receiver, AppUser sender);

        public Task RemoveFriend(AppUser user, AppUser friend);
    }
}
