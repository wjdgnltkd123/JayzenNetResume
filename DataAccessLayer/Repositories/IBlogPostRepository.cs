using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        Task<IEnumerable<BlogPost>> GetPostByTagAsync(string tag);
    }
}