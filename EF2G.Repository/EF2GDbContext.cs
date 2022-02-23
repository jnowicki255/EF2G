using EF2G.Repository.Entities;
using EF2G.Repository.Settings;
using EF2G.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;

namespace EF2G.Repository
{
    public class EF2GDbContext : DbContext
    {
        public EF2GDbContext()
        { }

        public EF2GDbContext(ISqlDbSettings connSettings)
            : base(new DbContextOptionsBuilder<EF2GDbContext>()
                  .UseSqlServer(connSettings.ConnectionString).Options)
        { }

        public EF2GDbContext(DbContextOptions<EF2GDbContext> options)
            : base(options)
        { }

        public virtual DbSet<DbUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("globalSettings.json")
                    .Build();

                var dbSettings = configuration.GetSection(SettingsSections.Sql).Get<SqlDbSettings>();

                //optionsBuilder.UseSqlServer(dbSettings.ConnectionString);
                optionsBuilder.UseMySql(dbSettings.ConnectionString, ServerVersion.AutoDetect(dbSettings.ConnectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            //modelBuilder.Entity<DbUser>(entity =>
            //{
            //    entity.Property(e => e.InsertDate).HasPrecision(3);
            //    entity.Property(e => e.ModifyDate).HasPrecision(3);
            //    entity.Property(e => e.LastLoginDate).HasPrecision(3);
            //    entity.Property(e => e.ExpirationDate).HasPrecision(3);
            //});
        }
    }
}
