using ExersiceApiCommuniction.ApiOne.Endpoints.Animals;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("animals", client => client.BaseAddress = new Uri("http://localhost:5126"));
builder.Services.AddSingleton<AnimalsHandler>();
builder.Services.AddFastEndpoints();

var app = builder.Build();

//app.MapAnimalEndpoints();

//app.MapGet("/", () => "API Two calls Api One");

//app.MapGet("/callApiTwo", async (IHttpClientFactory clientFactory) =>
//{
//    var client = clientFactory.CreateClient("apiTwo");
//    var respons = await client.GetAsync("/");
//    return await respons.Content.ReadAsStringAsync();
//});
app.MapGet("/callAnimals", async (IHttpClientFactory clientFactory) =>
{
    var client = clientFactory.CreateClient("animals");
    var respons = await client.GetAsync("/");
    return await respons.Content.ReadAsStringAsync();
});

app.UseFastEndpoints();

app.Run();
