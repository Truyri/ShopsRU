using Microsoft.EntityFrameworkCore;
using ShopRU.Domain.Enums;
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
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
            modelBuilder.Entity<UserEntity>().Property(u => u.Id).ValueGeneratedNever();
            modelBuilder.Entity<UserEntity>().Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<UserEntity>().Property(u => u.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<UserEntity>().Property(u => u.UserType).IsRequired();

            //SeedAsync(this).Wait();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ShopRUDatabase");
        }
        
        public DbSet<UserEntity> Users { get; set; }

        // public  static async Task SeedAsync(ApplicationDbContext applicationDbContext)
        // {
        //
        //         var users = new List<UserEntity>
        //         {
        //             new UserEntity
        //             {
        //                 Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bb"),
        //                 FirstName = "John",
        //                 LastName = "Doe",
        //                 UserType = UserTypes.Employee,
        //             },
        //             new UserEntity
        //             {
        //                 Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bc"),
        //                 FirstName = "Matt",
        //                 LastName = "Terrence",
        //                 UserType = UserTypes.Affiliate,
        //             },
        //             new UserEntity
        //             {
        //                 Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bd"),
        //                 FirstName = "Marc",
        //                 LastName = "Raiden",
        //                 UserType = UserTypes.Customer,
        //             }
        //         };
        //         
        //         applicationDbContext.Users.AddRange(users);
        //         await applicationDbContext.SaveChangesAsync();
        //     
        // }
    }
}
