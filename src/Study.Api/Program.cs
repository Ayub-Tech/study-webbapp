using Study.Application;
using Study.Infrastructure;
using Study.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application & Infrastructure
var conn = builder.Configuration.GetConnectionString("Default") ?? "Data Source=study.db";
builder.Services.AddApplication();
builder.Services.AddInfrastructure(conn);

var app = builder.Build();

// Skapa SQLite-databasen om den saknas
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Swagger alltid på lokalt
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
