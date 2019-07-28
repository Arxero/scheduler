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
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
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

        public async Task UpdateUserAsync(User dbUser, User newUser)
        {
            dbUser.Username = newUser.Username;
            dbUser.FirstName = newUser.FirstName;
            dbUser.LastName = newUser.LastName;
            dbUser.PhoneNumber = newUser.PhoneNumber;
            dbUser.Email = newUser.Email;
            dbUser.UpdatedAt = DateTime.Now;
            dbUser.Gender = newUser.Gender;
            Update(dbUser);
            await SaveAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            Delete(user);
            await SaveAsync();
        }
    }
}
