namespace MongoTest.Services.WatchLists.Model
{
    public record UserTotalMovies
    {
        public required string UserName { get; set; }
        public required int MoviesCount { get; set; }
    }
}
