using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces
{
    public interface IUserRepositoryAsync<T>  : IGenericRepositoryAsync<T> where T : UserEntity
    {
        
    }
}
