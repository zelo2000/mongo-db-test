namespace MongoTest.Services.WatchLists.Model
{
    public record UserWatchList
    {
        public required string UserName { get; set; }
        public List<string> Movies { get; set; } = [];
    }
}
