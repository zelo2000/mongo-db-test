using MongoTest.Services.Reviews;

namespace MongoTest.WebApi.Endpoints
{
    public static class ReviewEndpoints
    {
        public const string TagName = "Reviews";
        public static void RegisterReviewEndpoints(this IEndpointRouteBuilder routes)
        {
            var reviews = routes.MapGroup("/api/v1/reviews");

            var getAverageRatingForAllMovies = async (IReviewsService reviewsService) => await reviewsService.GetAverageRatingForAllMovies();
            reviews.MapGet("rating/average", getAverageRatingForAllMovies)
                .WithTags(TagName)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get average rating of all movies based on reviews"
                });
        }
    }
}