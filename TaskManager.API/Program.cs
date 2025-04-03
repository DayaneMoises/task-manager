using Microsoft.Extensions.Options;
using TaskManager.API.Data.Configurations;
using TaskManager.API.Data.Repositories;
using TaskManager.API.Services; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(option => option.LowercaseUrls = true);

// Configurar o DatabaseConfig
builder.Services.Configure<DatabaseConfig>(
    builder.Configuration.GetSection(nameof(DatabaseConfig))
);
builder.Services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);

// Injeção de dependência do repositório e serviço
builder.Services.AddSingleton<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<TaskService>(); 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
