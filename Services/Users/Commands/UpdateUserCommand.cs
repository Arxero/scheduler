using Entities.Models;
using MediatR;

namespace Services.Users.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public UserDto Model { get; set; }
        public int Id { get; set; }

    }
}
