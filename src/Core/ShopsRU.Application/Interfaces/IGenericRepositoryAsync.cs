using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class 
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetById(Guid id);

        Task<T> AddAsync(T entity);
    }
}
