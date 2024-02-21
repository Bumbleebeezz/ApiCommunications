using ExersiceApiCommuniction.ApiOne.Endpoints.SayGoodbye;
using FastEndpoints;

namespace ExersiceApiCommuniction.ApiOne.Endpoints.Animals;

public class AnimalsHandler : Endpoint<EmptyRequest, AnimalsRespons>
{
    public override void Configure()
    {
        Get("/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        SendAsync(new AnimalsRespons() { AnimalText = "Mjau"}, cancellation: ct);
    }
}