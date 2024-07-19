using MongoTest.Services.WatchLists;

namespace MongoTest.WebApi.Endpoints
{
    public static class WatchListEndpoints
    {
        public const string TagName = "Watch list";
        public static void RegisterWatchListEndpoints(this IEndpointRouteBuilder routes)
        {
            var reviews = routes.MapGroup("/api/v1/watch-list");

            var getAverageRatingForAllMovies = async (string userId, IWatchListsService service) => await service.GetUserMovies(userId);
            reviews.MapGet("{userId}/movies/all", getAverageRatingForAllMovies)
                .WithTags(TagName)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all movies watched by user with id {userId}"
                });

            var getUserTotalNumberOfMovies = async (string userId, IWatchListsService service) => await service.GetUserTotalNumberOfMovies(userId);
            reviews.MapGet("{userId}/movies/count", getUserTotalNumberOfMovies)
                .WithTags(TagName)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get amount of movies watched by user with id {userId}"
                });
        }
    }
}
