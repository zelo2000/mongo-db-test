using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoTest.Data.Attributes;

namespace MongoTest.Data.Entities
{
    [MongoCollection("users")]
    public record UserEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public required string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public required string Email { get; set; }

        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime SubscriptionDate { get; set; }
    }
}
