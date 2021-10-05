using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDemo.Models
{
    public class UserSearchViewModel
    {
        public UserSearchViewModel()
        {
            Results = new List<UserSearchResult>();
        }

        public string Value { get; set; }

        public ICollection<UserSearchResult> Results { get; set; }
    }
}
