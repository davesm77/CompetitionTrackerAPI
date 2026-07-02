using Microsoft.EntityFrameworkCore;

using CompetitionTrackerAPI.Data;
using CompetitionTrackerAPI.Interfaces;
using CompetitionTrackerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CompetitionDbContext>(options => options.UseSqlite("Data Source=competition.db"));

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IQuestionService,QuestionService>();
builder.Services.AddScoped<IAnswerService,AnswerService>();
builder.Services.AddScoped<ILeaderboardService,LeaderboardService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CompetitionDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedAsync(context);
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
