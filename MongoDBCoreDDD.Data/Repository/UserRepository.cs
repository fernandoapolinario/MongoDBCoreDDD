using MongoDBCoreDDD.Data.Context;
using MongoDBCoreDDD.Domain.Entities;
using MongoDBCoreDDD.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDBCoreDDD.Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        private MongoContext<User> _context;

        public UserRepository()
        {
            _context = new MongoContext<User>();
        }

        public void Insert(User obj)
        {
            _context.Users.InsertOne(obj);
        }

        public void Remove(string id)
        {
            _context.Users.DeleteOneAsync(Builders<User>.Filter.Eq("Id", id));
        }

        public User Select(string id)
        {
            var user = _context.Users.Find(x => x.Id == id).First();
            return user;
        }

        public IList<User> Select()
        {
            IList<User> users = _context.Users.Find(x => true).ToList();
            return users;
        }

        public void Update(User obj)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, obj.Id);
            var update = Builders<User>.Update
                            .Set(s => s.FistName, obj.FistName)
                            .Set(s => s.LastName, obj.LastName)
                            .Set(s => s.Document, obj.Document)
                            .Set(s => s.Age, obj.Age);

            _context.Users.UpdateOne(filter, update);
        }
    }
}
