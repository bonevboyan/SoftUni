namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

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
			StringBuilder sb = new StringBuilder();

			IEnumerable<ImportUserDto> usersDto = JsonConvert
				.DeserializeObject<IEnumerable<ImportUserDto>>(jsonString);

			foreach (var user in usersDto)
			{
				if (!IsValid(user) || !user.Cards.All(IsValid))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				User newUser = new User
				{
					Age = user.Age,
					Email = user.Email,
					FullName = user.FullName,
					Username = user.Username,
					Cards = user.Cards.Select(c => new Card
					{
						Cvc = c.CVC,
						Number = c.Number,
						Type = c.Type.Value
					}).ToList()
				};

				context.Users.Add(newUser);
				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
			}

			context.SaveChanges();
			return sb.ToString();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var output = new StringBuilder();
			var xmlSerializer = new XmlSerializer(
				typeof(ImportPurchaseDto[]),
				new XmlRootAttribute("Purchases"));
			var purchases =
				(ImportPurchaseDto[])xmlSerializer.Deserialize(
					new StringReader(xmlString));
			foreach (var xmlPurchase in purchases)
			{
				if (!IsValid(xmlPurchase))
				{
					output.AppendLine("Invalid Data");
					continue;
				}

				bool parsedDate = DateTime.TryParseExact(
					xmlPurchase.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);
				if (!parsedDate)
				{
					output.AppendLine("Invalid Data");
					continue;
				}

				var purchase = new Purchase
				{
					Date = date,
					Type = xmlPurchase.Type.Value,
					ProductKey = xmlPurchase.Key,
					Card = context.Cards.FirstOrDefault(x => x.Number == xmlPurchase.Card),
					Game = context.Games.FirstOrDefault(x => x.Name == xmlPurchase.GameName),
				};
				context.Purchases.Add(purchase);

				var username = context.Users.Where(x => x.Id == purchase.Card.UserId)
					.Select(x => x.Username).FirstOrDefault();
				output.AppendLine($"Imported {xmlPurchase.GameName} for {username}");
			}

			context.SaveChanges();
			return output.ToString();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}