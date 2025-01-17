using Microsoft.AspNetCore.Mvc;
using SetlistFmConverter.Backend.Interfaces.Services;

namespace SetlistFmConverter.Backend.Endpoints;

public static class SetlistEndpoints
{
    public static WebApplication CreateEndpoints(this WebApplication app)
    {
        app.MapGet("/playlist", async (
                [FromQuery] string? url,
                [FromServices] ISetlistFmParserService setlistFmParserService) =>
            {
                if (url is null) return Results.BadRequest();
                var tracks = await setlistFmParserService.GetTracksFromUrl(url);
                return Results.Ok(tracks);
            })
            .WithName("GetPlaylist");

        return app;
    }
}