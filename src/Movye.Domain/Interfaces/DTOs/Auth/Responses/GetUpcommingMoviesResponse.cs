using Movye.Domain.Entities;
using Movye.Domain.Interfaces.Services.IMovieDBService.Models;

namespace Movye.Domain.Interfaces.DTOs.Auth.Responses
{
    public class GetUpcommingMoviesResponse : IResponse
    {
        public GetUpcommingMoviesResponse(Movie[] movies)
        {
            Movies = movies;
        }

        public Movie[] Movies { get; set; }

        public static GetUpcommingMoviesResponse FromModel(GetUpcommingMoviesResponseModel model)
        {
            var movies = new List<Movie>();

            foreach (var movie in model.Results)
            {
                movies.Add(
                    new Movie(
                        Convert.ToInt32(movie.Id),
                        movie.Title,
                        $"https://image.tmdb.org/t/p/original{movie.PosterPath}",
                        $"https://image.tmdb.org/t/p/original{movie.BackdropPath}",
                        movie.Overview,
                        movie.VoteAverage,
                        movie.ReleaseDate!.Value.LocalDateTime
                    )
                );
            }

            return new GetUpcommingMoviesResponse(movies.ToArray());
        }
    }
}
