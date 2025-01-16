using SetlistFmConverter.Backend.Infrastructure.Base;
using SetlistFmConverter.Backend.Models.Songs;

namespace SetlistFmConverter.Backend.Interfaces.Services;

public interface ISetlistFmParserService : IBaseService
{
    Task<IEnumerable<TrackDto>> GetTracksFromUrl(string url);
}