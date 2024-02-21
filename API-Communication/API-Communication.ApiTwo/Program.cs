var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API Two!");

app.Run();
