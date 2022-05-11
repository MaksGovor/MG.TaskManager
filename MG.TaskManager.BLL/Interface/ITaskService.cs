using MG.TaskManager.DAL.Entity;
using System.Collections.Generic;

namespace MG.TaskManager.BLL.Interface
{
    public interface ITaskService
    {
        IEnumerable<Task> GetAllTasksForProject(int projectId);
        IEnumerable<Task> GetAllTasksForUser(int projectId, int userId);
        Task Create(Task task);
        Task FindById(int id);
        bool IsExistById(int id);
        Task Update(int taskId, Task task);
        Task UpdateStatus(int taskId, Status status);
        void DeleteById(int id);
        void DeleteAllByProjectId(int id);
        void DeleteAllByUserId(int id);
    }
}
