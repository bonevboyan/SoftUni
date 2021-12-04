namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.ToList()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = x.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Select(t => new
                        {
                            t.Price,
                            t.RowNumber
                        })
                        .OrderByDescending(x => x.Price)
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToList();



            return JsonConvert.SerializeObject(theatres, Formatting.Indented); ;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays.ToList()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = $"{(p.Rating == 0 ? "Premier" : $"{p.Rating}")}",
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(c => c.IsMainCharacter).Select(c => new ExportActorDto
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    })
                    .OrderByDescending(c => c.FullName)
                    .ToList()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();



            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportPlayDto[]),
                    new XmlRootAttribute("Plays"));
            var sw = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, plays, ns);
            return sw.ToString();
        }
    }
}
