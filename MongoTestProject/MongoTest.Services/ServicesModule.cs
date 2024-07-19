using Microsoft.Extensions.DependencyInjection;
using MongoTest.Data.Repositories;
using MongoTest.Services.Movies;
using MongoTest.Services.Reviews;
using MongoTest.Services.WatchLists;

namespace MongoTest.Services
{
    public static class ServicesModule
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository, BaseRepository>();

            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IReviewsService, ReviewsService>();
            services.AddTransient<IWatchListsService, WatchListsService>();

            return services;
        }
    }
}
