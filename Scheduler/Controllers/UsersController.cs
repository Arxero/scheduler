using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Users;
using Services.Users.Commands;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scheduler.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private IRepositoryWrapper Repository;
        private readonly IMapper Mapper;

        public UsersController(IRepositoryWrapper repositoryBase, IMapper mapper)
        {
            Repository = repositoryBase;
            Mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] Paging paging = null)
        {
            var query = new GetAllUsersQuery
            {
                Paging = paging
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetUserByIdQuery
            {
                Id = id
            };        
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto model)
        {
            var command = new CreateUserCommand
            {
                Model = model
            };
            var theUser = await Mediator.Send(command);
            return theUser;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto model)
        {
            var command = new UpdateUserCommand
            {
                Model = model
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }

    }
}
