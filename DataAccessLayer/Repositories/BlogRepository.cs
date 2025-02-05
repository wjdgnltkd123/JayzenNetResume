using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class BlogRepository : Repository<BlogPost>, IBlogPostRepository
    {
        private readonly JayzenContext _context;
        public BlogRepository(JayzenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPost>> GetPostByTagAsync(string tag)
        {
            var blogPostTag = await _context.BlogPostTags
                .Include(x => x.Post)
                .Include(x => x.Tag)
                .Where(x => x.Tag.Name == tag)
                .ToListAsync();

            return await _context.BlogPosts
                .Include(x => x.BlogPostTags)
                .Where(x => blogPostTag.Select(y => y.PostId).Contains(x.Id))
                .ToListAsync();
        }
    }
}
