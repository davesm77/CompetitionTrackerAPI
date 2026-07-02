namespace CompetitionTrackerAPI.DTOs;

public class QuestionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Text { get; set; } = "";
    public int Score { get; set; }
}