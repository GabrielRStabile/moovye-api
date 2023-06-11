namespace Movye.Domain.Entities
{
    public class MovieVideos
    {
        public MovieVideos(string key, long? size, string name)
        {
            Key = key;
            Size = size;
            Name = name;
        }

        public string Key { get; set; }
        public long? Size { get; set; }
        public string Name { get; set; }
    }
}
