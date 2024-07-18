using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoTest.Core;
using MongoTest.Data.Attributes;

namespace MongoTest.Data.Repositories
{
    public class BaseRepository(IMongoClient client, IOptions<DatabaseSettings> databaseOptions)
    {
        public IMongoDatabase Database { get; } = client.GetDatabase(databaseOptions.Value.MoviesDatabase);

        public IMongoCollection<T> GetCollection<T>(ReadPreference? readPreference = null) where T : class
        {
            return Database
              .WithReadPreference(readPreference ?? ReadPreference.Primary)
              .GetCollection<T>(GetCollectionName<T>());
        }

        public static string GetCollectionName<T>() where T : class
        {
            return (typeof(T).GetCustomAttributes(typeof(MongoCollectionAttribute), true).FirstOrDefault() as MongoCollectionAttribute)?.CollectionName
                ?? throw new ApplicationException("Failed to retrieve 'CollectionName' from the 'MongoCollection' attribute.");
        }
    }
}