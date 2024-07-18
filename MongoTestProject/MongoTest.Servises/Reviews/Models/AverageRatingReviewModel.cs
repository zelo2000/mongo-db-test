using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoTest.Data.Entities;

namespace MongoTest.Services.Reviews.Models
{
    public record AverageRatingReviewModel
    {
        public required string MovieTitle { get; set; }
        public required double AverageRating { get; set; }
    }

    public record ReviewToMovieModel : ReviewEntity
    {
        public MovieEntity Movie { get; set; }
    }
}
