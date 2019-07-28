using AutoMapper;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly IMapper Mapper;
        public UserRepository(RepositoryContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            Mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await GetAll().OrderBy(x => x.UserId).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await GetByCondition(x => x.UserId.Equals(userId))
                //.DefaultIfEmpty(new User())
                .FirstOrDefaultAsync();
        }
        public async Task AddUserAsync(User user)
        {
            Add(user);
            await SaveAsync();
        }

        public async Task UpdateUserAsync(User dbUser, UserDto newUser)
        {
            var mappedUser = Mapper.Map<User>(newUser);
            mappedUser.UserId = dbUser.UserId;
            mappedUser.CreatedAt = dbUser.CreatedAt;
            mappedUser.UpdatedAt = DateTime.Now;
            Update(mappedUser);
            await SaveAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            Delete(user);
            await SaveAsync();
        }
    }
}
