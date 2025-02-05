using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class BlogPostResponseDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public required ICollection<string> BlogPostTags { get; set; }

        public required ICollection<CommentResponseDto> Comments { get; set; }
    }
}
