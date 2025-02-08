using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class BlogPostRequestDto
    {
        public long Id { get; set; }
        public required string Email { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required ICollection<TagDto> BlogPostTags { get; set; }
    }
}
