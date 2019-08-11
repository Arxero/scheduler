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
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(SchedulerContext context, DbSet<User> dbset, IMapper mapper) : base(context, dbset)
        {
            Mapper = mapper;
        }

        private readonly IMapper Mapper;

        //public SchedulerContext UsersContext()
        //{
        //    return Context;
        //}

        //public Task DeleteUserAsync(int id)
        //{
        //    var entity = new TEntity();
        //    base.RemoveAsync(theUser);
        //}

        //public Task UpdateUserAsync(UserDto user)
        //{
        //    var theUser = Mapper.Map<User>(user);
        //    base.UpdateAsync(theUser);
        //    Context.SaveChanges();
        //    return Task.CompletedTask;
        //}
    }

    //public class UserRepository : RepositoryBase<User>, IUserRepository
    //{
    //    private readonly IMapper Mapper;
    //    public UserRepository(SchedulerContext repositoryContext, IMapper mapper) : base(repositoryContext)
    //    {
    //        Mapper = mapper;
    //    }

    //    public async Task<IEnumerable<User>> GetAllUsersAsync()
    //    {
    //        return await GetAll().OrderBy(x => x.UserId).ToListAsync();
    //    }

    //    public async Task<User> GetUserByIdAsync(int userId)
    //    {
    //        return await GetByCondition(x => x.UserId.Equals(userId))
    //            //.DefaultIfEmpty(new User())
    //            .FirstOrDefaultAsync();
    //    }
    //    public async Task AddUserAsync(User user)
    //    {
    //        Add(user);
    //        await SaveAsync();
    //    }

    //    public async Task UpdateUserAsync(User dbUser, UserDto newUser)
    //    {
    //        var mappedUser = Mapper.Map<User>(newUser);
    //        mappedUser.UserId = dbUser.UserId;
    //        mappedUser.CreatedAt = dbUser.CreatedAt;
    //        mappedUser.UpdatedAt = DateTime.Now;
    //        Update(mappedUser);
    //        await SaveAsync();
    //    }

    //    public async Task DeleteUserAsync(User user)
    //    {
    //        Delete(user);
    //        await SaveAsync();
    //    }
    //}
}
