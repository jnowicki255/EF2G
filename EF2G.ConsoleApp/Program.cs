using System;
using EF2G.Repository;
using EF2G.Repository.Repos;

namespace EF2G.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new EF2GDbContext();

            Repository.Repos.Repository repository 
                = new Repository.Repos.Repository(dbContext);

            var users = repository.GetUsersAsync().Result;

            foreach(var user in users)
            {
                Console.WriteLine($"{user.Username}, {user.FirstName}, {user.LastName}");
            }
        }
    }
}
