using MG.TaskManager.DAL.Entity;

namespace MG.TaskManager.BLL.Interface
{
    public interface IProjectService
    {
        void Create(Project project);
        Project FindById(int id);
        bool IsExistById(int id);
        void Update(int projectId, Project project);
        void DeleteById(int id);
    }
}
