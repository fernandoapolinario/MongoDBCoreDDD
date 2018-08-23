using FluentValidation;
using System.Collections.Generic;
using MongoDBCoreDDD.Domain.Entities;

namespace MongoDBCoreDDD.Domain.Interfaces
{
    public interface IUserService<T> where T : BaseEntity
    {
        User Post<V>(User obj) where V : AbstractValidator<User>;

        User Put<V>(User obj) where V : AbstractValidator<User>;

        void Delete(string id);

        User Get(string id);

        IList<User> Get();
    }
}
