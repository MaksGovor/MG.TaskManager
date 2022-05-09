using MG.TaskManager.DAL.Entity;

namespace MG.TaskManager.DAL.Interface
{
    public interface ITaskRepository : IRepository<Task>
    {
        Task FindById(int id);
    }
}
