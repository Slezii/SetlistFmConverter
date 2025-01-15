using SetlistFmConverter.Backend.Models.Playlist;
using SetlistFmConverter.Backend.Models.Songs;

namespace SetlistFmConverter.Backend.Interfaces.Services;

public interface ISpotifyService
{
    PlaylistDto GetPlaylist(IEnumerable<TrackDto> songs);
}