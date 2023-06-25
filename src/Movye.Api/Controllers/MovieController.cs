using Microsoft.AspNetCore.Mvc;
using Movye.Api.Controllers.Shared;
using Movye.Domain.Interfaces.DTOs.Auth.Responses;
using Movye.Domain.Interfaces.Services.IMovieDBService;

namespace Movye.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class MovieController : ApiControllerBase
    {
        private readonly IMovieDBService _movieDBService;

        [ActivatorUtilitiesConstructor]
        public MovieController(IMovieDBService movieDBService)
        {
            _movieDBService = movieDBService;
        }

        [HttpGet("upcomming")]
        public async Task<ActionResult<GetUpcommingMoviesResponse>> GetUpcommingMovies()
        {
            var response = await _movieDBService.GetUpcommingMovies();

            if (response is null)
                return NotFound();

            var movies = GetUpcommingMoviesResponse.FromModel(response);

            return Ok(movies);
        }

        [HttpGet("popular")]
        public async Task<ActionResult<GetMostPopularMoviesResponse>> GetMostPopularMovies()
        {
            var response = await _movieDBService.GetMostPopularMovies();

            if (response is null)
                return NotFound();

            var movies = GetMostPopularMoviesResponse.FromModel(response);

            return Ok(movies);
        }

        [HttpGet("{movieId}/videos")]
        public async Task<ActionResult<GetMovieVideosResponse>> GetMovieVideos(int movieId)
        {
            var response = await _movieDBService.GetMovieVideos(movieId);

            if (response is null)
                return NotFound();

            var videos = GetMovieVideosResponse.FromModel(response);

            return Ok(videos);
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<GetMovieDetailsResponse>> GetMovieDetails(int movieId)
        {
            var response = await _movieDBService.GetMovieDetails(movieId);

            if (response is null)
                return NotFound();

            var movie = GetMovieDetailsResponse.FromModel(response);

            return Ok(movie);
        }

        [HttpGet("search")]
        public async Task<ActionResult<SearchMovieByQueryResponse>> SearchMovies(
            [FromQuery] string query
        )
        {
            var response = await _movieDBService.GetMovieByKeyword(query);

            if (response is null)
                return NotFound();

            var movies = SearchMovieByQueryResponse.FromModel(response);

            return Ok(movies);
        }
    }
}
