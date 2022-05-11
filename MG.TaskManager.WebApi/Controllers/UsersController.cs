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
    public class UsersController : ApiController
    {
        private readonly IMapper mapper = AutoMapperConfiguration.provideMaper();
        private readonly IUserService _userService;

        public UsersController(IUserService userService) : base()
        {
            _userService = userService;
        }

        [ResponseType(typeof(IEnumerable<UserResponseDto>))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly returns list of users")]
        // GET: api/Users
        public IHttpActionResult Get()
        {
             IEnumerable<UserResponseDto> users = _userService.GetAll().Select(user => mapper.Map<User, UserResponseDto>(user));

             return Ok(users);
        }

        [ResponseType(typeof(UserResponseDto))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly returns user with id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "There is no users with such id")]
        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            User user = _userService.FindById(id);
            
            if (user == null)
            {
                return BadRequest("User with such id not found");
            }

            UserResponseDto userDto = mapper.Map<User, UserResponseDto>(user);

            return Ok(userDto);
        }

        [SwaggerResponseRemoveDefaults]
        [ResponseType(typeof(UserResponseDto))]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Sucessfuly creates user")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid input")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal server error")]
        // POST: api/Users
        public HttpResponseMessage Post([FromBody]UserRequestDto userDto)
        {
            try
            {
                User user = mapper.Map<UserRequestDto, User>(userDto);
                UserResponseDto userResponce = mapper.Map<User, UserResponseDto>(_userService.SignUp(user));
                return Request.CreateResponse(HttpStatusCode.Created, userResponce);
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

        [ResponseType(typeof(void))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Sucessfuly deleted")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal server error")]
        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteById(id);
                return Ok();
            }
            catch (BusinessLogicException e)
            {
                return NotFound();
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
