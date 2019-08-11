using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User, int>
    {
        //Task<List<User>> GetAllUsersAsync();
        //Task<User> GetUserByIdAsync(int id);
        //Task AddUserAsync(User user);
        //Task UpdateUserAsync(UserDto user);
        //Task DeleteUserAsync(User user);

        //SchedulerContext UsersContext();
    }
}
