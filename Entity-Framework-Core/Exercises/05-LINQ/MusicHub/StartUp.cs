using MusicHub.Data;
using System;
using System.Linq;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new MusicHubDbContext();

            ExportAlbumsInfo(context, 9);

            ExportSongsAboveDuration(context, 4);
        }
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Producers
                .FirstOrDefault(p => p.Id == producerId)
                .Albums
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        s.Name,
                        s.Price,
                        WriterName = s.Writer.Name,
                    })
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.WriterName)
                    .ToList(),
                    a.Price,
                })
                .OrderByDescending(a => a.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;

                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return sb.ToString().Trim();
        }
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    SongName = x.Name,
                    WriterName = x.Writer.Name,
                    PerformerFullName = x.SongPerformers
                        .Select(x => x.Performer.FirstName + " " + x.Performer.LastName)
                        .FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    x.Duration
                })
                .OrderBy(song => song.SongName)
                .ThenBy(song => song.WriterName)
                .ThenBy(song => song.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();

            int counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerFullName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration:c}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
