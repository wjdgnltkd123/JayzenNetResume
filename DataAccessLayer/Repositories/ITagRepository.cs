using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag?> GetByNameAsync(string name);
    }
}