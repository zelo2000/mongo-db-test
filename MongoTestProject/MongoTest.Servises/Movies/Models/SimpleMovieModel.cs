namespace MongoTest.Services.Movies.Models
{
    public record SimpleMovieModel
    {
        public required string Id { get; set; }

        public required string Title { get; set; }

        public required string Director { get; set; }

        public List<string> Genres { get; set; } = [];

        public DateTime ReleaseDate { get; set; }

        public double Rating { get; set; }

        public int Views { get; set; }
    }
}
