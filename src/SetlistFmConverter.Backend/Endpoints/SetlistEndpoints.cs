using Microsoft.AspNetCore.Mvc;
using SetlistFmConverter.Backend.Interfaces.Services;

namespace SetlistFmConverter.Backend.Endpoints;

public static class SetlistEndpoints
{
    public static WebApplication CreateEndpoints(this WebApplication app)
    {
        app.MapGet("/playlist", (
                [FromQuery] string? url,
                [FromServices] ISetlistFmParserService setlistFmParserService) =>
            {
                return Results.Ok(setlistFmParserService.GetTracksFromUrl(url));
            })
            .WithName("GetPlaylist");

        return app;
    }
}