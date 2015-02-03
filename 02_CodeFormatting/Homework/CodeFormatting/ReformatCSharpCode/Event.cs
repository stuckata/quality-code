using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReformatCSharpCode
{
    class Event : IComparable
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public int CompareTo(object otherObject)
        {
            Event otherEvent = otherObject as Event;

            int byDate = this.Date.CompareTo(otherEvent.Date);
            int byTitle = this.Title.CompareTo(otherEvent.Title);
            int byLocation = this.Location.CompareTo(otherEvent.Location);

            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }

            return byDate;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(Date.ToString("yyyy-MM-ddTHH:mm:ss" + " | " + Title));

            if (Location != null && Location != "")
            {
                result.Append(" | " + Location);
            }

            return result.ToString();
        }

    }
}
