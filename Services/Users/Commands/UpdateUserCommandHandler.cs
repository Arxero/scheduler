using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private IRepositoryWrapper Repository;
        private readonly IMapper Mapper;

        public UpdateUserCommandHandler(IRepositoryWrapper repositoryBase, IMapper mapper)
        {
            Repository = repositoryBase;
            Mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await Repository.User.UpdateUserAsync(request.Model);
            return Unit.Value;
        }
    }
}
