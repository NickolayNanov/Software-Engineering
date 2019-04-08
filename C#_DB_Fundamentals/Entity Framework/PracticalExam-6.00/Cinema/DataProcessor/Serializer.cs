namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                            .Movies
                            .Where(x => x.Rating >= rating && x.Projections.Count(p => p.Tickets.Any()) > 0)                            
                            .Select(x => new
                            {
                                MovieName = x.Title,
                                Rating = $"{x.Rating:F2}",
                                TotalIncomes = $"{x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)):F2}",
                                Customers = x.Projections
                                                .SelectMany(p => p.Tickets)
                                                .Select(t => t.Customer)
                                                .Select(f => new
                                                {
                                                    FirstName = f.FirstName,
                                                    LastName = f.LastName,
                                                    Balance = $"{f.Balance:F2}"
                                                })
                                                .OrderByDescending(f => f.Balance)
                                                .ThenBy(f => f.FirstName)
                                                .ThenBy(f => f.LastName)
                                                .ToArray()
                            })
                            .OrderByDescending(x => decimal.Parse(x.Rating))
                            .ThenByDescending(x => decimal.Parse(x.TotalIncomes))
                            .Take(10)
                            .ToArray();

            string json = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                                .Customers
                                .Where(x => x.Age >= age)
                                .Select(x => new ExportCustomerDto
                                {
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    SpentMoney = $"{x.Tickets.Sum(t => t.Price):F2}",
                                    SpentTime = new TimeSpan(x.Tickets
                                                    .Select(t => t.Projection)
                                                    .Select(p => p.Movie.Duration)
                                                    .Sum(t => t.Ticks))
                                                    .ToString(@"hh\:mm\:ss")
                                })
                                .OrderByDescending(x => decimal.Parse(x.SpentMoney))
                                .Take(10)
                                .ToArray();

            string xml = SerializeObject(customers, "Customers");
            return xml;
        }

        public static string SerializeObject<T>(T values, string rootName, bool omitXmlDeclaration = false,
        bool indentXml = true)
        {
            string xml = string.Empty;

            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var settings = new XmlWriterSettings()
            {
                Indent = indentXml,
                OmitXmlDeclaration = omitXmlDeclaration
            };

            XmlSerializerNamespaces @namespace = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, values, @namespace);
                xml = stream.ToString();
            }

            return xml;
        }

    }
}