using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBMigrations;
using MongoTest.Data.Entities;
using MongoTest.Data.Repositories;

namespace MongoTest.DataMigration.Migrations
{
    public class InsertInitialDataMigration : IMigration
    {
        public MongoDBMigrations.Version Version => new(0, 0, 2);
        public string Name => "2024-07-18: Populate initial data";

        private readonly string _reviewCollectionName = BaseRepository.GetCollectionName<ReviewEntity>();
        private readonly string _usersCollectionName = BaseRepository.GetCollectionName<UserEntity>();
        private readonly string _moviesCollectionName = BaseRepository.GetCollectionName<MovieEntity>();
        private readonly string _watchListsCollectionName = BaseRepository.GetCollectionName<WatchListsEntity>();

        public void Up(IMongoDatabase database)
        {
            var movieCollection = database.GetCollection<MovieEntity>(_moviesCollectionName);
            movieCollection.InsertMany([
                    new()
                    {
                        Title = "The Matrix",
                        Director = "Lana Wachowski",
                        Genres = ["Action", "Sci-Fi"],
                        ReleaseDate = new DateTime(1999, 3, 31),
                        Rating = 8.7,
                        Views = 1500000
                    },
                    new()
                    {
                        Title = "Inception",
                        Director = "Christopher Nolan",
                        Genres = ["Action", "Adventure", "Sci-Fi"],
                        ReleaseDate = new DateTime(2010, 7, 16),
                        Rating = 8.8,
                        Views = 2000000
                    },
                    new()
                    {
                        Title = "Interstellar",
                        Director = "Christopher Nolan",
                        Genres = ["Adventure", "Drama", "Sci-Fi"],
                        ReleaseDate = new DateTime(2014, 11, 7),
                        Rating = 8.6,
                        Views = 1800000
                    },
                    new()
                    {
                        Title = "The Shawshank Redemption",
                        Director = "Frank Darabont",
                        Genres = ["Drama"],
                        ReleaseDate = new DateTime(1994, 9, 22),
                        Rating = 9.3,
                        Views = 2200000
                    },
                    new()
                    {
                        Title = "The Godfather",
                        Director = "Francis Ford Coppola",
                        Genres = ["Crime", "Drama"],
                        ReleaseDate = new DateTime(1972, 3, 24),
                        Rating = 9.2,
                        Views = 2500000
                    }
                ]);

            var userCollection = database.GetCollection<UserEntity>(_usersCollectionName);
            userCollection.InsertMany([
                    new ()
                    {
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        SubscriptionDate = new DateTime(2021, 1, 1)
                    },
                    new ()
                    {
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com",
                        SubscriptionDate = new DateTime(2020, 5, 15)
                    },
                    new ()
                    {
                        Name = "Alice Johnson",
                        Email = "alice.johnson@example.com",
                        SubscriptionDate = new DateTime(2019, 11, 20)
                    },
                    new ()
                    {
                        Name = "Bob Brown",
                        Email = "bob.brown@example.com",
                        SubscriptionDate = new DateTime(2018, 7, 30)
                    },
                    new()
                    {
                        Name = "Charlie Davis",
                        Email = "charlie.davis@example.com",
                        SubscriptionDate = new DateTime(2022, 2, 10)
                    }
                ]);

            var movies = movieCollection.AsQueryable().ToList();
            var users = userCollection.AsQueryable().ToList();
            var random = new Random();

            database.GetCollection<ReviewEntity>(_reviewCollectionName).InsertMany([
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 5,
                        ReviewText = "Amazing movie!",
                        ReviewDate = new DateTime(2021, 3, 1)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 4,
                        ReviewText = "Great visuals and story.",
                        ReviewDate = new DateTime(2021, 6, 10)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 5,
                        ReviewText = "Mind-blowing!",
                        ReviewDate = new DateTime(2021, 9, 15)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 5,
                        ReviewText = "A masterpiece.",
                        ReviewDate = new DateTime(2021, 12, 20)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 5,
                        ReviewText = "Unparalleled acting.",
                        ReviewDate = new DateTime(2022, 1, 5)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 5,
                        ReviewText = "Amazing movie!",
                        ReviewDate = new DateTime(2021, 3, 1)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 4,
                        ReviewText = "Great visuals and story.",
                        ReviewDate = new DateTime(2021, 6, 10)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 5,
                        ReviewText = "Mind-blowing!",
                        ReviewDate = new DateTime(2021, 9, 15)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 5,
                        ReviewText = "A masterpiece.",
                        ReviewDate = new DateTime(2021, 12, 20)
                    },
                    new ()
                    {
                        MovieId = movies[random.Next(0, movies.Count)].Id,
                        UserId = users[random.Next(0, users.Count)].Id,
                        Rating = 5,
                        ReviewText = "Unparalleled acting.",
                        ReviewDate = new DateTime(2022, 1, 5)
                    }
                ]);

            database.GetCollection<WatchListsEntity>(_watchListsCollectionName).InsertMany([
                    new ()
                    {
                        UserId = users[0].Id,
                        Movies = [movies[0].Id, movies[1].Id]
                    },
                    new ()
                    {
                        UserId = users[1].Id,
                        Movies = [movies[2].Id, movies[3].Id]
                    },
                    new ()
                    {
                            UserId = users[2].Id,
                        Movies = [movies[4].Id]
                    },
                    new ()
                    {
                        UserId = users[3].Id,
                        Movies = [movies[0].Id, movies[4].Id]
                    },
                    new ()
                    {
                        UserId = users[4].Id,
                        Movies = [movies[1].Id, movies[3].Id]
                    }
                ]);
        }

        public void Down(IMongoDatabase database)
        {
            database.GetCollection<ReviewEntity>(_reviewCollectionName).DeleteMany(new BsonDocument());
            database.GetCollection<WatchListsEntity>(_watchListsCollectionName).DeleteMany(new BsonDocument());
            database.GetCollection<UserEntity>(_usersCollectionName).DeleteMany(new BsonDocument());
            database.GetCollection<MovieEntity>(_moviesCollectionName).DeleteMany(new BsonDocument());
        }
    }
}
