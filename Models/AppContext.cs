using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AraVirtualTour
{
    public class AppContext : DbContext 
    {
        protected readonly IConfiguration Configuration;

        public AppContext(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("AppDB"));
        }

        public DbSet<UserModel> Users {get; set;}

    }
}
