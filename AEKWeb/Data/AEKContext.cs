using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AEKWeb.Data
{
    public class AEKContext : IdentityDbContext
    {
        public AEKContext(DbContextOptions<AEKContext> options)
            : base(options)
        {
        }

        public DbSet<CalendarEvent> Events { get; set; }

        public DbSet<SignUp> SignUps { get; set; }

    }
}
