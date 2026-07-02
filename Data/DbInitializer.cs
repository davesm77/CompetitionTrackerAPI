using CompetitionTrackerAPI.DTOs;
using CompetitionTrackerAPI.Models;

namespace CompetitionTrackerAPI.Data;
public static class DbInitializer
{
    public static async Task SeedAsync(CompetitionDbContext context)
    {
        Console.WriteLine("Seed start.");
        Console.WriteLine($"Pocet uzivatelu: {context.Users.Count()}");
        
        SeedUsers(context);

        Console.WriteLine("Uzivatele pridani.");

        SeedQuestions(context);

        Console.WriteLine("Otazky pridany.");

        SeedAnswers(context);

        Console.WriteLine("Odpovedi pridany.");

        await context.SaveChangesAsync();

        Console.WriteLine("SaveChanges dokonceno.");
    }

    public static void SeedUsers(CompetitionDbContext context)
    {
        if(context.Users.Any()) return;

        context.Users.AddRange(
            new User
            {
                Name = "Spravce",
                Role = UserRole.Moderator
            },
            new User
            {
                Name = "Karel",
                Role = UserRole.Contestant
            }
        );
    }

    public static void SeedQuestions(CompetitionDbContext context)
    {
        if(context.Questions.Any()) return;

        context.Questions.AddRange(
            new Question
            {
                Name = "Planety",
                Text = "Vyjmenujte největší planetu Sluneční soustavy.",
                Score = 5
            },

            new Question
            {
                Name = "Elektřina",
                Text = "Napište symbol veličiny a jednotku pro elektrický odpor.",
                Score = 5
            }
        );
    }

    public static void SeedAnswers(CompetitionDbContext context)
    {
        if(context.Answers.Any()) return;

        context.Answers.AddRange(
            new Answer
            {
                UserId = 2,
                QuestionId = 1,
                Text = "Pluto",
                IsCorrect = false,
            },

            new Answer
            {
                UserId = 2,
                QuestionId = 2,
                Text = "R a Omega",
                IsCorrect = true,
            }
        );
    }
}