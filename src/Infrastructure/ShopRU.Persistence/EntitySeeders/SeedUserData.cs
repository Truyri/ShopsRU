using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopRU.Domain.Enums;
using ShopsRU.Domain.Common;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Persistence.EntitySeeders
{
    public class SeedUserData : IEntityTypeConfiguration<UserEntity>, IDisposable 
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasData(
                new UserEntity
                {
                    Id = Guid.Parse("b34d5b8f-9a68-4b2a-b437-648c8d7341bb"),
                    FirstName = "John",
                    LastName = "Doe",
                    UserType = UserTypes.Employee,
                }
                );
        }
    }
}
