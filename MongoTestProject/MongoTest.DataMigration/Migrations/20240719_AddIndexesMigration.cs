using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBMigrations;
using MongoTest.Data.Entities;
using MongoTest.Data.Repositories;
using System.Collections.Generic;

namespace MongoTest.DataMigration.Migrations
{
    public class AddIndexesMigration : IMigration
    {
        public MongoDBMigrations.Version Version => new(0, 0, 3);
        public string Name => "2024-07-19: Add indexes";

        private readonly string _reviewCollectionName = BaseRepository.GetCollectionName<ReviewEntity>();
        private readonly string _usersCollectionName = BaseRepository.GetCollectionName<UserEntity>();
        private readonly string _moviesCollectionName = BaseRepository.GetCollectionName<MovieEntity>();
        private readonly string _watchListsCollectionName = BaseRepository.GetCollectionName<WatchListsEntity>();

        public void Up(IMongoDatabase database)
        {
            var moviesIndexes = new List<CreateIndexModel<MovieEntity>>
            {
                new(Builders<MovieEntity>.IndexKeys.Descending(x => x.Rating)),
                new(Builders<MovieEntity>.IndexKeys.Text(x => x.Title)),
                new(Builders<MovieEntity>.IndexKeys.Descending(x => x.Director).Descending(x => x.Genres))
            };
            database.GetCollection<MovieEntity>(_moviesCollectionName).Indexes.CreateMany(moviesIndexes);

            var usersIndexes = new List<CreateIndexModel<UserEntity>>
            {
                new(Builders<UserEntity>.IndexKeys.Text(x => x.Email)),
            };
            database.GetCollection<UserEntity>(_usersCollectionName).Indexes.CreateMany(usersIndexes);

            var reviewIndexes = new List<CreateIndexModel<ReviewEntity>>
            {
                new(Builders<ReviewEntity>.IndexKeys.Descending(x => x.Rating)),
                new(Builders<ReviewEntity>.IndexKeys.Ascending(x => x.MovieId).Ascending(x => x.UserId))
            };
            database.GetCollection<ReviewEntity>(_reviewCollectionName).Indexes.CreateMany(reviewIndexes);

            var WatchListsIndexes = new List<CreateIndexModel<WatchListsEntity>>
            {
                new(Builders<WatchListsEntity>.IndexKeys.Ascending(x => x.UserId)),
            };
            database.GetCollection<WatchListsEntity>(_watchListsCollectionName).Indexes.CreateMany(WatchListsIndexes);
        }

        public void Down(IMongoDatabase database)
        {
            database.GetCollection<ReviewEntity>(_reviewCollectionName).Indexes.DropAll();
            database.GetCollection<WatchListsEntity>(_watchListsCollectionName).Indexes.DropAll();
            database.GetCollection<UserEntity>(_usersCollectionName).Indexes.DropAll();
            database.GetCollection<MovieEntity>(_moviesCollectionName).Indexes.DropAll();
        }
    }
}
