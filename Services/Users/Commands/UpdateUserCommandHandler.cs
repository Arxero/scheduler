using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Validators;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private IRepositoryWrapper Repository;
        private readonly IMapper Mapper;

        public UpdateUserCommandHandler(IRepositoryWrapper repositoryBase, IMapper mapper)
        {
            Repository = repositoryBase;
            Mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            UserValidator validator = new UserValidator();
            var validatorResults = validator.Validate(request.Model);

            if (validatorResults.IsValid == false)
            {
                throw new ArgumentNullException(nameof(request.Model));
            }

            var entity = await Repository.User.GetByIdAsync(request.Id);
            entity.Username = request.Model.Username;
            entity.FirstName = request.Model.FirstName;
            entity.LastName = request.Model.LastName;
            entity.PhoneNumber = request.Model.PhoneNumber;
            entity.Email = request.Model.Email;
            entity.Gender = request.Model.Gender;

            var theUser = await Repository.User.UpdateAsync(entity);
            return Mapper.Map<UserDto>(theUser);
        }
    }
}
