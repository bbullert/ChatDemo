using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ChatDemo.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }

        public AppUser Author { get; set; }

        public string AuthorId { get; set; }

        public int ChatId { get; set; }

        public string GetFormattedTimeStamp()
        {
            string format = "ddd d MMM yyy, HH:mm";
            var textInfo = new CultureInfo("en-US").TextInfo;
            var now = textInfo.ToTitleCase(TimeStamp.ToString(format));

            return now;
        }
    }
}
