using BusinessLayer.DTOs;

namespace BusinessLayer.Services
{
    public interface IUserService
    {
        Task AddAsync(UserRegisterDto registerDto);
        Task<UserResponseDto?> GetByEmailAsync(string email);
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
    }
}