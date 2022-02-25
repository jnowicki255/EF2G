using EF2G.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EF2G.Repository.Seeds
{
    public static partial class DbSeed
    {
        public static void UsersSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>().HasData(
                new DbUser
                {
                    UserId = 1,
                    Username = "tester",
                    Password = "123",
                    Email = "tester@example.com",
                    FirstName = "Test",
                    LastName = "Er",
                    Telephone = "555-666-777",
                    ExpirationDate = null,
                    LastLoginDate = null,
                    InsertDate = new DateTime(2022, 01, 01),
                    ModifyDate = new DateTime(2022, 01, 01)
                },
                new DbUser
                {
                    UserId = 2,
                    Username = "sampleUser",
                    Password = "123",
                    Email = "sampleUser@example.com",
                    FirstName = "Sample",
                    LastName = "User",
                    Telephone = "555-666-777",
                    ExpirationDate = null,
                    LastLoginDate = null,
                    InsertDate = new DateTime(2022, 01, 01),
                    ModifyDate = new DateTime(2022, 01, 01)
                }
                );
        }
    }
}
