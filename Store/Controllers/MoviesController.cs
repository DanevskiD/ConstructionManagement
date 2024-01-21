using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interface;
using Store.Domain.Requests.Movie;
using Store.Domain.Responses.Movie;

namespace Store.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetMoviesResponse>>> GetMoviesAsync()
        {
            List<GetMoviesResponse> movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovieAsync([FromBody] CreateMovieRequest request)
        {
            await _movieService.CreateMovieAsync(request);
            return Ok();
        }
    }
}
