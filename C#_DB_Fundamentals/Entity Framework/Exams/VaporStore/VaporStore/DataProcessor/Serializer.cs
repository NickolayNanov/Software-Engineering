namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDtos;
    using VaporStore.DataProcessor.ImputDtos;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{         
            var games = context
                            .Genres
                            .Where(g => genreNames.Contains(g.Name))
                            .Select(x => new
                            {
                                x.Id,
                                Genre = x.Name,
                                Games = x.Games
                                            .Where(p => p.Purchases.Any())
                                            .Select(g => new
                                            {
                                                g.Id,
                                                Title = g.Name,
                                                Developer = g.Developer.Name,
                                                Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                                                Players = g.Purchases.Count
                                            })
                                            .OrderByDescending(p => p.Players)
                                            .ThenBy(p => p.Id)
                                            .ToArray(),
                                TotalPlayers = x.Games.Sum(p => p.Purchases.Count)
                            })
                            .OrderByDescending(x => x.TotalPlayers)
                            .ThenBy(x => x.Id)
                            .ToArray();

            string json = JsonConvert.SerializeObject(games, Newtonsoft.Json.Formatting.Indented);
            return json;

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            PurchaseType type = Enum.Parse<PurchaseType>(storeType);

            var users = context
                            .Users
                            .Select(x => new ExportUserDto
                            {
                                Username = x.Username,
                                Purchases = x.Cards
                                                .SelectMany(p => p.Purchases)
                                                .Where(p => p.Type == type)
                                                .Select(p => new PurchaseDto
                                                {
                                                    Card = p.Card.Number,
                                                    Cvc = p.Card.Cvc,
                                                    Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                                    Game = new GameDto
                                                    {
                                                        Genre = p.Game.Genre.Name,
                                                        Title = p.Game.Name,
                                                        Price = p.Game.Price
                                                    }
                                                })
                                                .OrderBy(f => f.Date)
                                                    .ToArray(),
                                 TotalSpent = x.Cards
                                                 .SelectMany(p => p.Purchases)
                                                 .Where(t => t.Type == type)
                                                 .Sum(p => p.Game.Price)
                            })
                            .Where(x => x.Purchases.Any())
                            .OrderByDescending(x => x.TotalSpent)
                            .ThenBy(u => u.Username)
                            .ToArray();

            string xml = SerialzerXml.SerializeObject(users, "Users", true);
            return xml;
        }
        
    }
}