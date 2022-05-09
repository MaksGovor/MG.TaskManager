using MG.TaskManager.DAL.Entity;
using System;

namespace MG.TaskManager.BLL.Validation
{
    public class ProjectValidation
    {
        public static bool checkValidInput(Project project)
        {
            return (
                project.ProjectName != null && !project.ProjectName.Equals(string.Empty) &&
                project.UserId > 0 &&
                project.BeginDate >= DateTime.Now && project.BeginDate <= project.EndDate
                );
        }
    }
}
