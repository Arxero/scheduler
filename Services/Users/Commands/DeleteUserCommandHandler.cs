using AutoMapper;
using Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private IRepositoryWrapper Repository;
        private readonly IMapper Mapper;

        public DeleteUserCommandHandler(IRepositoryWrapper repositoryBase, IMapper mapper)
        {
            Repository = repositoryBase;
            Mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await Repository.User.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
