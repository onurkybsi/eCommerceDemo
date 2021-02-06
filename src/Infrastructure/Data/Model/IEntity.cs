using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Data
{
    public class Entity
    {
        [BsonIgnore]
        public int Id { get; set; }
        [NotMapped]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MongoDBObjectId { get; set; }
    }
}