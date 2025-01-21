using SetlistFmConverter.Backend.Infrastructure.Base;
using SetlistFmConverter.Backend.Models.Songs;

namespace SetlistFmConverter.Backend.ContextIntegration.Services;

public interface ISetlistFmParserService : IBaseService
{
    Task<IEnumerable<TrackDto>> GetTracksFromUrl(string url);
}