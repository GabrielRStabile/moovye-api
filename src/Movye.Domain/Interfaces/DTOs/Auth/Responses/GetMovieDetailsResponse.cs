using Movye.Domain.Entities;
using Movye.Domain.Interfaces.Services.IMovieDBService.Models;

namespace Movye.Domain.Interfaces.DTOs.Auth.Responses
{
    public class GetMovieDetailsResponse
    {
        public GetMovieDetailsResponse(MovieDetails movieDetails)
        {
            MovieDetails = movieDetails;
        }

        public MovieDetails MovieDetails { get; set; }

        public static GetMovieDetailsResponse FromModel(GetMovieDetailsResponseModel model)
        {
            var movieDetails = new MovieDetails(
                model.Genres.Select(g => new Entities.Genre(g.Name)).ToArray(),
                model.Runtime
            );

            return new GetMovieDetailsResponse(movieDetails);
        }
    }
}
