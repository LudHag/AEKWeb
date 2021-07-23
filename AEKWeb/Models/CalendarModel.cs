using AEKWeb.Data;
using System.Collections.Generic;

namespace AEKWeb.Models
{
    public record CalendarModel(IEnumerable<CalendarEvent> Events);
}
