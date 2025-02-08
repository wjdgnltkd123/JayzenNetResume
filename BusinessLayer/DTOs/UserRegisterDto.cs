using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs
{
    public class UserRegisterDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string SimpleIntroduce { get; set; }
        public required string ProfileImage { get; set; }
    }
}