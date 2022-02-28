using EF2G.Repository.Entities;
using EF2G.Repository.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EF2G.Repository.Repos
{
    public class Repository : IRepository
    {
        private readonly EF2GDbContext dbContext;

        public Repository(EF2GDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task CreateUserAsync(DbUser newUser)
        {
            throw new System.NotImplementedException();
        }

        public async Task<DbUser> GetUserAsync(int userId)
        {
            var dbUser = await dbContext.Users
                .SingleOrDefaultAsync(x => x.UserId == userId);

            return dbUser;
        }

        public async Task<DbUser[]> GetUsersAsync()
        {
            var dbUsers = await dbContext.Users
                .ToArrayAsync();

            return dbUsers;
        }

        public Task RemoveUserAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUserAsync(DbUser updatedUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
