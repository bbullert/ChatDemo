using ChatDemo.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatDemo.Infrastructure
{
    public class ChatHub : Hub
    {
        private readonly IChatRepository chatRepository;
        
        public ChatHub(IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        public async Task GroupPing(string chatId, string status)
        {
            await Clients.OthersInGroup(chatId).SendAsync("GroupPing", chatId, status);
        }

        public async Task GroupPingCallback(string chatId, string status)
        {
            await Clients.OthersInGroup(chatId).SendAsync("GroupPingCallback", chatId, status);
        }

        public override async Task OnConnectedAsync()
        {
            string signInUserId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var chats = chatRepository.GetUserChats(signInUserId);

            foreach (var chat in chats)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chat.Id.ToString());
                await GroupPing(chat.Id.ToString(), "1");
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string signInUserId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var chats = chatRepository.GetUserChats(signInUserId);

            foreach (var chat in chats)
            {
                await GroupPing(chat.Id.ToString(), "0");
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, chat.Id.ToString());
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string chatId, string text)
        {
            string authorName = Context.User.FindFirstValue(ClaimTypes.Name);
            string authorId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var message = new Message
            {
                Text = text,
                AuthorId = authorId,
                ChatId = int.Parse(chatId),
                TimeStamp = DateTime.Now
            };
            message = await chatRepository.CreateMessage(message);

            await Clients.Group(chatId).SendAsync("ReceiveMessage",
                new
                {
                    Text = message.Text,
                    AuthorName = authorName,
                    TimeStamp = message.GetFormattedTimeStamp(),
                    ChatId = message.ChatId
                });
        }
    }
}
