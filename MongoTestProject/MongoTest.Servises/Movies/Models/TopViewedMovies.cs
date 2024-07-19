namespace MongoTest.Services.Reviews.Models
{
    public class TopViewedMovies
    {
        public required string MovieTitle { get; set; }
        public required double Count { get; set; }
    }
}
