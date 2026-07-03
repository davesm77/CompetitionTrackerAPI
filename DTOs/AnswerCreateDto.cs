namespace CompetitionTrackerAPI.DTOs;

public class AnswerCreateDto
{
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; } = "";
}