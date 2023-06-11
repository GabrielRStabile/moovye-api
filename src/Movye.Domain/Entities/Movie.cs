namespace Movye.Domain.Entities
{
    public class Movie : Content
    {
        public Movie() { }

        public Movie(
            int id,
            string title,
            string posterImage,
            string coverImage,
            string description,
            double? voteAverage,
            DateTime? releaseDate
        )
        {
            Id = id;
            Title = title;
            PosterImage = posterImage;
            CoverImage = coverImage;
            Description = description;
            VoteAverage = voteAverage;
            ReleaseDate = releaseDate;
        }

        public string Title { get; set; }
        public string PosterImage { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
        public double? VoteAverage { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
