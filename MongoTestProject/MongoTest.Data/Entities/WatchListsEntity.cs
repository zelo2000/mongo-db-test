using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoTest.Data.Attributes;

namespace MongoTest.Data.Entities
{
    [MongoCollection("watch_lists")]
    public class WatchListsEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Movies { get; set; } = [];
    }
}
