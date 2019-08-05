using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Users.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public UserDto Model { get; set; }

    }
}
