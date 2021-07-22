using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AEKWeb.Data
{
    public class AEKContext : IdentityDbContext
    {
        public AEKContext(DbContextOptions<AEKContext> options)
            : base(options)
        {
        }
    }
}
