using MongoDBCoreDDD.Domain.Entities;
using System.Collections.Generic;

namespace MongoDBCoreDDD.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Remove(string id);

        T Select(string id);

        IList<T> Select();
    }
}
