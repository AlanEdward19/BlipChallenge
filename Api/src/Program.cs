using BlipChallenge.Configurations;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.RegisterServices();
builder.Services.ConfigureEndpoints();

var app = builder.Build();

app.ConfigureSwagger();
app.MapEndpoints(configuration);
app.ConfigureMiddleware();

app.Run();
app.Logger.LogInformation("Application instance is ready to handle incoming requests");