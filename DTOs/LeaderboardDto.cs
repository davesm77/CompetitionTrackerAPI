namespace CompetitionTrackerAPI.DTOs;

public class LeaderboardDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = "";
    public int TotalScore { get; set; }
}