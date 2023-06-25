using Microsoft.Extensions.Options;
using Movye.Api.Utils;
using Movye.Domain.Interfaces.Services.IMovieDBService;
using Movye.Domain.Interfaces.Services.IMovieDBService.Models;

namespace Movye.Application.Services
{
    public class MovieDBService : IMovieDBService
    {
        private readonly AppEnvironments env;

        public MovieDBService(IOptions<AppEnvironments> env)
        {
            this.env = env.Value;
        }

        public async Task<GetUpcommingMoviesResponseModel?> GetUpcommingMovies()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                $"{env.THEMOVIEDB_API_URL}/movie/upcoming?api_key={env.THEMOVIEDB_API_KEY}&language=pt-BR"
            );

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return GetUpcommingMoviesResponseModel.FromJson(content);
            }

            return null;
        }

        public async Task<GetMostPopularMoviesResponseModel?> GetMostPopularMovies()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                $"{env.THEMOVIEDB_API_URL}/movie/top_rated?api_key={env.THEMOVIEDB_API_KEY}&language=pt-BR"
            );

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return GetMostPopularMoviesResponseModel.FromJson(content);
            }

            return null;
        }

        public async Task<GetMovieDetailsResponseModel?> GetMovieDetails(int movieId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                $"{env.THEMOVIEDB_API_URL}/movie/{movieId}?api_key={env.THEMOVIEDB_API_KEY}&language=pt-BR"
            );

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return GetMovieDetailsResponseModel.FromJson(content);
            }

            return null;
        }

        public async Task<GetMovieVideosResponseModel?> GetMovieVideos(int movieId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                $"{env.THEMOVIEDB_API_URL}/movie/{movieId}/videos?api_key={env.THEMOVIEDB_API_KEY}&language=pt-BR"
            );

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return GetMovieVideosResponseModel.FromJson(content);
            }

            return null;
        }

        public async Task<GetMoviesByKeywordResponse?> GetMovieByKeyword(string keyword)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                $"{env.THEMOVIEDB_API_URL}/search/movie?api_key={env.THEMOVIEDB_API_KEY}&language=pt-BR&query={keyword}"
            );

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return GetMoviesByKeywordResponse.FromJson(content);
            }

            return null;
        }
    }
}
