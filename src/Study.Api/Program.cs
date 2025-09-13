 HEAD
// HEAD
using Study.Infrastructure;
using Study.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

origin/main
using Study.Application;
using Study.Infrastructure;
using Study.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Services
 HEAD
 0a4fac79134d8f05b5d2c7d493768e3a8d086c99

origin/main
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

HEAD
//HEAD
// Application & Infrastructure layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// CORS för frontend (Vite kör på http://localhost:5173)
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("frontend", p =>
        p.WithOrigins("http://localhost:5173")
         .AllowAnyHeader()
         .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("frontend");

app.UseAuthorization();


origin/main
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
 HEAD
0a4fac79134d8f05b5d2c7d493768e3a8d086c99
origin/main

app.MapControllers();

app.Run();
