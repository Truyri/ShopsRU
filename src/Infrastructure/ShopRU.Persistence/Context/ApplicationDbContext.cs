using Microsoft.EntityFrameworkCore;
using ShopRU.Domain.Enums;
using ShopRU.Persistence.EntitySeeders;
using ShopsRU.Domain.Common;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bb"),
                FirstName = "John",
                LastName = "Doe",
                UserType = UserTypes.Employee,
            });

            await dbContext.SaveChangesAsync();

            base.OnModelCreating(modelBuilder);

        }
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new SeedUserData());

        //    base.OnModelCreating(modelBuilder);
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("exampleDatabase");
        //}

    }
}
