using CompetitionTrackerAPI.DTOs;

namespace CompetitionTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAllUsersAsync();
        public Task<UserDto?> GetUserByIdAsync(int id);

        public Task<UserDetailDto> CreateUserAsync(CreateUserDto user);

    }
}