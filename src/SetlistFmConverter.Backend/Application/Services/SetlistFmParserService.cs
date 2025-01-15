using SetlistFmConverter.Backend.Infrastructure.Base;
using SetlistFmConverter.Backend.Interfaces.Services;
using SetlistFmConverter.Backend.Models.Songs;

namespace SetlistFmConverter.Backend.Application.Services;

public class SetlistFmParserService : BaseService, ISetlistFmParserService
{
    public IEnumerable<TrackDto> GetTracksFromUrl(string url)
    {
        return [new TrackDto("artist", "title")];
    }
}