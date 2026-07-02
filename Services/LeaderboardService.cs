using CompetitionTrackerAPI.Models;
using CompetitionTrackerAPI.Interfaces;

using CompetitionTrackerAPI.Data;
using CompetitionTrackerAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CompetitionTrackerAPI.Services
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly CompetitionDbContext _context;

        public LeaderboardService(CompetitionDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaderboardDto>> GetTotalScoresAsync()
        {
            return await _context.Answers
            .Where(a => a.IsCorrect)
            .GroupBy(a => new {
                a.UserId,
                a.User.Name}
                )
            .Select(u => new LeaderboardDto {
                UserId = u.Key.UserId,
                UserName = u.Key.Name,
                TotalScore = u.Sum(a => a.Score)
            }).ToListAsync();
        }
    }
}