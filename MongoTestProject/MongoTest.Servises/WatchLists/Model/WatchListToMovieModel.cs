using MongoTest.Data.Entities;

namespace MongoTest.Services.Reviews.Models
{
    public record WatchListToMovieModel : WatchListsEntity
    {
        public List<MovieEntity> MovieEntities { get; set; }
    }

    public record WatchListToUserModel : WatchListsEntity
    {
        public UserEntity UserEntity { get; set; }
    }

    public record WatchListToMovieToUserModel : WatchListToMovieModel
    {
        public UserEntity UserEntity { get; set; }
    }
}
