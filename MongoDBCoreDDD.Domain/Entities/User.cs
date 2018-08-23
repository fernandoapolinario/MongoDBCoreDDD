using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCoreDDD.Domain.Entities
{
    public class User : BaseEntity
    {
        [BsonRequired]
        public string FistName { get; set; }

        [BsonRequired]
        public string LastName { get; set; }

        public string Document { get; set; }

        public int Age { get; set; }
    }
}
