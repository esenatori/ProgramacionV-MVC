using Microsoft.AspNetCore.Mvc; 
using System;
using System.Diagnostics;
using System.Drawing;
using Web.MVCMovies.Data;
using Web.MVCMovies.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Web.MVCMovies.Controllers
{
    public class MoviesEFController : Controller
    {
        MoviesContext _moviesContext;

        public MoviesEFController()
        { 
              _moviesContext = new MoviesContext();

        }
        public async Task<IActionResult> Index()
        {
           
            return View(_moviesContext.Movies.ToList());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = new Movie { Genere = "Drama", Id = 1, Price = 1, Title = "Sueño de Libertad", ReleaseDate = DateTime.Parse("01/01/1994")};

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
            var NewMovie = new Movie { Genere = movie.Genere, Id = movie.Id, Price = movie.Price, Title = movie.Title, ReleaseDate= movie.ReleaseDate };

            return View(NewMovie);
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
