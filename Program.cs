using AS_OOP_RacingTeams.Data.Context;
using AS_OOP_RacingTeams.Data.Repositories;
using AS_OOP_RacingTeams.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    // x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")) // SqLite
    x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")) // Postgress
);


// Repositories 

builder.Services.AddScoped<IJobRepository, JobRepository>();

builder.Services.AddScoped<ISponsorShipRepository, SponsorShipRepository>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
