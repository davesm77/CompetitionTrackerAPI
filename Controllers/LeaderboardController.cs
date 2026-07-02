using CompetitionTrackerAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private ILeaderboardService _service;

        public LeaderboardController(ILeaderboardService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderboard()
        {
            var leaderboard = await _service.GetTotalScoresAsync();

            return Ok(leaderboard);
        }
    }
}