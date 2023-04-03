using ShopRU.Persistence.Context;
using ShopRU.Persistence.Repositories;
using ShopsRU.Application.Interfaces;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRU.Persistence.Repositories
{
    public class UserRepository<T> : GenericRepository<T>, IUserRepositoryAsync<T> where T : UserEntity
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

         }
    }
}
