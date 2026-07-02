using CompetitionTrackerAPI.DTOs;

namespace CompetitionTrackerAPI.Interfaces
{
    public interface IQuestionService
    {
        public Task<List<QuestionDto>> GetAllQuestionsAsync();

        public Task<QuestionDto?> GetQuestionByIdAsync(int id);

        public Task<QuestionDto> CreateQuestionAsync(QuestionDto dto);
    }  
}