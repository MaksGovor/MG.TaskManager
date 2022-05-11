using MG.TaskManager.BLL.Interface;
using MG.TaskManager.BLL.Validation;
using MG.TaskManager.DAL.Entity;
using MG.TaskManager.DAL.Interface;
using System.Collections.Generic;

namespace MG.TaskManager.BLL.Service
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Task> GetAllTasksForProject(int projectId)
        {
            return _unitOfWork.Tasks.Find(t => t.ProjectId == projectId);
        }

        public IEnumerable<Task> GetAllTasksForUser(int userId)
        {
            return _unitOfWork.Tasks.Find(t => t.ProjectId == userId);
        }

        public void Create(Task task)
        {
            if (!TaskValidation.checkValidInput(task))
            {
                throw new BusinessLogicException("Task fields is not valid");
            }

            if (_unitOfWork.Users.FindById((int)task.UserId) == null)
            {
                throw new BusinessLogicException($"User with id: {task.UserId} not exist");
            }

            if (_unitOfWork.Projects.FindById(task.ProjectId) == null)
            {
                throw new BusinessLogicException($"Project with id: {task.ProjectId} not exist");
            }

            _unitOfWork.Tasks.Create(task);
            _unitOfWork.Save();
        }

        public void Update(int taskId, Task taskFieldsToUpdate)
        {
            Task task = _unitOfWork.Tasks.FindById(taskId);
            if (task == null)
            {
                throw new BusinessLogicException("There is no task with id = " + taskId);
            }

            Task validTask = TaskValidation.validateUpdateTaskDto(taskFieldsToUpdate, task);
            if (_unitOfWork.Users.FindById((int)validTask.UserId) == null)
            {
                throw new BusinessLogicException($"User with id: {validTask.UserId} not exist");
            }

            if (_unitOfWork.Projects.FindById(validTask.ProjectId) == null)
            {
                throw new BusinessLogicException($"Project with id: {validTask.ProjectId} not exist");
            }

            task.TaskName = validTask.TaskName;
            task.Description = validTask.Description;
            task.Priority = validTask.Priority;
            task.Status = validTask.Status;
            task.StartDate = validTask.StartDate;
            task.EndDate = validTask.EndDate;
            task.ProjectId = validTask.ProjectId;
            task.UserId = validTask.UserId;

            _unitOfWork.Tasks.Update(task);
            _unitOfWork.Save();
        }

        public void UpdateStatus(int taskId, Status status)
        {
            Task task = _unitOfWork.Tasks.FindById(taskId);

            if (task == null)
            {
                throw new BusinessLogicException("There is no task with id = " + taskId);
            }
            task.Status = status;

            _unitOfWork.Tasks.Update(task);
            _unitOfWork.Save();
        }

        public Task FindById(int id)
        {
            return _unitOfWork.Tasks.FindById(id);
        }

        public bool IsExistById(int id)
        {
            return FindById(id) != null;
        }

        public void DeleteById(int id)
        {
            bool isTaskExists = IsExistById(id);
            if (!isTaskExists)
            {
                throw new BusinessLogicException("There is no task with id = " + id);
            }

            _unitOfWork.Tasks.Delete(id);
            _unitOfWork.Save();
        }

        public void DeleteAllByProjectId(int id)
        {
            if (id <= 0 || _unitOfWork.Projects.FindById(id) == null)
            {
                throw new BusinessLogicException("There is no project with id = " + id);
            }

            _unitOfWork.Tasks.DeleteAllByProjectId(id);
            _unitOfWork.Save();
        }

        public void DeleteAllByUserId(int id)
        {
            if (id <= 0 || _unitOfWork.Users.FindById(id) == null)
            {
                throw new BusinessLogicException("There is no user with id = " + id);
            }

            _unitOfWork.Tasks.DeleteAllByUserId(id);
            _unitOfWork.Save();
        }
    }
}
