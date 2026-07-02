namespace CompetitionTrackerAPI.Models;

public class Answer
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;
    public string Text { get; set; } = "";
    public bool IsCorrect { get; set; }
    public int Score { get; set; } = 0;
}