
using Entities.Models;
using MediatR;

namespace Services.Users
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
