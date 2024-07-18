using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoTest.Data.Attributes;

namespace MongoTest.Data.Entities
{
    [MongoCollection("movies")]
    public record MovieEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public required string Title { get; set; }

        [BsonRepresentation(BsonType.String)]
        public required string Director { get; set; }

        public List<string> Genres { get; set; } = [];

        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime ReleaseDate { get; set; }

        public double Rating { get; set; }

        public int Views { get; set; }
    }
}
