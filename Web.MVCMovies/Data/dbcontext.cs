  
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Web.MVCMovies.Models;

namespace Web.MVCMovies.Data
{
    public class MoviesContext : DbContext
    {

        public MoviesContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MoviesEF;Integrated Security=True;Connect Timeout=60;")
        {
        }

        public DbSet<Movie> Movies { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}