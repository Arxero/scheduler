
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private IRepositoryWrapper Repository;
        private readonly IMapper Mapper;

        public GetUserByIdQueryHandler (IRepositoryWrapper repositoryBase, IMapper mapper)
        {
            Repository = repositoryBase;
            Mapper = mapper;
        }

        public async Task<UserDto> Handle (GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await Repository.User.GetByIdAsync(request.Id);
            var mappedUser = Mapper.Map<UserDto>(user);
            return mappedUser;
        }
    }
}
