namespace CompetitionTrackerAPI.Models;

public class User
{
    public int Id { get; private set; } // tady musim poresit unikatnost a bezpecnost
    public UserRole Role { get; set; }
    public string Name {get; set;} = "";
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}