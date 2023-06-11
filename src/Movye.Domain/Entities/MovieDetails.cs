namespace Movye.Domain.Entities
{
    public class MovieDetails
    {
        public MovieDetails(Genre[] genres, long? runtime)
        {
            Runtime = runtime;
            Genres = genres;
        }

        public Genre[] Genres { get; set; }
        public long? Runtime { get; set; }
    }

    public class Genre
    {
        public Genre(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
