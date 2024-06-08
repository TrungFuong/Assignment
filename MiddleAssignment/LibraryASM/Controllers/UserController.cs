using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using LibraryASM;
using LibraryASM.Services;
using Library.DTOs;
using System.Net;

namespace LibraryASM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if(users == null)
            {
                return NotFound();
            }
                return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<ResponseUserDTO>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(Guid userId, RequestUserDTO requestUserDTO)
        {
            await _userService.UpdateUserAsync(userId, requestUserDTO);
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddUserAsync(RequestUserDTO requestUserDTO)
        {
            var createdUser = await _userService.AddUserAsync(requestUserDTO);
            return CreatedAtAction(nameof(GetUserById), new { userId = createdUser.UserId }, createdUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var currentUser = await _userService.GetUserByIdAsync(userId);
            if (currentUser == null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(userId);
            return NoContent();
        }
    }
}
