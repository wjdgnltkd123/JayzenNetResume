using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLayer.DTOs
{
    public class UserSimplestDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
    }
}
