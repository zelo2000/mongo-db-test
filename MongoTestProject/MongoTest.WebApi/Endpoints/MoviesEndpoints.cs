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
                .WithTags(TagName)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get list of all movies by director name"
                });

            var getMoviesInGenreWithRatingHigherThan = async (string genre, double rating, IMovieService movieService) => await movieService.GetMoviesInGenreWithRatingHigherThan(genre, rating);
            movies.MapGet("genre/{genre}/rating/{rating}", getMoviesInGenreWithRatingHigherThan)
                .WithTags(TagName)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get list of all movies where genre is {genre} with rating larger than {rating}"
                });

            var getTopViewedMovies = (int count, IMovieService movieService) => movieService.GetTopViewedMovies(count);
            movies.MapGet("top/{count}", getTopViewedMovies)
                .WithTags(TagName)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get list of top {count} movies"
                });
        }
    }
}
