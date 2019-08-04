
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Users
{
    public class GetAllUsersQuery: IRequest<PagedResult<UserDto>>
    {
        public Paging Paging { get; set; }
    }
}
