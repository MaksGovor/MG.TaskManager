using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.TaskManager.DAL.Entity
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public Status Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }

    public enum Status
    {
        NonStarted,
        InProgress,
        Finished
    }
}
