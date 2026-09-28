var builder = WebApplication.CreateBuilder(args);

// Add services if needed in future
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Root endpoint: Hello World
app.MapGet("/", () => Results.Ok(new
{
    Message = "Hello World from .NET running on Azure App Service!",
    Status = "Healthy",
    Timestamp = DateTime.UtcNow
}));

// Simple health-check endpoint
app.MapGet("/health", () => Results.Ok("OK"));

app.Run();

// Required for integration testing if using WebApplicationFactory
public partial class Program { }
