using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutomizedWorkplace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkplaceBLL.DTO;
using WorkplaceBLL.Interfaces;

namespace AutomizedWorkplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices service;
        IMapper mapper;
        public UserController(IUserServices serv,IMapper map)
        {
            serv = service;
            map = mapper;
        }



        // GET: api/User
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            return mapper.Map<IEnumerable<UserModel>>(await service.GetUsers());
        }

        
        [Authorize]
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserModel> Get(int id)
        {
            return mapper.Map<UserModel>(await service.GetUser(id));
        }

        
        // PUT: api/User/5
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(UserModel user)
        {
            await service.UpdateUser(mapper.Map<UserDTO>(user));
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return Ok();
        }
    }
}
