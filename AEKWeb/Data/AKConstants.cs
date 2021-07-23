using System.Collections.Generic;

namespace AEKWeb.Data
{
    public class AkRoles
    {
        public const string Medlem = "Medlem";
        public const string Styrelse = "Styrelse";
        public static readonly IList<string> Roles = new List<string>()
        {
            Medlem,
            Styrelse
        };
    }
}
