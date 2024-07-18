using MongoDB.Driver;
using MongoTest.Data.Entities;
using MongoTest.Data.Repositories;
using MongoTest.Services.Movies.Models;
using System.Linq.Expressions;

namespace MongoTest.Services.Movies
{
    public interface IMovieService
    {
        Task<List<SimpleMovieModel>> GetMoviesByDirector(string director);
        Task<List<SimpleMovieModel>> GetMoviesInGenreWithRatingHigherThan(string genre, double rating);
    }

    public class MovieService(IBaseRepository baseRepository) : IMovieService
    {
        private readonly IBaseRepository _baseRepository = baseRepository;

        private readonly Expression<Func<MovieEntity, SimpleMovieModel>> ToModel = entity => new SimpleMovieModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Director = entity.Director,
            Genres = entity.Genres,
            ReleaseDate = entity.ReleaseDate,
            Rating = entity.Rating,
            Views = entity.Views
        };

        public async Task<List<SimpleMovieModel>> GetMoviesByDirector(string director)
        {
            var movies = await _baseRepository.GetCollection<MovieEntity>()
                .Find(x => x.Director == director)
                .Project(ToModel)
                .ToListAsync();
            return movies;
        }

        public async Task<List<SimpleMovieModel>> GetMoviesInGenreWithRatingHigherThan(string genre, double rating)
        {
            var movies = await _baseRepository.GetCollection<MovieEntity>()
                .Find(x => x.Genres.Contains(genre) && x.Rating > rating)
                .Project(ToModel)
                .ToListAsync();
            return movies;
        }
    }
}
