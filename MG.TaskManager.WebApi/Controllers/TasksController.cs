using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TasksController : ApiController
    {
        private readonly IMapper mapper = AutoMapperConfiguration.provideMaper();
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService) : base()
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("api/Tasks/AllForProject")]
        [ResponseType(typeof(IEnumerable<TaskResponseDto>))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly returns list of tasks for project")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid projectId")]
        // GET: api/Tasks
        public IHttpActionResult Get(int projectId)
        {
            try
            {
                IEnumerable<TaskResponseDto> tasks = _taskService.GetAllTasksForProject(projectId)
                    .Select(task => mapper.Map<Task, TaskResponseDto>(task));

                return Ok(tasks);
            }
            catch (BusinessLogicException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/Tasks/AllForUser")]
        [ResponseType(typeof(IEnumerable<TaskResponseDto>))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly returns list of tasks for user in project")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid projectId")]
        // GET: api/Tasks/5
        public IHttpActionResult Get(int projectId, int userId)
        {
            try
            {
                IEnumerable<TaskResponseDto> tasks = _taskService.GetAllTasksForUser(projectId, userId)
                    .Select(task => mapper.Map<Task, TaskResponseDto>(task));

                return Ok(tasks);
            }
            catch (BusinessLogicException e)
            {
                return BadRequest(e.Message);
            }
        }

        [SwaggerResponseRemoveDefaults]
        [ResponseType(typeof(TaskResponseDto))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Sucessfuly creates task")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid input")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal server error")]
        // POST: api/Tasks
        public HttpResponseMessage Post([FromBody]TaskRequestDto taskDto)
        {
            try
            {
                Task task = mapper.Map<TaskRequestDto, Task>(taskDto);
                TaskResponseDto taskResponse = mapper.Map<Task, TaskResponseDto>(_taskService.Create(task));
                return Request.CreateResponse(HttpStatusCode.Created, taskResponse);
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

        [ResponseType(typeof(TaskResponseDto))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Sucessfuly updates task")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid input")]
        // PUT: api/Tasks/5
        public IHttpActionResult Put(int id, [FromBody] TaskRequestDto taskDto)
        {
            try
            {
                Task task = mapper.Map<TaskRequestDto, Task>(taskDto);
                TaskResponseDto taskResponse = mapper.Map<Task, TaskResponseDto>(_taskService.Update(id, task));
                return Ok(taskResponse);
            }
            catch (BusinessLogicException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("api/Tasks/UdateStatus")]
        [ResponseType(typeof(TaskResponseDto))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Sucessfuly updates task")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid input")]
        // PUT: api/Tasks/5
        public IHttpActionResult Put(int id, [FromBody] Status status)
        {
            try
            {
                TaskResponseDto taskResponse = mapper.Map<Task, TaskResponseDto>(_taskService.UpdateStatus(id, status));
                return Ok(taskResponse);
            }
            catch (BusinessLogicException e)
            {
                return BadRequest(e.Message);
            }
        }

        [ResponseType(typeof(void))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly deleted")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal server error")]
        // DELETE: api/Tasks/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _taskService.DeleteById(id);
                return Ok();
            }
            catch (BusinessLogicException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
