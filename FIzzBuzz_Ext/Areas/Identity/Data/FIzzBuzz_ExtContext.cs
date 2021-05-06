using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIzzBuzz_Ext.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FIzzBuzz_Ext.Data
{
    public class FIzzBuzz_ExtContext : IdentityDbContext<FIzzBuzz_ExtUser>
    {
        public FIzzBuzz_ExtContext(DbContextOptions<FIzzBuzz_ExtContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
