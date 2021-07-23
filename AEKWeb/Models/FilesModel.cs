using System.Collections.Generic;

namespace AEKWeb.Models
{
    public record FilesModel(bool IsLoggedIn, IEnumerable<string> Files);
}
