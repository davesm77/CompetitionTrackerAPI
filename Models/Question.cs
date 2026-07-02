namespace CompetitionTrackerAPI.Models;

public class Question
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Text { get; set; } = "";
    public int Score { get; set; }
    // pridat vlastnost pro spravnou odpoved?
    public ICollection<Answer> Answers { get; set; }= new List<Answer>();
}