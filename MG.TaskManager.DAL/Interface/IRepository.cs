using System;
using System.Collections.Generic;

namespace MG.TaskManager.DAL.Interface
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);

        IEnumerable<T> Find(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
    }
}
