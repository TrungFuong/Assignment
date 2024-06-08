using Library.DTOs;

namespace LibraryASM.Services
{
    public interface IUserService
    {
        Task<IEnumerable<ResponseUserDTO>> GetAllUsersAsync();
        Task<ResponseUserDTO> GetUserByIdAsync(Guid userId);
        Task<ResponseUserDTO> AddUserAsync(RequestUserDTO requestUserDTO);
        Task DeleteUserAsync(Guid userId);
        Task UpdateUserAsync(Guid userId, RequestUserDTO requestUserDTO);
    }
}
