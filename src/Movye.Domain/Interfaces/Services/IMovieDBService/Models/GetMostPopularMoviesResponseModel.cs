using Newtonsoft.Json;

namespace Movye.Domain.Interfaces.Services.IMovieDBService.Models
{
    public partial class GetMostPopularMoviesResponseModel
    {
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public long? Page { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public Result[] Results { get; set; } = null!;

        [JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalPages { get; set; }

        [JsonProperty("total_results", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalResults { get; set; }
    }

    public partial class GetMostPopularMoviesResponseModel
    {
        public static GetMostPopularMoviesResponseModel? FromJson(string json) =>
            JsonConvert.DeserializeObject<GetMostPopularMoviesResponseModel>(
                json,
                Converter.Settings
            );
    }
}
