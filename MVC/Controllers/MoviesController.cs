using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _movieService.GetMovieDetailsAsync(id);
            if (movieDetails == null) return NotFound();
            return View(movieDetails);
        }
    }
}