namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			IEnumerable<ImportGameDto> gamesDto = JsonConvert
				.DeserializeObject<IEnumerable<ImportGameDto>>(jsonString);

            foreach (var game in gamesDto)
            {
                if (!IsValid(game) || game.Tags.Count() == 0)
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				Genre genre = context.Genres.FirstOrDefault(x => x.Name == game.Genre)
					?? new Genre { Name = game.Genre };

				Developer developer = context.Developers.FirstOrDefault(x => x.Name == game.Developer)
					?? new Developer { Name = game.Developer };


				Game newGame = new Game
				{
					Name = game.Name,
					Genre = genre,
					Developer = developer,
					Price = game.Price,
					ReleaseDate = game.ReleaseDate.Value
				};

				foreach (var tag in game.Tags)
				{
					Tag newTag = context.Tags.FirstOrDefault(x => x.Name == tag)
						?? new Tag { Name = tag };
					newGame.GameTags.Add(new GameTag { Tag = newTag });
				}

				context.Games.Add(newGame);

				context.SaveChanges();
				sb.AppendLine($"Added {game.Name} ({game.Genre}) with {game.Tags.Count()} tags");
			}
			return sb.ToString();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			return "TODO";
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			return "TODO";
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}