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

        public async Task CreateUserAsync(DbUser newUser)
        {
            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();
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

        public async Task RemoveUserAsync(int userId)
        {
            var dbUser = await dbContext.Users
                .SingleOrDefaultAsync(x => x.UserId == userId);

            dbContext.Users.Remove(dbUser);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(DbUser updatedUser)
        {
            var dbUser = await dbContext.Users
                .SingleOrDefaultAsync(x => x.UserId == updatedUser.UserId);

            if (await dbContext.Users.AnyAsync(x => x.Username == updatedUser.Username
                && x.UserId != updatedUser.UserId))
                throw new System.Exception(
                    $"User with username {updatedUser.Username} already exists");

            dbContext.Entry(dbUser).CurrentValues.SetValues(updatedUser);
            dbUser.ModifyDate = System.DateTime.UtcNow;
            await dbContext.SaveChangesAsync();
        }
    }
}
