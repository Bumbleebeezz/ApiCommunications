var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("apiTwo", client => client.BaseAddress = new Uri("http://localhost:5299"));

var app = builder.Build();

app.MapGet("/", () => "API One!");

app.MapGet("/callApiTwo", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("apiTwo");
    var respons = await client.GetAsync("/");
    return await respons.Content.ReadAsStringAsync();
});

app.Run();
