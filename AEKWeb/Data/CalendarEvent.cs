using System;

namespace AEKWeb.Data
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
    }
}
