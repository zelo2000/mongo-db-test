using MongoDB.Driver;
using MongoTest.Data.Entities;
using MongoTest.Data.Repositories;
using MongoTest.Services.Reviews.Models;
using MongoTest.Services.WatchLists.Model;

namespace MongoTest.Services.WatchLists
{
    public interface IWatchListsService
    {
        Task<UserWatchList> GetUserMovies(string userId);
        Task<UserTotalMovies> GetUserTotalNumberOfMovies(string userId);
    }

    public class WatchListsService(IBaseRepository baseRepository) : IWatchListsService
    {
        private readonly IBaseRepository _baseRepository = baseRepository;

        public async Task<UserWatchList> GetUserMovies(string userId)
        {
            var watchListsCollection = _baseRepository.GetCollection<WatchListsEntity>();
            var movieCollection = _baseRepository.GetCollection<MovieEntity>();
            var userCollection = _baseRepository.GetCollection<UserEntity>();

            var unwingOptions = new AggregateUnwindOptions<WatchListToMovieToUserModel>
            {
                PreserveNullAndEmptyArrays = true
            };

            var userWatchList = await watchListsCollection
                .Aggregate()
                .Match(x => x.UserId == userId)
                .Lookup<WatchListsEntity, MovieEntity, WatchListToMovieModel>(movieCollection, x => x.Movies, x => x.Id, x => x.MovieEntities)
                .Lookup<WatchListToMovieModel, UserEntity, WatchListToMovieToUserModel>(userCollection, x => x.UserId, x => x.Id, x => x.UserEntity)
                .Unwind(reviewToMovie => reviewToMovie.UserEntity, unwingOptions)
                .Project(x => new UserWatchList
                {
                    UserName = x.UserEntity.Name,
                    Movies = x.MovieEntities.Select(x => x.Title).ToList(),
                })
                .FirstOrDefaultAsync();

            return userWatchList;
        }

        public async Task<UserTotalMovies> GetUserTotalNumberOfMovies(string userId)
        {
            var watchListsCollection = _baseRepository.GetCollection<WatchListsEntity>();
            var userCollection = _baseRepository.GetCollection<UserEntity>();

            var unwingOptions = new AggregateUnwindOptions<WatchListToUserModel>
            {
                PreserveNullAndEmptyArrays = true
            };

            var userWatchList = await watchListsCollection
               .Aggregate()
               .Match(x => x.UserId == userId)
               .Lookup<WatchListsEntity, UserEntity, WatchListToUserModel>(userCollection, x => x.UserId, x => x.Id, x => x.UserEntity)
               .Unwind(reviewToMovie => reviewToMovie.UserEntity, unwingOptions)
               .Project(x => new UserTotalMovies
               {
                   UserName = x.UserEntity.Name,
                   MoviesCount = x.Movies.Count,
               })
               .FirstOrDefaultAsync();

            return userWatchList;
        }
    }
}
