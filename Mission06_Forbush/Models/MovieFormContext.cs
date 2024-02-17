using Microsoft.EntityFrameworkCore;
// MovieFormContext class is defined, it inherits from DbContext, configuring it to manage database operations for the Application model.
namespace Mission06_Forbush.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options) 
        {
        }

        public DbSet<Application> Applications { get; set; }
    }
}
