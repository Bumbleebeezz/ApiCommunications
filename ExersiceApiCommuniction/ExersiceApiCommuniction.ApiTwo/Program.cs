using ExersiceApiCommuniction.ApiOne.Endpoints.Animals;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("apiOne", client => client.BaseAddress = new Uri("http://localhost:5246"));

var app = builder.Build();



app.MapGet("/", () => "API Two calls Api One");

app.MapGet("/callApiOne", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("apiOne");
    var respons = await client.GetAsync("/");
    return await respons.Content.ReadAsStringAsync();
});

app.Run();
