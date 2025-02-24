﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoTest.Data.Attributes;

namespace MongoTest.Data.Entities
{
    [MongoCollection("reviews")]
    public record class ReviewEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required string MovieId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required string UserId { get; set; }

        public int Rating { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string? ReviewText { get; set; }


        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime ReviewDate { get; set; }
    }
}
