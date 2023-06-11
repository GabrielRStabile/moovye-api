using Movye.Domain.Interfaces.Services.IMovieDBService.Models;

namespace Movye.Domain.Interfaces.Services.IMovieDBService
{
    public interface IMovieDBService
    {
        Task<GetUpcommingMoviesResponseModel?> GetUpcommingMovies();
        Task<GetMostPopularMoviesResponseModel?> GetMostPopularMovies();
        Task<GetMovieDetailsResponseModel?> GetMovieDetails(int movieId);
        Task<GetMovieVideosResponseModel?> GetMovieVideos(int movieId);
    }
}
