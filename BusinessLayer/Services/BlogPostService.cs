using BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using System.Diagnostics;
using DataAccessLayer.Models;

namespace BusinessLayer.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task AddAsync(BlogPostRequestDto requestBlogPost)
        {
            Debug.Assert(requestBlogPost != null, "BlogPost must not be null");
            Debug.Assert(!string.IsNullOrWhiteSpace(requestBlogPost.Name), "Name must not be null or empty");
            Debug.Assert(!string.IsNullOrWhiteSpace(requestBlogPost.Email), "Email must not be null or empty");
            Debug.Assert(!string.IsNullOrWhiteSpace(requestBlogPost.Title), "Title must not be null or empty");
            Debug.Assert(!string.IsNullOrWhiteSpace(requestBlogPost.Content), "Content must not be null or empty");
            Debug.Assert(requestBlogPost.BlogPostTags != null, "BlogPostTags must not be null");



            //await _blogPostRepository.AddAsync(blogPost);
        }

        public async Task DeleteAsync(long id)
        {
            Debug.Assert(id > 0, "Id must be greater than 0");
            await _blogPostRepository.DeleteAsync(id);
            // check if the blog post exists only in debug
        }

        public Task<IEnumerable<BlogPostResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlogPostResponseDto>> GetBlogPostByTag(string tag)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(tag), "Tag must not be null or empty");
            throw new NotImplementedException();
        }

        public Task<BlogPostResponseDto?> GetByIdAsync(long id)
        {
            Debug.Assert(id > 0, "Id must be greater than 0");
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BlogPostRequestDto blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
