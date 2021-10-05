using ChatDemo.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> logger;
        private readonly IChatRepository chatRepository;

        public ChatController(
            ILogger<ChatController> logger,
            IChatRepository chatRepository)
        {
            this.logger = logger;
            this.chatRepository = chatRepository;
        }

        public IActionResult Index()
        {
            string signInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var chats = chatRepository.GetUserChats(signInUserId);

            foreach (var chat in chats)
            {
                chat.Name = chat.Users.FirstOrDefault(x => x.Id != signInUserId).UserName;
            }

            return View(chats);
        }

        public IActionResult Direct(int id)
        {
            var chat = chatRepository.GetChatById(id);
            var messages = chatRepository.GetMessagesByChatId(id, 0, 10).ToList();
            messages.Reverse();
            chat.Messages = messages;

            return View(chat);
        }

        [HttpPost]
        public IActionResult GetMessages(int chatId, int startIndex, int length)
        {
            var messages = chatRepository.GetMessagesByChatId(chatId, startIndex, length).ToList();

            return PartialView("_ChatMessagesPartial", messages);
        }
    }
}
