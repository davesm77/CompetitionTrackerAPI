using CompetitionTrackerAPI.Models;
using CompetitionTrackerAPI.Interfaces;

using CompetitionTrackerAPI.Data;
using Microsoft.AspNetCore.Mvc;
using CompetitionTrackerAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CompetitionTrackerAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly CompetitionDbContext _context;

        public QuestionService(CompetitionDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionDto>> GetAllQuestionsAsync()
        {
            return await _context.Questions.Select(
                u => new QuestionDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Text = u.Text,
                    Score = u.Score
                }).ToListAsync();
        }

        public async Task<QuestionDto?> GetQuestionByIdAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if(question == null) return null;

            return new QuestionDto
            {
                Id = question.Id,
                Name = question.Name,
                Text = question.Text,
                Score = question.Score
            };
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionDto dto)
        {
            var question = new Question{
                Name = dto.Name,
                Text = dto.Text,
                Score = dto.Score
            };
            
            _context.Questions.Add(question);

            await _context.SaveChangesAsync();

            return new QuestionDto
            {
                Id = question.Id,
                Name = question.Name,
                Text = question.Text,
                Score = question.Score
            };
        }
    }
}