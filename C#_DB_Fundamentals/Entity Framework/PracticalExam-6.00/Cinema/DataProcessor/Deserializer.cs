namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";        
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            ImportMovieDto[] dtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            IList<Movie> moviesToAdd = new List<Movie>();

            foreach (ImportMovieDto dto in dtos)
            {
                bool titleAlreadyExists = moviesToAdd.Any(x => x.Title == dto.Title);

                if (!IsValid(dto) || titleAlreadyExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Movie currentMovie = new Movie
                {
                    Title = dto.Title,
                    Genre = Enum.Parse<Data.Models.Enums.Genre>(dto.Genre),
                    Duration = TimeSpan.Parse(dto.Duration),
                    Director = dto.Director,
                    Rating = dto.Rating
                };

                moviesToAdd.Add(currentMovie);
                sb.AppendLine($"Successfully imported {currentMovie.Title} with genre {currentMovie.Genre.ToString()} and rating {currentMovie.Rating:F2}!");
            }

            context.Movies.AddRange(moviesToAdd);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            ImportHallDto[] dtos = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            IList<Hall> hallsToAdd = new List<Hall>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Hall currentHall = new Hall
                {
                    Name = dto.Name,
                    Is3D = dto.Is3D,
                    Is4Dx = dto.Is4Dx
                };

                for (int i = 0; i < dto.Seats; i++)
                {
                    Seat currentSeat = new Seat
                    {
                        Hall = currentHall
                    };

                    currentHall.Seats.Add(currentSeat);
                };

                string projectionType = string.Empty;

                if (currentHall.Is4Dx && currentHall.Is3D) projectionType = "4Dx/3D";
                else if (currentHall.Is3D && !currentHall.Is4Dx) projectionType = "3D";
                else if (!currentHall.Is3D && currentHall.Is4Dx) projectionType = "4Dx";
                else projectionType = "Normal";
                        

                hallsToAdd.Add(currentHall);
                sb.AppendLine(String.Format(SuccessfulImportHallSeat, currentHall.Name, projectionType, currentHall.Seats.Count));
            }

            context.Halls.AddRange(hallsToAdd);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            ImportProjectionDto[] dtos = (ImportProjectionDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            IList<Projection> projectionsToAdd = new List<Projection>();

            foreach (var dto in dtos)
            {
                Hall hall = context.Halls.FirstOrDefault(h => h.Id == dto.HallId);
                Movie movie = context.Movies.FirstOrDefault(m => m.Id == dto.MovieId);

                if(!IsValid(dto) || hall == null || movie == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Projection currentProjection = new Projection
                {
                    Hall = hall,
                    Movie = movie,
                    DateTime = DateTime.ParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projectionsToAdd.Add(currentProjection);
                sb.AppendLine(String.Format(SuccessfulImportProjection, currentProjection.Movie.Title, currentProjection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(projectionsToAdd);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();         
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerTicketDto[]), new XmlRootAttribute("Customers"));
            ImportCustomerTicketDto[] dtos = (ImportCustomerTicketDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            IList<Customer> customersToAdd = new List<Customer>();

            foreach (ImportCustomerTicketDto dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer currentCustomer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance
                };

                foreach (TicketDto ticketDto in dto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket
                    {
                        Customer = currentCustomer,
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price
                    };

                    currentCustomer.Tickets.Add(ticket);
                    
                }

                customersToAdd.Add(currentCustomer);
                sb.AppendLine(String.Format(SuccessfulImportCustomerTicket,
                                                                currentCustomer.FirstName,
                                                                currentCustomer.LastName,
                                                                currentCustomer.Tickets.Count));
            }

            context.Customers.AddRange(customersToAdd);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        private static bool IsValid(object entity)
        {
            ValidationContext validatorContext = new ValidationContext(entity);
            IList<ValidationResult> validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validatorContext, validationResult, true);

            return isValid;
        }
    }
}
