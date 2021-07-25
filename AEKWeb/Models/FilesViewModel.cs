using System.Collections.Generic;

namespace AEKWeb.Models
{
    public record FilesViewModel(bool IsLoggedIn, IEnumerable<string> Files);
}
