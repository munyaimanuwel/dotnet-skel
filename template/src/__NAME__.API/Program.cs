using __NAMESPACE__.API.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();

app.MapControllers();

app.Run();
