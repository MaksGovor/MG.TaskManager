using MG.TaskManager.DAL.Entity;
using MG.TaskManager.DAL.EntityFramework;
using MG.TaskManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MG.TaskManager.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TMContext _tmContext;

        public TaskRepository(TMContext context)
        {
            _tmContext = context;
        }

        public Task Get(int taskId)
        {
            return _tmContext.Tasks.Find(taskId);
        }

        public void Create(Task item)
        {
            _tmContext.Tasks.Add(item);
        }

        public void Update(Task item)
        {
            _tmContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var task = _tmContext.Tasks.Find(id);
            if (task != null)
            {
                _tmContext.Tasks.Remove(task);
            }
        }

        public Task FindById(int id)
        {
            return _tmContext.Tasks.Find(id);
        }

        public IEnumerable<Task> GetAll()
        {
            return _tmContext.Tasks;
        }

        public IEnumerable<Task> Find(Func<Task, bool> predicate)
        {
            return _tmContext.Tasks.Where(predicate).ToList();
        }
    }
}
