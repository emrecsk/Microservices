using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //MongoDB'de ObjectId tipinde olmasını sağlıyoruz.
        public required string Id { get; set; }
        public required string Name { get; set; }
    }
}
