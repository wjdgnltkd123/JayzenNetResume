using BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostResponseDto>> GetAllAsync();
        Task<BlogPostResponseDto?> GetByIdAsync(long id);
        Task<IEnumerable<BlogPostResponseDto>> GetBlogPostByTag(string tag);
        Task AddAsync(BlogPostRequestDto blogPost);
        Task UpdateAsync(BlogPostRequestDto blogPost);
        Task DeleteAsync(long id);
    }
}
