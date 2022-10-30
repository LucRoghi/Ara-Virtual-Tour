using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AraVirtualTour
{
    public class AppContext : IdentityDbContext<AppUserModel>
    {
        protected readonly IConfiguration Configuration;

        public AppContext(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetConnectionString("AppDB");
            options.UseSqlite(connectionString);
        }

        public DbSet<AppUserModel>? AppUser { get; set; }
        public DbSet<StaffModel>? StaffModel { get; set; }
        public DbSet<VirtualTourModel>? VirtualTourModel { get; set; }

    }
}