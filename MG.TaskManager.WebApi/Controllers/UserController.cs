using AutoMapper;
using MG.TaskManager.BLL.Interface;
using MG.TaskManager.DAL.Entity;
using MG.TaskManager.WebApi.App_Start;
using MG.TaskManager.WebApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MG.TaskManager.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IMapper mapper = AutoMapperConfiguration.provideMaper();
        private readonly IUserService _userService;

        public UserController(IUserService userService) : base()
        {
            _userService = userService;
        }

        // GET: api/User
        public IHttpActionResult Get()
        {
            IEnumerable<UserDto> users = _userService.GetAll().Select(user => mapper.Map<User, UserDto>(user));

            return Ok(users);
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
