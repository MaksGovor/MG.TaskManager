using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MG.TaskManager.DAL.Entity;
using MG.TaskManager.DAL.EntityFramework;
using MG.TaskManager.DAL.Interface;

namespace MG.TaskManager.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TMContext _tmContext;

        public UserRepository(TMContext context)
        {
            _tmContext = context;
        }

        public User Get(int userId)
        {
            return _tmContext.Users.Find(userId);
        }

        public void Create(User item)
        {
            _tmContext.Users.Add(item);
        }

        public void Update(User item)
        {
            _tmContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var user = _tmContext.Users.Find(id);
            if (user != null)
            {
                _tmContext.Users.Remove(user);
            }
        }

        public User FindById(int id)
        {
            return _tmContext.Users.Find(id);
        }

        public User FindByLogin(string login)
        {
            return _tmContext.Users.SingleOrDefault(user => user.Login == login);
        }

        public IEnumerable<User> GetAll()
        {
            return _tmContext.Users;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _tmContext.Users.Where(predicate).ToList();
        }
    }
}
