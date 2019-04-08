namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.Dtos.Export;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            string xmlCars = File.ReadAllText("../../../Datasets/cars.xml");
            string xmlParts = File.ReadAllText("../../../Datasets/parts.xml");
            string xmlSuppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            string xmlCustomers = File.ReadAllText("../../../Datasets/customers.xml");
            string xmlSales = File.ReadAllText("../../../Datasets/sales.xml");

            using (CarDealerContext db = new CarDealerContext())
            {
                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }
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

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Parse(inputXml);
            var elements = xdoc.Root.Elements().ToList();

            IList<Supplier> suppliers = new List<Supplier>();

            elements.ForEach(element =>
            {
                Supplier supplier = new Supplier()
                {
                    Name = element.Element("name").Value,
                    IsImporter = bool.Parse(element.Element("isImporter").Value)
                };

                suppliers.Add(supplier);
            });

            context.Suppliers.AddRange(suppliers);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Parse(inputXml);

            List<XElement> elements = xdoc.Root.Elements().ToList();
            HashSet<int> supplierIds = context.Suppliers.Select(s => s.Id).ToHashSet();

            IList<Part> parts = new List<Part>();

            elements.ForEach(element =>
            {
                Part part = new Part()
                {
                    Name = element.Element("name").Value,
                    Price = decimal.Parse(element.Element("price").Value),
                    Quantity = int.Parse(element.Element("quantity").Value),
                    SupplierId = int.Parse(element.Element("supplierId").Value)
                };

                if (supplierIds.Contains(part.SupplierId))
                {
                    parts.Add(part);
                }
            });

            context.Parts.AddRange(parts);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Parse(inputXml);
            var elements = xdoc.Root.Elements();

            IList<Car> cars = new List<Car>();

            foreach (var property in elements)
            {
                Car currentCar = new Car
                {
                    Make = property.Element("make").Value,
                    Model = property.Element("model").Value,
                    TravelledDistance = Convert.ToInt64(property.Element("TraveledDistance").Value)
                };

                HashSet<int> partIds = new HashSet<int>();

                foreach (var item in property.Element("parts").Elements())
                {
                    var partId = Convert.ToInt32(item.Attribute("id").Value);
                    partIds.Add(partId);
                }

                HashSet<int> existingPartIds = context.Parts.Select(p => p.Id).ToHashSet();

                foreach (var id in partIds)
                {
                    if (!existingPartIds.Contains(id))
                    {
                        continue;
                    }

                    PartCar pc = new PartCar()
                    {
                        Car = currentCar,
                        PartId = id
                    };

                    currentCar.PartCars.Add(pc);
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            int affectedRows = cars.Count;
            return $"Successfully imported {affectedRows}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Parse(inputXml);
            List<XElement> elements = xdoc.Root.Elements().ToList();

            IList<Customer> customers = new List<Customer>();
            elements.ForEach(el =>
            {
                Customer customer = new Customer()
                {
                    Name = el.Element("name").Value,
                    BirthDate = Convert.ToDateTime(el.Element("birthDate").Value),
                    IsYoungDriver = Convert.ToBoolean(el.Element("isYoungDriver").Value)
                };

                customers.Add(customer);
            });

            context.Customers.AddRange(customers);           

            int affectedRows = context.SaveChanges();
            return $"Successfully imported {affectedRows}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Parse(inputXml);
            var elements = xdoc.Root.Elements();

            HashSet<int> carIds = context.Cars.Select(c => c.Id).ToHashSet();
            HashSet<int> customerIds = context.Customers.Select(c => c.Id).ToHashSet();
            IList<Sale> sales = new List<Sale>();
            
            foreach (var element in elements)
            {
                int carId = Convert.ToInt32(element.Element("carId").Value);
                int customerId = Convert.ToInt32(element.Element("customerId").Value);

                if (!carIds.Contains(carId))
                {
                    continue;
                }

                Sale sale = new Sale()
                {
                    CarId = carId,
                    CustomerId = customerId,
                    Discount = Convert.ToDecimal(element.Element("discount").Value)
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                            .Cars                            
                            .Where(c => c.TravelledDistance > 2000000)
                            .ProjectTo<CarsWithDistanceDto>()
                            .OrderBy(c => c.Make)
                            .ThenBy(c => c.Model)
                            .Take(10)
                            .ToArray();

            string xml = SerializeObject(cars, "cars");
            return xml;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmws = context
                            .Cars
                            .Where(c => c.Make == "BMW")
                            .OrderBy(c => c.Model)
                            .ThenByDescending(c => c.TravelledDistance)
                            .ProjectTo<BmwDto>()
                            .ToArray();

            string xml = SerializeObject(bmws, "cars");
            return xml;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                                .Suppliers
                                .Where(s => !s.IsImporter)
                                .ProjectTo<LocalSuppliersDto>()
                                .ToArray();

            string xml = SerializeObject(suppliers, "suppliers");
            return xml;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                            .Cars
                            .Include(c => c.PartCars)
                            .OrderByDescending(c => c.TravelledDistance)
                            .ThenBy(c => c.Model)
                            .Take(5)
                            .ProjectTo<ListOfPartsDto>()
                            .ToArray();

            string xml = SerializeObject(cars, "cars");
            return xml;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                                .Customers
                                .Where(c => c.Sales.Any())
                                .ProjectTo<CustomerTotalSale>()
                                .OrderByDescending(c => c.SpentMoney)
                                .ToArray();

            string xml = SerializeObject(customers, "customers");
            return xml;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                            .Sales
                            .Include(s => s.Customer)
                            .Include(s => s.Car)
                            .ThenInclude(c => c.PartCars)
                            .ThenInclude(pc => pc.Part)
                            .ProjectTo<SalesWithDiscountDto>()
                            .ToArray();

            string xml = SerializeObject(sales, "sales");
            return xml;
        }
    }
}