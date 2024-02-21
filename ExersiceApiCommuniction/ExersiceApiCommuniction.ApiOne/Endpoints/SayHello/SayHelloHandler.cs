using ExersiceApiCommuniction.ApiOne.Endpoints.SayGoodbye;
using FastEndpoints;

namespace ExersiceApiCommuniction.ApiOne.Endpoints.SayHello;

public class SayHelloHandler : Endpoint<EmptyRequest, SayHelloRespons>
{
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        SendAsync(new SayHelloRespons() { ResponsText = "Hello !!! API One"}, cancellation: ct);
    }
}