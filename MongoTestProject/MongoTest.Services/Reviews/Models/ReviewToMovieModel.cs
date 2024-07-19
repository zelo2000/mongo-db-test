using MongoTest.Data.Entities;

namespace MongoTest.Services.Reviews.Models
{
    public record ReviewToMovieModel : ReviewEntity
    {
        public MovieEntity Movie { get; set; }
    }
}
