using MG.TaskManager.DAL.Entity;
using System;

namespace MG.TaskManager.BLL.Validation
{
    class TaskValidation
    {
        public static bool checkValidInput(Task taskToCheck)
        {
            return (
                taskToCheck.TaskName != null && !taskToCheck.TaskName.Equals(string.Empty) &&
                taskToCheck.Priority >= 0 &&
                !taskToCheck.TaskName.Equals(string.Empty) &&
                taskToCheck.ProjectId > 0 &&
                taskToCheck.UserId > 0 &&
                taskToCheck.StartDate >= DateTime.Now && taskToCheck.StartDate <= taskToCheck.EndDate
                );
        }

        public static Task validateUpdateTaskDto(Task taskFieldsToUpdate, Task task)
        {
            Task validTaskDto = new Task();
            validTaskDto.TaskName = taskFieldsToUpdate.TaskName ?? task.TaskName;
            validTaskDto.Description = taskFieldsToUpdate.Description ?? task.Description;
            validTaskDto.Priority = taskFieldsToUpdate.Priority >= 0 ? taskFieldsToUpdate.Priority : task.Priority;
            validTaskDto.Status = taskFieldsToUpdate.Status;
            validTaskDto.StartDate = taskFieldsToUpdate.StartDate ?? task.StartDate;
            validTaskDto.EndDate = taskFieldsToUpdate.EndDate ?? task.EndDate;
            validTaskDto.ProjectId = taskFieldsToUpdate.ProjectId > 0 ? taskFieldsToUpdate.ProjectId : task.ProjectId;
            validTaskDto.UserId = taskFieldsToUpdate.UserId > 0 ? taskFieldsToUpdate.UserId : task.UserId;

            if (!checkValidInput(validTaskDto))
            {
                throw new BusinessLogicException("Task fields is not valid");
            }

            return validTaskDto;
        }

        public static bool checkTaskDatesByProject(Task task, Project project)
        {
            if (project == null)
            {
                throw new BusinessLogicException($"Project with id: {task.ProjectId} not exist");
            }

            return (
                task.EndDate <= project.EndDate &&
                task.StartDate >= project.BeginDate
                );
        }
    }
}
