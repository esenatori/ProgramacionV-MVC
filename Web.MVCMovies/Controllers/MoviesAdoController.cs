using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using Web.MVCMovies.Models;

namespace Web.MVCMovies.Controllers
{
    public class MoviesAdoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var sqlconection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MoviesADO;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            sqlconection.Open();

            SqlCommand command = new SqlCommand("select * from Movies", sqlconection);
            List<Movie> movies = new List<Movie>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                movies.Add(new Movie { Genere = reader["Genere"].ToString(), Id = 1, Price = 1, Title = "Sueño de Libertad", ReleaseDate = DateTime.Parse("01/01/1994") });

            } 

            reader.Close();
            sqlconection.Close();   

            //movies.Add(new Movie { Genere = "Crimen Drama", Id = 2, Price = 1, Title = "El Padrino", ReleaseDate = DateTime.Parse("01/01/1972") });
            //movies.Add(new Movie { Genere = "Acción Crimen Drama Suspenso", Id = 3, Price = 1, Title = "Batman: El caballero de la noche ", ReleaseDate = DateTime.Parse("01/01/2008") });
            //movies.Add(new Movie { Genere = "Crimen Drama", Id = 4, Price = 1, Title = "El padrino II", ReleaseDate = DateTime.Parse("01/01/1974") });
            //movies.Add(new Movie { Genere = "Crimen Drama", Id = 5, Price = 1, Title = "12 hombres en pugna", ReleaseDate = DateTime.Parse("01/01/1957") });
            //movies.Add(new Movie { Genere = "Biografía Drama Historia", Id = 6, Price = 1, Title = "La lista de Schindler ", ReleaseDate = DateTime.Parse("01/01/1993") });
            //movies.Add(new Movie { Genere = "Acción Aventura Drama Fantasía", Id = 7, Price = 1, Title = "El señor de los anillos: El retorno del rey", ReleaseDate = DateTime.Parse("01/01/2003") });

            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = new Movie { Genere = "Drama", Id = 1, Price = 1, Title = "Sueño de Libertad", ReleaseDate = DateTime.Parse("01/01/1994") };

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            var sqlconection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MoviesADO;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            sqlconection.Open();

            var SQL = $"insert into Movies(Title, ReleaseDate, Genere, )";

           // SqlCommand command = new SqlCommand(, sqlconection);
              
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = new Movie { Genere = "Drama", Id = 1, Price = 1, Title = "Sueño de Libertad", ReleaseDate = DateTime.Parse("01/01/1994") };

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //Intentanmos Guardar

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Buscamos el objeto a borrar
            var movie = new Movie { Genere = "Drama", Id = 1, Price = 1, Title = "Sueño de Libertad", ReleaseDate = DateTime.Parse("01/01/1994") };

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Buscamos el objeto a borrar
            var movie = new Movie { Genere = "Drama", Id = 1, Price = 1, Title = "Sueño de Libertad", ReleaseDate = DateTime.Parse("01/01/1994") };

            if (movie != null)
            {
                //borramos
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
