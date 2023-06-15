  
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Drawing;
using Web.MVCMovies.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Web.MVCMovies.Data
{
    public class MoviesContext : DbContext
    {
          
        public MoviesContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MoviesEF;Integrated Security=True;Connect Timeout=60;")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        //TODO Revisar por que
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}