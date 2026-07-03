using CompetitionTrackerAPI.DTOs;
using CompetitionTrackerAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var questions = await _service.GetAllQuestionsAsync();

            return Ok(questions);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await _service.GetQuestionByIdAsync(id);

            if (question == null) return NotFound();

            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionDto dto)
        {
            var createdQuestion = await _service.CreateQuestionAsync(dto);

            return CreatedAtAction(
                nameof(GetQuestion),
                new {id = createdQuestion.Id},
                createdQuestion
            );
        }
    }

}