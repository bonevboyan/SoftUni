namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(
                typeof(ImportPlaysDto[]),
                new XmlRootAttribute("Plays"));
            var plays  =
                (ImportPlaysDto[])xmlSerializer.Deserialize(
                    new StringReader(xmlString));

            foreach (var playDto in plays)
            {
                bool canBeParsed = TimeSpan.TryParse(playDto.Duration, out TimeSpan timeSpan);

                var canParse = Enum.TryParse(typeof(Genre), playDto.Genre, out var genre);

                if (!IsValid(playDto) || timeSpan.TotalSeconds < 3600 || !canParse)
                {
                    output.AppendLine("Invalid data!");
                    continue;
                }

                Play play = new Play
                {
                    Title = playDto.Title,
                    Duration = timeSpan,
                    Rating = playDto.Rating,
                    Genre = (Genre) genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                context.Plays.Add(play);

                output.AppendLine($"Successfully imported {play.Title} with genre {play.Genre} and a rating of {play.Rating}!");
                
            }

            context.SaveChanges();

            return output.ToString();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(
                typeof(ImportCastDto[]),
                new XmlRootAttribute("Casts"));
            var casts =
                (ImportCastDto[])xmlSerializer.Deserialize(
                    new StringReader(xmlString));

            foreach (var castDto in casts)
            {
                if (!IsValid(castDto))
                {
                    output.AppendLine("Invalid data!");
                    continue;
                }

                Cast cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };
                context.Casts.Add(cast);
                output.AppendLine($"Successfully imported actor {cast.FullName} as a {(cast.IsMainCharacter == true ? "main" : "lesser")} character!");
            }

            context.SaveChanges();

            return output.ToString();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var output = new StringBuilder();

            var theaterDtos = JsonConvert
                .DeserializeObject<IEnumerable<ImportTheaterDto>>(jsonString);


            foreach (var theaterDto in theaterDtos)
            {
                if (!IsValid(theaterDto))
                {
                    output.AppendLine("Invalid data!");
                    continue;
                }

                Theatre theatre = new Theatre
                {
                    Name = theaterDto.Name,
                    NumberOfHalls = theaterDto.NumberOfHalls,
                    Director = theaterDto.Director
                };

                foreach (var ticketDto in theaterDto.Tickets)
                {
                    if (IsValid(ticketDto)
                        && context.Plays.Any(p => p.Id == ticketDto.PlayId))
                    {

                        var newTicket = new Ticket
                        {
                            Price = ticketDto.Price,
                            RowNumber = ticketDto.RowNumber,
                            PlayId = ticketDto.PlayId,
                            Theatre = theatre

                        };
                        theatre.Tickets.Add(newTicket);
                    }
                    else
                    {
                        output.AppendLine("Invalid data!");
                    }

                }

                context.Theatres.Add(theatre);
                context.SaveChanges();

                output.AppendLine($"Successfully imported theatre {theatre.Name} with #{theatre.Tickets.Count()} tickets!");
            }

            context.SaveChanges();

            return output.ToString();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
