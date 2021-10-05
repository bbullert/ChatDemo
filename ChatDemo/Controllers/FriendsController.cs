using ChatDemo.Infrastructure;
using ChatDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        private readonly IAppUserRepository userRepository;
        private readonly IChatRepository chatRepository;

        public FriendsController(
            IAppUserRepository userRepository,
            IChatRepository chatRepository)
        {
            this.userRepository = userRepository;
            this.chatRepository = chatRepository;
        }

        public IActionResult Index()
        {
            var signedInUser = userRepository.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(signedInUser.Friends);
        }

        public IActionResult Requests()
        {
            var signedInUser = userRepository.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(userRepository.GetUnacceptedReceivedFriendRequest(signedInUser));
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string value)
        {
            var result = new List<UserSearchResult>();

            if (value.Length > 1)
            {
                string signedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var signedInUser = userRepository.GetUserById(signedInUserId);
                var users = userRepository.FindUsersByUserName(value);
                users.Remove(users.Where(x => x.Id == signedInUser.Id).FirstOrDefault());

                foreach (var user in users)
                {
                    var status = FriendRequestStatus.None;

                    if (userRepository.AreFriends(signedInUser, user))
                    {
                        status = FriendRequestStatus.Accepted;
                    }
                    else if (userRepository.HaveSentFriendRequest(signedInUser, user))
                    {
                        status = FriendRequestStatus.Requested;
                    }
                    else if (userRepository.HaveReceivedFriendRequest(signedInUser, user))
                    {
                        status = FriendRequestStatus.Received;
                    }

                    result.Add(new UserSearchResult
                    {
                        User = user,
                        FriendRequestStatus = status
                    });
                }
            }

            return PartialView("_SearchUserResultsPartial", result);
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest(string userId)
        {
            string signedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var signedInUser = userRepository.GetUserById(signedInUserId);
            var user = userRepository.GetUserById(userId);

            await userRepository.SendFriendRequest(signedInUser, user);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AcceptFriendRequest(string userId)
        {
            string signedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var signedInUser = userRepository.GetUserById(signedInUserId);
            var user = userRepository.GetUserById(userId);

            await userRepository.AcceptFriendRequest(signedInUser, user);
            await chatRepository.CreatePrivateChat(signedInUser, user);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeclineFriendRequest(string userId)
        {
            string signedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var signedInUser = userRepository.GetUserById(signedInUserId);
            var user = userRepository.GetUserById(userId);

            await userRepository.DeclineFriendRequest(signedInUser, user);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFriend(string userId)
        {
            string signedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var signedInUser = userRepository.GetUserById(signedInUserId);
            var user = userRepository.GetUserById(userId);

            await chatRepository.RemovePrivateChat(signedInUser, user);
            await userRepository.RemoveFriend(signedInUser, user);

            return Ok();
        }
    }
}
