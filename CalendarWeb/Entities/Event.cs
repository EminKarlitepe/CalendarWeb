using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarWeb.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}