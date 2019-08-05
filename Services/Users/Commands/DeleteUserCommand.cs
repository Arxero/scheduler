using MediatR;

namespace Services.Users.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }

    }
}
