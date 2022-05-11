using MG.TaskManager.BLL.Interface;
using MG.TaskManager.BLL.Validation;
using MG.TaskManager.DAL.Entity;
using MG.TaskManager.DAL.Interface;
using System.Collections.Generic;

namespace MG.TaskManager.BLL.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _unitOfWork.Projects.GetAll();
        }

        public IEnumerable<Project> GetAllProjectsForUser(int userId)
        {
            return _unitOfWork.Projects.Find(p => p.UserId == userId);
        }

        public Project Create(Project project)
        {
            if (!ProjectValidation.checkValidInput(project))
            {
                throw new BusinessLogicException("Project fields is not valid, check date fields or userId");
            }

            if (_unitOfWork.Users.FindById(project.UserId) == null)
            {
                throw new BusinessLogicException($"User with id: {project.UserId} not exist");
            }

            _unitOfWork.Projects.Create(project);
            _unitOfWork.Save();
            return project;
        }

        public Project FindById(int id)
        {
            return _unitOfWork.Projects.FindById(id);
        }

        public bool IsExistById(int id)
        {
            return FindById(id) != null;
        }

        public void Update(int projectId, Project projectFieldsToUpdate)
        {
            if (!IsExistById(projectId))
            {
                throw new BusinessLogicException("There is no project with id = " + projectId);
            }

            Project project = _unitOfWork.Projects.FindById(projectId);
            project.ProjectName = projectFieldsToUpdate.ProjectName ?? project.ProjectName;
            project.BeginDate = projectFieldsToUpdate.BeginDate ?? project.BeginDate;
            project.EndDate = projectFieldsToUpdate.EndDate ?? project.EndDate;
            project.UserId = projectFieldsToUpdate.UserId != 0 ? projectFieldsToUpdate.UserId : project.UserId;

            _unitOfWork.Projects.Update(project);
            _unitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            bool isProjectExists = IsExistById(id);
            if (!isProjectExists)
            {
                throw new BusinessLogicException("There is no project with id = " + id);
            }

            _unitOfWork.Projects.Delete(id);
            _unitOfWork.Save();
        }
    }
}
