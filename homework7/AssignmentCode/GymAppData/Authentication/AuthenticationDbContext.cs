using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppData.Authentication
{
    public class AuthenticationDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthenticationDbContext(DbContextOptions options)
              : base(options)
        {
        }

    }
}
