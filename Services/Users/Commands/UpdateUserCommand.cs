using Entities.Models;
using MediatR;

namespace Services.Users.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UserDto Model { get; set; }

    }
}
