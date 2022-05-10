using System;
using System.ComponentModel.DataAnnotations;

namespace MG.TaskManager.WebApi.Dto
{
    public class TaskDto
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

    public enum Status
    {
        NonStarted,
        InProgress,
        Finished
    }

}
