// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Movye.Domain.Interfaces.Services.IMovieDBService.Models;
//
//    var getMovieDetailsResponseModel = GetMovieDetailsResponseModel.FromJson(jsonString);

namespace Movye.Domain.Interfaces.Services.IMovieDBService.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class GetMovieDetailsResponseModel
    {
        [JsonProperty("adult", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Adult { get; set; }

        [JsonProperty("backdrop_path", NullValueHandling = NullValueHandling.Ignore)]
        public string BackdropPath { get; set; }

        [JsonProperty("belongs_to_collection", NullValueHandling = NullValueHandling.Ignore)]
        public BelongsToCollection BelongsToCollection { get; set; }

        [JsonProperty("budget", NullValueHandling = NullValueHandling.Ignore)]
        public long? Budget { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public Genre[] Genres { get; set; }

        [JsonProperty("homepage", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Homepage { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("imdb_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ImdbId { get; set; }

        [JsonProperty("original_language", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Popularity { get; set; }

        [JsonProperty("poster_path", NullValueHandling = NullValueHandling.Ignore)]
        public string PosterPath { get; set; }

        [JsonProperty("production_companies", NullValueHandling = NullValueHandling.Ignore)]
        public ProductionCompany[] ProductionCompanies { get; set; }

        [JsonProperty("production_countries", NullValueHandling = NullValueHandling.Ignore)]
        public ProductionCountry[] ProductionCountries { get; set; }

        [JsonProperty("release_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ReleaseDate { get; set; }

        [JsonProperty("revenue", NullValueHandling = NullValueHandling.Ignore)]
        public long? Revenue { get; set; }

        [JsonProperty("runtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Runtime { get; set; }

        [JsonProperty("spoken_languages", NullValueHandling = NullValueHandling.Ignore)]
        public SpokenLanguage[] SpokenLanguages { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("tagline", NullValueHandling = NullValueHandling.Ignore)]
        public string Tagline { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Video { get; set; }

        [JsonProperty("vote_average", NullValueHandling = NullValueHandling.Ignore)]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? VoteCount { get; set; }
    }

    public partial class BelongsToCollection
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("poster_path", NullValueHandling = NullValueHandling.Ignore)]
        public string PosterPath { get; set; }

        [JsonProperty("backdrop_path", NullValueHandling = NullValueHandling.Ignore)]
        public string BackdropPath { get; set; }
    }

    public partial class Genre
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class ProductionCompany
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("origin_country", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginCountry { get; set; }
    }

    public partial class ProductionCountry
    {
        [JsonProperty("iso_3166_1", NullValueHandling = NullValueHandling.Ignore)]
        public string Iso3166_1 { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class SpokenLanguage
    {
        [JsonProperty("english_name", NullValueHandling = NullValueHandling.Ignore)]
        public string EnglishName { get; set; }

        [JsonProperty("iso_639_1", NullValueHandling = NullValueHandling.Ignore)]
        public string Iso639_1 { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class GetMovieDetailsResponseModel
    {
        public static GetMovieDetailsResponseModel FromJson(string json) => JsonConvert.DeserializeObject<GetMovieDetailsResponseModel>(json, Converter.Settings);
    }
}
