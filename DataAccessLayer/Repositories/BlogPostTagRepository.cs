using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class BlogPostTagRepository : Repository<BlogPostTag>, IBlogPostTagRepository
    {
        private readonly JayzenContext _context;
        public BlogPostTagRepository(JayzenContext context) : base(context)
        {
            _context = context;
        }
    }
}
