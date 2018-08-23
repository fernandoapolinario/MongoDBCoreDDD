using MongoDBCoreDDD.Data.Repository;
using MongoDBCoreDDD.Domain.Entities;
using MongoDBCoreDDD.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace MongoDBCoreDDD.Service.Services
{
    public class UserService<T> : IUserService<User> where T : BaseEntity
    {
        private UserRepository _repository = new UserRepository();

        public User Post<V>(User obj) where V : AbstractValidator<User>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);
            return obj;
        }

        public User Put<V>(User obj) where V : AbstractValidator<User>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }

        public void Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("The id can't be zero.");

            _repository.Remove(id);
        }

        public IList<User> Get() => _repository.Select();

        public User Get(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("The id can't be zero.");

            return _repository.Select(id);
        }

        private void Validate(User obj, AbstractValidator<User> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
