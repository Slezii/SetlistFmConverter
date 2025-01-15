namespace SetlistFmConverter.Backend.Endpoints;

public static class SetlistEndpoints
{
    public static WebApplication CreateEndpoints(this WebApplication app)
    {
        app.MapGet("/playlist", () =>
            {
                return Results.Ok("Playlist");
            })
            .WithName("GetPlaylist");

        return app;
    }
}