using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(long id);
        Task<T> UpdateAsync(T entity);
    }
}
