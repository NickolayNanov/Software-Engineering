namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImputDtos;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            ImportUserDto[] dtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            IList<Game> games = new List<Game>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Developer developer = GetDeveloper(context, dto.Developer);
                Genre genre = GetGenre(context, dto.Genre);

                Game currentGame = new Game
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre
                };

                foreach (var dtoTag in dto.Tags)
                {
                    Tag currentTag = GetTag(context, dtoTag);

                    currentGame.GameTags.Add(new GameTag
                    {
                        Game = currentGame,
                        Tag = currentTag
                    });
                }

                games.Add(currentGame);
                sb.AppendLine($"Added {currentGame.Name} ({currentGame.Genre.Name}) with {currentGame.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)    
        {
            InputUserDto[] dtos = JsonConvert.DeserializeObject<InputUserDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            IList<User> users = new List<User>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                User currentUser = new User
                {
                    Username = dto.Username,
                    FullName = dto.FullName,
                    Email = dto.Email,
                    Age = dto.Age,
                };

                foreach (var cardDto in dto.Cards)
                {
                    Card currentCard = new Card
                    {
                        User = currentUser,
                        Cvc = cardDto.Cvc,
                        Number = cardDto.Number,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    };

                    currentUser.Cards.Add(currentCard);
                }

                sb.AppendLine($"Imported {currentUser.Username} with {currentUser.Cards.Count} cards");
                users.Add(currentUser);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchase[]), new XmlRootAttribute("Purchases"));
            ImportPurchase[] purchasesDto = (ImportPurchase[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            IList<Purchase> purchases = new List<Purchase>();

            foreach (var dto in purchasesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isValidType = Enum.TryParse<PurchaseType>(dto.Type, out PurchaseType purchaseType);

                if (!isValidType)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Game game = context.Games.FirstOrDefault(g => g.Name == dto.GameTitle);
                Card card = context.Cards.FirstOrDefault(c => c.Number == dto.CardNumber);

                Purchase currentPurchase = new Purchase
                {
                    Game = game,
                    ProductKey = dto.ProductKey,
                    Card = card,
                    Type = purchaseType,
                    Date = DateTime.ParseExact(dto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                };

                purchases.Add(currentPurchase);
                sb.AppendLine($"Imported {currentPurchase.Game.Name} for {currentPurchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        private static Tag GetTag(VaporStoreDbContext context, string currentTag)
        {
            Tag tag = context.Tags.FirstOrDefault(t => t.Name == currentTag);

            if (tag == null)
            {
                tag = new Tag
                {
                    Name = currentTag
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }

            return tag;
        }

        private static Genre GetGenre(VaporStoreDbContext context, string genreName)
        {
            Genre genre = context.Genres.FirstOrDefault(g => g.Name == genreName);

            if (genre == null)
            {
                genre = new Genre()
                {
                    Name = genreName
                };

                context.Genres.Add(genre);
                context.SaveChanges();
            }

            return genre;
        }

        private static Developer GetDeveloper(VaporStoreDbContext context, string developerName)
        {
            Developer developer = context.Developers.FirstOrDefault(d => d.Name == developerName);

            if (developer == null)
            {
                developer = new Developer()
                {
                    Name = developerName
                };

                context.Developers.Add(developer);
                context.SaveChanges();
            }

            return developer;
        }

        private static bool IsValid(object entity)
        {
            System.ComponentModel.DataAnnotations.ValidationContext validatorContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity);
            IList<ValidationResult> validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validatorContext, validationResult, true);

            return isValid;
        }

      
    }
}