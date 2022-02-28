using EF2G.Repository.Entities;
using System.Threading.Tasks;

namespace EF2G.Repository.Repos.Interfaces
{
    public interface IUserRepository
    {
        Task<DbUser> GetUserAsync(int userId);
        Task<DbUser[]> GetUsersAsync();
        Task CreateUserAsync(DbUser newUser);
        Task UpdateUserAsync(DbUser updatedUser);
        Task RemoveUserAsync(int userId);
    }
}
