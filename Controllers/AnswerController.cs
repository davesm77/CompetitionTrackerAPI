using CompetitionTrackerAPI.DTOs;
using CompetitionTrackerAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _service;

        public AnswerController(IAnswerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnswersToQuestion([FromQuery] int questionId)
        {
            var answers = await _service.GetAnswersByQuestionIdAsync(questionId);

            return Ok(answers);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAnswers()
        {
            var answers = await _service.GetAllAnswersAsync();

            return Ok(answers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAnswer(int id)
        {
            var answer = await _service.GetAnswerByIdAsync(id);

            if (answer == null) return NotFound();

            return Ok(answer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer(AnswerCreateDto dto)
        {
            var createdAnswer = await _service.CreateAnswerAsync(dto);

            return CreatedAtAction(
                nameof(GetAnswer),
                new {id = createdAnswer.Id},
                createdAnswer
            );
        }

        [HttpPatch]
        [Route("mark/{id}")]
        public async Task<IActionResult> EvaluateAnswer(int id, AnswerEvaluationDto dto)
        {
            var evaluatedAnswer = await _service.EvaluateAnswerAsync(id, dto);

            if (evaluatedAnswer == null) return NotFound();

            return Ok(evaluatedAnswer);
        }
    }
}