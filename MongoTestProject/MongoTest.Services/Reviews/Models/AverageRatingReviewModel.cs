namespace MongoTest.Services.Reviews.Models
{
    public record AverageRatingReviewModel
    {
        public required string MovieTitle { get; set; }
        public required double AverageRating { get; set; }
    }
}
