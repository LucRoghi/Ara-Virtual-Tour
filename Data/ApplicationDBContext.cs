namespace AraVirtualTour.Data 
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<useraccounts> useraccounts {get; set;}
    }
}