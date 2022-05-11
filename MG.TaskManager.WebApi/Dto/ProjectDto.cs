using System;
using System.ComponentModel.DataAnnotations;

namespace MG.TaskManager.WebApi.Dto
{
    public class ProjectResponceDto
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "ProjectName can not be empty")]
        public string ProjectName { get; set; }

        public DateTime BeginDate { get; set; }
        
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "OwnerId can not be empty")]
        public int OwnerId { get; set; }
    }

    public class ProjectRequestDto
    {
        [Required(ErrorMessage = "ProjectName can not be empty")]
        public string ProjectName { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "OwnerId can not be empty")]
        public int OwnerId { get; set; }
    }
}
