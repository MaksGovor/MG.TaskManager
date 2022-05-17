using MG.TaskManager.DAL.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MG.TaskManager.WebApi.Dto
{
    public class TaskResponseDto
    {
        [Required(ErrorMessage = "TaskId can not be empty")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "TaskName can not be empty")]
        public string TaskName { get; set; }
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Priority can not be empty")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "Status can not be empty")]
        public Status Status { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
        [Required(ErrorMessage = "Project can not be empty")]
        public ProjectResponseDto Project { get; set; }
        
        [Required(ErrorMessage = "Executor can not be empty")]
        public UserResponseDto Executor { get; set; }
    }

    public class TaskRequestDto
    {
        [Required(ErrorMessage = "TaskName can not be empty")]
        public string TaskName { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Priority can not be empty")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "Status can not be empty")]
        public Status Status { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "ProjectId can not be empty")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "ExecutorId can not be empty")]
        public int ExecutorId { get; set; }
    }
}
