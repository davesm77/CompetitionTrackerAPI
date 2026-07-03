using CompetitionTrackerAPI.DTOs;
using CompetitionTrackerAPI.Models;

namespace CompetitionTrackerAPI.Interfaces
{
    public interface IAnswerService
    {
        public Task<List<AnswerDto>> GetAnswersByQuestionIdAsync(int Id);
        public Task<AnswerDto> CreateAnswerAsync(AnswerCreateDto dto);
        public Task<AnswerDto?> GetAnswerByIdAsync(int id);
        public Task<List<AnswerDto>> GetAllAnswersAsync();
        public Task<AnswerDto?> EvaluateAnswerAsync(int id, AnswerEvaluationDto dto);
    }
}