using MG.TaskManager.DAL.Entity;
using MG.TaskManager.DAL.EntityFramework;
using MG.TaskManager.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MG.TaskManager.DAL.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TMContext _tmContext;
        public ProjectRepository(TMContext context)
        {
            _tmContext = context;
        }

        public Project Get(int projectId)
        {
            return _tmContext.Projects.Find(projectId);
        }

        public void Create(Project item)
        {
            _tmContext.Projects.Add(item);
        }

        public void Update(Project item)
        {
            _tmContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var project = _tmContext.Projects.Find(id);
            if (project != null)
            {
                _tmContext.Projects.Remove(project);
            }
        }

        public Project FindById(int id)
        {
            return _tmContext.Projects.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _tmContext.Projects;
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            return _tmContext.Projects.Where(predicate).ToList();
        }
    }
}
