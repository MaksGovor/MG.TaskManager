using MG.TaskManager.DAL.Entity;

namespace MG.TaskManager.DAL.Interface
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project FindById(int id);
    }
}
