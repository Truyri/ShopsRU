using ShopRU.Domain.Enums;
using ShopsRU.Domain.Entities;
using ShopRU.Persistence.Context;

namespace ShopRU.Persistence.EntitySeeders
{
    public static class UserSeeds 
    {
        public static async Task SeedAsync(ApplicationDbContext applicationDbContext)
        {
            var users = new List<UserEntity>
            {
                new UserEntity
                {
                    Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bb"),
                    FirstName = "John",
                    LastName = "Doe",
                    UserType = UserTypes.Employee,
                },
                new UserEntity
                {
                    Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bc"),
                    FirstName = "Matt",
                    LastName = "Terrence",
                    UserType = UserTypes.Affiliate,
                },
                new UserEntity
                {
                    Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bd"),
                    FirstName = "Marc",
                    LastName = "Raiden",
                    UserType = UserTypes.Customer,
                }
            };

            applicationDbContext.Users.AddRange(users);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}