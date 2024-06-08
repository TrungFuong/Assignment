using Library.Models;

namespace LibraryASM.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(Guid userId, User user);
        Task DeleteUserAsync(Guid userId);
    }
}
