using CompetitionTrackerAPI.Models;
using CompetitionTrackerAPI.Interfaces;
using CompetitionTrackerAPI.Data;
using CompetitionTrackerAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CompetitionTrackerAPI.Services
{
    public class UserService : IUserService
    {
        private readonly CompetitionDbContext _context;

        public UserService(CompetitionDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> GetAllUsersAsync() //co se stane kdyz tam nebude nic?
        {
            return await _context.Users.Select(u => new UserDto
                {
                Id = u.Id,
                Name = u.Name
                })
                .ToListAsync();
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        public async Task<UserDetailDto> CreateUserAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Role = dto.Role
            };
            
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return new UserDetailDto
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}