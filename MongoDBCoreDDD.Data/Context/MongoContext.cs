using MongoDB.Driver;
using MongoDBCoreDDD.Domain.Entities;

namespace MongoDBCoreDDD.Data.Context
{
    public class MongoContext<T> where T : class
    {
        private readonly IMongoDatabase database;

        public MongoContext()
        {
            database = new MongoClient("mongodb://localhost:27017").GetDatabase("Users");
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return database.GetCollection<User>("Users");
            }
        }
    }
}
