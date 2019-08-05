using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private IRepositoryWrapper Repository;
        private readonly IMapper Mapper;

        public CreateUserCommandHandler(IRepositoryWrapper repositoryBase, IMapper mapper)
        {
            Repository = repositoryBase;
            Mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var theUser = await Repository.User.AddAsync(Mapper.Map<User>(request.Model)); // saving db model
            var userToReturn = Mapper.Map<UserDto>(theUser);
            return userToReturn;
        }
    }
}
