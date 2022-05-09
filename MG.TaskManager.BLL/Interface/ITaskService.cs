using MG.TaskManager.DAL.Entity;

namespace MG.TaskManager.BLL.Interface
{
    interface ITaskService
    {
        void Create(Task task);
        Task FindById(int id);
        bool IsExistById(int id);
        void Update(int taskId, Task task);
        void DeleteById(int id);
    }
}
