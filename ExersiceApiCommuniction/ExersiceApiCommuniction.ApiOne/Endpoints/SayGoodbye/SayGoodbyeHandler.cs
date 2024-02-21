using FastEndpoints;

namespace ExersiceApiCommuniction.ApiOne.Endpoints.SayGoodbye;

public class SayGoodbyeHandler : Endpoint<EmptyRequest, SayGoodbyeRespons>
{
    public override void Configure()
    {
        Get("/goodbye");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        SendAsync(new SayGoodbyeRespons() { GoodbyeMessage = "Goodbye! API One" }, cancellation:ct);
    }
}