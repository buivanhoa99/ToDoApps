using Microsoft.EntityFrameworkCore;
using ToDoApps.Core.Abstract.Repositories;
using ToDoApps.Core.Abstract.Services;
using ToDoApps.Core.Context;
using ToDoApps.Infrastructure.Repositories;
using ToDoApps.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddScoped<IToDoTaskService, ToDoTaskService>();
builder.Services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoAppsContext>(options =>
    options.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=buivanhoa99_;User Id=buivanhoa99_;Password=KUrB66Xp@eN@pMv;"));
var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
