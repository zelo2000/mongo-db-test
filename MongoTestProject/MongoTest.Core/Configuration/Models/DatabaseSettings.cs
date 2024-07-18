namespace MongoTest.Core.Configuration.Models
{
    public record DatabaseSettings
    {
        public required string MoviesDatabase { get; set; }
    }
}
