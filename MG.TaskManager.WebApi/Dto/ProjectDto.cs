﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MG.TaskManager.WebApi.Dto
{
    public class ProjectResponseDto
    {
        [Required(ErrorMessage = "ProjectId can not be empty")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "ProjectName can not be empty")]
        public string ProjectName { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "OwnerId can not be empty")]
        public UserResponseDto Owner { get; set; }
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
