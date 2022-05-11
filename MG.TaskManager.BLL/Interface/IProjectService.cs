using MG.TaskManager.DAL.Entity;
using System.Collections.Generic;

namespace MG.TaskManager.BLL.Interface
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();
        Project Create(Project project);
        Project FindById(int id);
        bool IsExistById(int id);
        Project Update(int projectId, Project projectFieldsToUpdate);
        void DeleteById(int id);
    }
}
