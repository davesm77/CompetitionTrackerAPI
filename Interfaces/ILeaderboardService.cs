using CompetitionTrackerAPI.DTOs;

namespace CompetitionTrackerAPI.Interfaces
{
    public interface ILeaderboardService
    {
        public Task<List<LeaderboardDto>> GetTotalScoresAsync();
    }
}