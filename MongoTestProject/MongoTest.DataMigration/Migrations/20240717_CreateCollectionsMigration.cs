using MongoDB.Driver;
using MongoDBMigrations;
using MongoTest.Data.Entities;
using MongoTest.Data.Repositories;

namespace MongoTest.DataMigration.Migrations
{
    public class CreateCollectionsMigration : IMigration
    {
        public MongoDBMigrations.Version Version => new(0, 0, 1);
        public string Name => "2024-07-17: Create movies, users, reviews and watch lists collections";

        private readonly string _reviewCollectionName = BaseRepository.GetCollectionName<ReviewEntity>();
        private readonly string _usersCollectionName = BaseRepository.GetCollectionName<UserEntity>();
        private readonly string _moviesCollectionName = BaseRepository.GetCollectionName<MovieEntity>();
        private readonly string _watchListsCollectionName = BaseRepository.GetCollectionName<WatchListsEntity>();

        public void Up(IMongoDatabase database)
        {
            database.CreateCollection(_moviesCollectionName);
            database.CreateCollection(_usersCollectionName);
            database.CreateCollection(_reviewCollectionName);
            database.CreateCollection(_watchListsCollectionName);
        }

        public void Down(IMongoDatabase database)
        {
            var collectionNames = database.ListCollectionNames().ToList();

            if (collectionNames.Contains(_moviesCollectionName))
                database.DropCollection(_moviesCollectionName);

            if (collectionNames.Contains(_usersCollectionName))
                database.DropCollection(_usersCollectionName);

            if (collectionNames.Contains(_reviewCollectionName))
                database.DropCollection(_reviewCollectionName);

            if (collectionNames.Contains(_watchListsCollectionName))
                database.DropCollection(_watchListsCollectionName);
        }
    }
}
