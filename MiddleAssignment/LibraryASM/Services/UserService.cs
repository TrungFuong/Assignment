using Exceptions;
using Library.DTOs;
using Library.Models;
using LibraryASM.Repositories;
using System.Net;

namespace LibraryASM.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ResponseUserDTO> AddUserAsync(RequestUserDTO requestUserDTO)
        {
            //DIDN'T THINK OF REGISTER FUNCTION
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResponseUserDTO>> GetAllUsersAsync()
        {
            var users = await  _userRepository.GetAllUsersAsync();
            if (users == null)
            {
                throw new NotFoundException();
            }
            var responseUsers = users.Select(u => new ResponseUserDTO
            {
               UserId = u.UserId,
               UserName = u.UserName,
               UserEmail = u.UserEmail,
               UserPhone = u.UserPhone,
               UserRole = u.Role,
            }).ToList();
            return responseUsers;
        }

        public async Task<ResponseUserDTO> GetUserByIdAsync(Guid userId)
        {
            var currentUser = await _userRepository.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                throw new NotFoundException();
            }
            return new ResponseUserDTO
            {
                UserId = userId,
                UserName = currentUser.UserName,
                UserEmail = currentUser.UserEmail,
                UserPhone = currentUser.UserPhone,
                UserRole = currentUser.Role
            };
        }

        public async Task UpdateUserAsync(Guid userId, RequestUserDTO requestUserDTO)
        {
            var currentUser = await _userRepository.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                throw new NotFoundException();
            }
            currentUser.UserName = requestUserDTO.UserName;
            currentUser.UserEmail = requestUserDTO.UserEmail;
            currentUser.UserPhone = requestUserDTO.UserPhone;

            await _userRepository.UpdateUserAsync(userId, currentUser);
        }
    }
}
