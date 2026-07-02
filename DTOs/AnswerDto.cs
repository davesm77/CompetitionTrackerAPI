namespace CompetitionTrackerAPI.DTOs;
public class AnswerDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; } = "";
    public int Score { get; set; } = 0;
    public bool IsCorrect { get; set; } = false;
}