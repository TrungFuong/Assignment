using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryASM.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryASMDBContext _context;
        public UserRepository(LibraryASMDBContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var currentUser = await _context.Users.FindAsync(userId);
            if (currentUser != null)
            {
                _context.Users.Remove(currentUser);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task UpdateUserAsync(Guid userId, User user)
        {
            var currentUser = await GetUserByIdAsync(userId);
            if (currentUser != null)
            {

                _context.Update(currentUser);
                _context.SaveChangesAsync();
            }
        }
    }
}
