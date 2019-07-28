using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public UsersController(IRepositoryWrapper repositoryBase)
        {
            Repository = repositoryBase;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await Repository.User.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            User user = await Repository.User.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User with this id does not exist");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is empty.");
            }

            await Repository.User.AddUserAsync(user);
            //Repository.Save();
            return CreatedAtRoute("Get", new { Id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is empty.");
            }
            User userToUpdate = await Repository.User.GetUserByIdAsync(id);

            if (userToUpdate == null)
            {
                return NotFound("The user you are trying to edit does not exist.");
            }

            await Repository.User.UpdateUserAsync(userToUpdate, user);
            //Repository.Save();
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
            //Repository.Save();
            return NoContent();
        }

    }
}
