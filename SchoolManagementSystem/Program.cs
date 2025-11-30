using SchoolManagementSystem.Configuration;
using SchoolManagementSystem.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.AddSerilog(
    new LoggerConfiguration()
        .WriteTo.File("Logs/SchoolManagmentSystem.txt", rollingInterval: RollingInterval.Day)
        .MinimumLevel.Information()
        .CreateLogger());




builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
