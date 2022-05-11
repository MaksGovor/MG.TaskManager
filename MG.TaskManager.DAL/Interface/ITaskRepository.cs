using MG.TaskManager.DAL.Entity;

namespace MG.TaskManager.DAL.Interface
{
    public interface ITaskRepository : IRepository<Task>
    {
        Task FindById(int id);
        void DeleteAllByProjectId(int id);
        void DeleteAllByUserId(int id);
    }
}
