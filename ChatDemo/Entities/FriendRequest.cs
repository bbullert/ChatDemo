using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Entities
{
    public class FriendRequest
    {
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public AppUser Sender { get; set; }

        public AppUser Receiver { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime Since { get; set; }
    }
}
