using MongoTest.Services.Movies;

namespace MongoTest.WebApi.Endpoints
{
    public static class MoviesEndpoints
    {
        public const string TagName = "Movies";
        public static void RegisterMoviesEndpoints(this IEndpointRouteBuilder routes)
        {
            var movies = routes.MapGroup("/api/v1/movies");

            var getMoviesByDirector = async (string director, IMovieService movieService) => await movieService.GetMoviesByDirector(director);
            movies.MapGet("director/{director}", getMoviesByDirector)
                .WithTags(TagName);

            var getMoviesInGenreWithRatingHigherThan = async (string genre, double rating, IMovieService movieService) => await movieService.GetMoviesInGenreWithRatingHigherThan(genre, rating);
            movies.MapGet("genre/{genre}/rating/{rating}", getMoviesInGenreWithRatingHigherThan)
                .WithTags(TagName);
        }
    }
}
