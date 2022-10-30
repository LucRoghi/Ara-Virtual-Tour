using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AraVirtualTour
{
    public class AppContext : DbContext 
    {
        public DbSet<UserModel> Users {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"Data Source=aravirtualtour.db");
    }
}
