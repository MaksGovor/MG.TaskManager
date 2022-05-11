using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using MG.TaskManager.BLL.Interface;
using MG.TaskManager.BLL.Validation;
using MG.TaskManager.DAL.Entity;
using MG.TaskManager.WebApi.App_Start;
using MG.TaskManager.WebApi.Dto;
using Swashbuckle.Swagger.Annotations;

namespace MG.TaskManager.WebApi.Controllers
{
    public class ProjectsController : ApiController
    {
        private readonly IMapper mapper = AutoMapperConfiguration.provideMaper();
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService) : base()
        {
            _projectService = projectService;
        }

        [ResponseType(typeof(IEnumerable<ProjectResponceDto>))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly returns list of projects")]
        // GET: api/Projects
        public IHttpActionResult Get()
        {
            IEnumerable<ProjectResponceDto> projects = _projectService
                .GetAllProjects()
                .Select(project => mapper.Map<Project, ProjectResponceDto>(project));

            return Ok(projects);
        }

        [ResponseType(typeof(ProjectResponceDto))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly returns project with id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "There is no projects with such id")]
        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            Project project = _projectService.FindById(id);

            if (project == null)
            {
                return BadRequest("Project with such id not found");
            }

            ProjectResponceDto projectResponce = mapper.Map<Project, ProjectResponceDto>(project);

            return Ok(projectResponce);
        }

        [SwaggerResponseRemoveDefaults]
        [ResponseType(typeof(ProjectResponceDto))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Sucessfuly creates project")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid input")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal server error")]
        // POST: api/Projects
        public HttpResponseMessage Post([FromBody]ProjectRequestDto projectDto)
        {
            try
            {
                Project project = mapper.Map<ProjectRequestDto, Project>(projectDto);
                ProjectResponceDto projectResponce = mapper.Map<Project, ProjectResponceDto>(_projectService.Create(project));
                return Request.CreateResponse(HttpStatusCode.Created, projectResponce);
            }
            catch (BusinessLogicException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = e.Message });
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new { Message = "Internal server error" });
            }
        }


        [ResponseType(typeof(ProjectResponceDto))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly updated")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid id")]
        // PUT: api/Projects/5
        public IHttpActionResult Put(int id, [FromBody]ProjectRequestDto projectDto)
        {
            try
            {
                Project project = mapper.Map<ProjectRequestDto, Project>(projectDto);
                ProjectResponceDto projectResponce = mapper.Map<Project, ProjectResponceDto>(_projectService.Update(id, project));
                return Ok(projectResponce);
            }
            catch (BusinessLogicException e)
            {
                return BadRequest(e.Message);
            }
        }

        [ResponseType(typeof(void))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly deleted")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid id")]
        // DELETE: api/Projects/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _projectService.DeleteById(id);
                return Ok();
            }
            catch (BusinessLogicException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
