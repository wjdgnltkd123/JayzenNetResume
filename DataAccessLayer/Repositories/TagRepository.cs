using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly JayzenContext _context;
        public TagRepository(JayzenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tag?> GetByNameAsync(string name)
        {
            return await _context.Tags.FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}
