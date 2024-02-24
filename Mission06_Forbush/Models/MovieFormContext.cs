using Microsoft.EntityFrameworkCore;
// MovieFormContext class is defined, it inherits from DbContext, configuring it to manage database operations for the Application model.
namespace Mission06_Forbush.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {

        }
        // Create a public database set of type Movie and Categories
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
