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
            var users = await Repository.User.GetAllUsersAsync();
            var mappedUsers = Mapper.Map<IList<UserDto>>(users);
            return Ok(mappedUsers);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            User user = await Repository.User.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User with this id does not exist");
            }
            var mappedUser = Mapper.Map<UserDto>(user);
            return Ok(mappedUser);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("User is empty.");
            }

            var mappedUser = Mapper.Map<User>(user); // dto to db model
            mappedUser.CreatedAt = DateTime.Now;
            await Repository.User.AddUserAsync(mappedUser); // saving db model
            var userToreturn = Mapper.Map<UserDto>(mappedUser); // db model to dto
            return CreatedAtRoute("Get", new { Id = userToreturn.UserId }, userToreturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("User is empty.");
            }
            var userToUpdate = await Repository.User.GetUserByIdAsync(id);

            if (userToUpdate == null)
            {
                return NotFound("The user you are trying to edit does not exist.");
            }

            await Repository.User.UpdateUserAsync(userToUpdate, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await Repository.User.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User with this id does not exist.");
            }
            await Repository.User.DeleteUserAsync(user);
            return NoContent();
        }

    }
}
