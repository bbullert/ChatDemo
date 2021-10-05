using ChatDemo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ChatDemo.ViewComponents
{
    public class ChatListViewComponent : ViewComponent
    {
        private readonly IChatRepository chatRepository;

        public ChatListViewComponent(
            IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string signInUserId = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var chats = chatRepository.GetUserChats(signInUserId);
            foreach (var chat in chats)
            {
                chat.Name = chat.Users.FirstOrDefault(x => x.Id != signInUserId).UserName;
            }

            return View(chats);
        }
    }
}
