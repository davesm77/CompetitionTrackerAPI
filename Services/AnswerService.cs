using CompetitionTrackerAPI.Models;
using CompetitionTrackerAPI.Interfaces;

using CompetitionTrackerAPI.Data;
using CompetitionTrackerAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CompetitionTrackerAPI.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly CompetitionDbContext _context;

        public AnswerService(CompetitionDbContext context)
        {
            _context = context;
        }

        public async Task<AnswerDto> CreateAnswerAsync(AnswerDto dto)
        {
            var answer = new Answer
            {
                UserId = dto.UserId,
                QuestionId = dto.QuestionId,
                Text = dto.Text
            };

            _context.Answers.Add(answer);

            await _context.SaveChangesAsync();

            return new AnswerDto
            {
                Id = answer.Id,
                UserId = answer.UserId,
                QuestionId = answer.QuestionId,
                Text = answer.Text
            };
        }

        public async Task<AnswerDto?> GetAnswerByIdAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);

            if (answer == null) return null;

            return new AnswerDto
            {
                Id = answer.Id,
                UserId = answer.UserId,
                QuestionId = answer.QuestionId,
                Text = answer.Text,
                IsCorrect = answer.IsCorrect,
                Score = answer.Score
            };
        }

        public async Task<List<AnswerDto>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _context.Answers
            .Where(u => u.QuestionId == questionId)
            .Select(u => new AnswerDto
            {
                Id = u.Id,
                QuestionId = u.QuestionId,
                UserId = u.UserId,
                Text = u.Text,
                IsCorrect = u.IsCorrect,
                Score = u.Score
            }).ToListAsync();
        }

        public async Task<List<AnswerDto>> GetAllAnswersAsync()
        {
            return await _context.Answers
            .Select(u => new AnswerDto
            {
                Id = u.Id,
                QuestionId = u.QuestionId,
                UserId = u.UserId,
                Text = u.Text,
                IsCorrect = u.IsCorrect,
                Score = u.Score
            }).ToListAsync();
        }

        public async Task<AnswerDto?> EvaluateAnswerAsync(int id, AnswerEvaluationDto dto)
        {
            var answer = await _context.Answers.SingleAsync(a => a.Id == id);

            if (answer == null) return null;

            answer.IsCorrect = dto.IsCorrect;
            answer.Score = dto.Score;

            await _context.SaveChangesAsync();

            return new AnswerDto
            {
                Id = answer.Id,
                UserId = answer.UserId,
                QuestionId = answer.QuestionId,
                Text = answer.Text,
                IsCorrect = answer.IsCorrect,
                Score = answer.Score
            };
        }
    }
}