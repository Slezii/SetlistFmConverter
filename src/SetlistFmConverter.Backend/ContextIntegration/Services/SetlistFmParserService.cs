using HtmlAgilityPack;
using SetlistFmConverter.Backend.Infrastructure.Base;
using SetlistFmConverter.Backend.Interfaces.Services;
using SetlistFmConverter.Backend.Models.Songs;

namespace SetlistFmConverter.Backend.ContextIntegration.Services;

public class SetlistFmParserService : BaseService, ISetlistFmParserService
{
    public async Task<IEnumerable<TrackDto>> GetTracksFromUrl(string url)
    {
        var tracks = new List<TrackDto>();
        var web = new HtmlWeb();
        var doc = await web.LoadFromWebAsync(url);

        var songContainers = doc.DocumentNode.SelectNodes("//div[contains(@class, 'songPart')]");
        
        if (songContainers != null)
        {
            foreach (var container in songContainers)
            {
                var songNode = container.SelectSingleNode(".//a[@class='songLabel']");
                var coverNode = container.SelectSingleNode(".//span[@class='songCover']");

                if (songNode != null)
                {
                    var track = new TrackDto(
                        coverNode != null
                            ? coverNode.InnerText.Trim().TrimStart('(').TrimEnd(')')
                            : doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'setlistHeadline')]//a")?.InnerText.Trim() ?? "Unknown Artist",
                        songNode.InnerText.Trim());
                    tracks.Add(track);
                };
            }
        }
        return tracks;
    }
}