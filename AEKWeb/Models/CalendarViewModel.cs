using AEKWeb.Data;
using System.Collections.Generic;

namespace AEKWeb.Models
{
    public record CalendarViewModel(IEnumerable<CalendarEvent> Events);
}
