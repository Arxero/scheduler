
using AutoMapper;
using Contracts;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Users
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedResult<UserDto>>
    {
        private IRepositoryWrapper Repository;
        private readonly IMapper Mapper;

        public GetAllUsersQueryHandler(IRepositoryWrapper repositoryBase, IMapper mapper)
        {
            Repository = repositoryBase;
            Mapper = mapper;
        }

        public async Task<PagedResult<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await Repository.User.QueryAsync(request.Paging);
            var mappedUsers = users.Items.Select(x => Mapper.Map<UserDto>(x)).ToList();

            return new PagedResult<UserDto>
            {
                Items = mappedUsers,
                Total = users.Total,
            };
        }
    }
}
