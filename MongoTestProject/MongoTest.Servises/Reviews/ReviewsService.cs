using MongoDB.Driver;
using MongoTest.Data.Entities;
using MongoTest.Data.Repositories;
using MongoTest.Services.Reviews.Models;

namespace MongoTest.Services.Reviews
{
    public interface IReviewsService
    {
        Task<List<AverageRatingReviewModel>> GetAverageRatingForAllMovies();
    }

    public class ReviewsService(IBaseRepository baseRepository) : IReviewsService
    {
        private readonly IBaseRepository _baseRepository = baseRepository;

        public async Task<List<AverageRatingReviewModel>> GetAverageRatingForAllMovies()
        {
            var reviewCollection = _baseRepository.GetCollection<ReviewEntity>();
            var movieCollection = _baseRepository.GetCollection<MovieEntity>();

            var unwingOptions = new AggregateUnwindOptions<ReviewToMovieModel>
            {
                PreserveNullAndEmptyArrays = true
            };

            var test = await reviewCollection
                .Aggregate()
                .Lookup<ReviewEntity, MovieEntity, ReviewToMovieModel>(movieCollection, x => x.MovieId, x => x.Id, x => x.Movie)
                .Unwind(reviewToMovie => reviewToMovie.Movie, unwingOptions)
                .Group(
                    x => x.Movie.Title,
                    x => new AverageRatingReviewModel
                    {
                        MovieTitle = x.Key,
                        AverageRating = x.Average(x => x.Rating)
                    }
                ).ToListAsync();

            return test;
        }
    }
}
