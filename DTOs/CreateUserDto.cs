using CompetitionTrackerAPI.Models;

namespace CompetitionTrackerAPI.DTOs;

public class CreateUserDto
{
    public string Name { get; set; } = "";
    public UserRole Role { get; set; }
}