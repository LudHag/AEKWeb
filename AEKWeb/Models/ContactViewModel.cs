using AEKWeb.Data;
using System.Collections.Generic;

namespace AEKWeb.Models
{
    public record ContactViewModel(IEnumerable<SignUp> signups);
}
