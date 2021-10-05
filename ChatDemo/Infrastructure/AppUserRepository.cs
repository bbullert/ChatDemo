using ChatDemo.Entities;
using ChatDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Infrastructure
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext context;

        public AppUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public AppUser GetUserById(string userId)
        {
            return context.Users
                .Include(x => x.Chats)
                .Include(x => x.SentFriendRequests)
                .ThenInclude(x => x.Receiver)
                .Include(x => x.ReceivedFriendRequests)
                .ThenInclude(x => x.Sender)
                .FirstOrDefault(x => x.Id == userId);
        }

        public ICollection<AppUser> FindUsersByUserName(string userName, int startIndex = 0, int count = 20)
        {
            return context.Users
                .Include(x => x.SentFriendRequests)
                .ThenInclude(x => x.Receiver)
                .Include(x => x.ReceivedFriendRequests)
                .ThenInclude(x => x.Sender)
                .Where(x => x.UserName.ToLower().StartsWith(userName.ToLower()))
                .Skip(startIndex)
                .Take(count)
                .ToList();
        }

        public bool AreFriends(AppUser user, AppUser friend)
        {
            return user.Friends
                .FirstOrDefault(x => x.Id == friend.Id) != null;
        }

        public bool HaveSentFriendRequest(AppUser sender, AppUser receiver)
        {
            return sender.SentFriendRequests
                .FirstOrDefault(x => x.Sender.Id == sender.Id && x.Receiver.Id == receiver.Id) != null;
        }

        public bool HaveReceivedFriendRequest(AppUser receiver, AppUser sender)
        {
            return receiver.ReceivedFriendRequests
                .FirstOrDefault(x => x.Sender.Id == sender.Id && x.Receiver.Id == receiver.Id) != null;
        }

        public ICollection<FriendRequest> GetUnacceptedSentFriendRequest(AppUser sender)
        {
            return sender.SentFriendRequests
                .Where(x => x.IsAccepted == false)
                .ToList();
        }

        public ICollection<FriendRequest> GetUnacceptedReceivedFriendRequest(AppUser receiver)
        {
            return receiver.ReceivedFriendRequests
                .Where(x => x.IsAccepted == false)
                .ToList();
        }

        public async Task SendFriendRequest(AppUser sender, AppUser receiver)
        {
            if (sender.Id == receiver.Id)
            {
                return;
            }

            var request = new FriendRequest
            {
                Sender = sender,
                Receiver = receiver
            };

            context.FriendRequests.Add(request);

            await context.SaveChangesAsync();
        }

        public async Task AcceptFriendRequest(AppUser receiver, AppUser sender)
        {
            if (sender.Id == receiver.Id)
            {
                return;
            }

            var request = receiver.ReceivedFriendRequests
                .FirstOrDefault(x => !x.IsAccepted && x.Sender.Id == sender.Id);

            if (request == null)
            {
                return;
            }

            request.IsAccepted = true;
            request.Since = DateTime.Now;

            await context.SaveChangesAsync();
        }

        public async Task DeclineFriendRequest(AppUser receiver, AppUser sender)
        {
            if (sender.Id == receiver.Id)
            {
                return;
            }

            var request = receiver.ReceivedFriendRequests
                .FirstOrDefault(x => !x.IsAccepted && x.Sender.Id == sender.Id);

            if (request == null)
            {
                return;
            }

            context.FriendRequests.Remove(request);
            await context.SaveChangesAsync();
        }

        public async Task RemoveFriend(AppUser user, AppUser friend)
        {
            if (user.Id == friend.Id)
            {
                return;
            }

            var request = user.SentFriendRequests
                .FirstOrDefault(x => x.IsAccepted && x.Receiver.Id == friend.Id);

            if (request == null)
            {
                request = user.ReceivedFriendRequests
                    .FirstOrDefault(x => x.IsAccepted && x.Sender.Id == friend.Id);
            }

            if (request == null)
            {
                return;
            }

            context.FriendRequests.Remove(request);
            await context.SaveChangesAsync();
        }
    }
}
