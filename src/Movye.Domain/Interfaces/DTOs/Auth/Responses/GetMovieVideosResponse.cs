using Movye.Domain.Entities;
using Movye.Domain.Interfaces.Services.IMovieDBService.Models;

namespace Movye.Domain.Interfaces.DTOs.Auth.Responses
{
    public class GetMovieVideosResponse
    {
        public GetMovieVideosResponse(MovieVideos[] movieVideos)
        {
            MovieVideos = movieVideos;
        }

        public MovieVideos[] MovieVideos { get; set; }

        public static GetMovieVideosResponse FromModel(GetMovieVideosResponseModel model)
        {
            var movieVideos = new List<MovieVideos>();

            foreach (var video in model.Results)
            {
                movieVideos.Add(
                    new MovieVideos(video.Key, (long)Convert.ToDouble(video.Size), video.Name)
                );
            }

            return new GetMovieVideosResponse(movieVideos.ToArray());
        }
    }
}
