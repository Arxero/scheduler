using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scheduler.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IRepositoryWrapper Repository;
        private readonly IMapper Mapper;

        public UsersController(IRepositoryWrapper repositoryBase, IMapper mapper)
        {
            Repository = repositoryBase;
            Mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await Repository.User.GetAllAsync();
            var mappedUsers = Mapper.Map<IList<UserDto>>(users);
            return Ok(mappedUsers);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            User user = await Repository.User.GetByIdAsync(id);
            var mappedUser = Mapper.Map<UserDto>(user);
            return Ok(mappedUser);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {    
            var theUser = await Repository.User.AddAsync(Mapper.Map<User>(user)); // saving db model
            var userToReturn = Mapper.Map<UserDto>(theUser);
            return CreatedAtRoute("Get", new { Id = userToReturn.Id }, userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto user)
        {      
            await Repository.User.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Repository.User.RemoveAsync(id);
            return NoContent();
        }

    }
}
