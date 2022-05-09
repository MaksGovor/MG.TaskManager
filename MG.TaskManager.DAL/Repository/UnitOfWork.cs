using MG.TaskManager.DAL.EntityFramework;
using MG.TaskManager.DAL.Interface;
using System;

namespace MG.TaskManager.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TMContext _tMContext;
        private bool _isDisposed;
        private UserRepository userRepository;
        private TaskRepository taskRepository;
        private ProjectRepository projectRepository;

        public UnitOfWork()
        {
            _tMContext = new TMContext();
        }

        public IUserRepository Users 
        { 
            get 
            {
                if (userRepository == null) userRepository = new UserRepository(_tMContext);
                return userRepository;
            } 
        }
        public ITaskRepository Tasks 
        {
            get
            {
                if (taskRepository == null) taskRepository = new TaskRepository(_tMContext);
                return taskRepository;
            }
        }
        public IProjectRepository Projects 
        {
            get
            {
                if (projectRepository == null) projectRepository = new ProjectRepository(_tMContext);
                return projectRepository;
            }
        }

        public void Save()
        {
            _tMContext.SaveChanges();
        }

        public void Dispose()
        {

            if (!_isDisposed)
            {
                _tMContext.Dispose();
                _isDisposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
