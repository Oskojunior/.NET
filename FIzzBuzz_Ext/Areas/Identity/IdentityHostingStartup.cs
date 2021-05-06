using System;
using FIzzBuzz_Ext.Areas.Identity.Data;
using FIzzBuzz_Ext.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FIzzBuzz_Ext.Areas.Identity.IdentityHostingStartup))]
namespace FIzzBuzz_Ext.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FIzzBuzz_ExtContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FIzzBuzz_ExtContextConnection")));

                services.AddDefaultIdentity<FIzzBuzz_ExtUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<FIzzBuzz_ExtContext>();
            });
        }
    }
}