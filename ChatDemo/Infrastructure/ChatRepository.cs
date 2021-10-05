using ChatDemo.Entities;
using ChatDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatDemo.Infrastructure
{
    public interface IChatRepository
    {
        public Chat GetChatById(int id);

        public Chat GetChatByUsers(AppUser user1, AppUser user2);

        public IEnumerable<Chat> GetUserChats(string userId);

        public ICollection<Message> GetMessagesByChatId(int chatId, int startIndex = 0, int count = 10);

        public Task CreatePrivateChat(AppUser user1, AppUser user2);

        public Task RemovePrivateChat(int chatId);

        public Task RemovePrivateChat(AppUser user1, AppUser user2);

        public Task<Message> CreateMessage(Message message);
    }

    public class ChatRepository : IChatRepository
    {
        private readonly AppDbContext context;

        public ChatRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Chat GetChatById(int id)
        {
            return context.Chats
                .Include(x => x.Users)
                .FirstOrDefault(x => x.Id == id);
        }

        public Chat GetChatByUsers(AppUser user1, AppUser user2)
        {
            return context.Chats
                .Include(x => x.Users)
                .FirstOrDefault(x => x.Users.Contains(user1) && x.Users.Contains(user2));
        }

        public IEnumerable<Chat> GetUserChats(string userId)
        {
            return context.Chats
                .Include(x => x.Users)
                .Where(x => x.Users.Any(y => y.Id == userId))
                .ToList();
        }

        public ICollection<Message> GetMessagesByChatId(int chatId, int startIndex = 0, int count = 10)
        {
            return context.Messages
                .Include(x => x.Author)
                .Where(x => x.ChatId == chatId)
                .OrderByDescending(x => x.TimeStamp)
                .Skip(startIndex)
                .Take(count)
                .ToList();
        }

        public async Task CreatePrivateChat(AppUser user1, AppUser user2)
        {
            var chat = new Chat();
            chat.Users.Add(user1);
            chat.Users.Add(user2);

            context.Chats.Add(chat);
            await context.SaveChangesAsync();
        }

        public async Task RemovePrivateChat(int chatId)
        {
            var chat = context.Chats.FirstOrDefault(x => x.Id == chatId);

            context.Chats.Remove(chat);
            await context.SaveChangesAsync();
        }

        public async Task RemovePrivateChat(AppUser user1, AppUser user2)
        {
            var chat = user1.Chats.FirstOrDefault(x => x.Users.Any(x => x.Id == user2.Id));
            
            if (chat == null)
            {
                return;
            }

            context.Chats.Remove(chat);
            await context.SaveChangesAsync();
        }

        public async Task<Message> CreateMessage(Message message)
        {
            context.Messages.Add(message);
            await context.SaveChangesAsync();

            return message;
        }
    }
}
