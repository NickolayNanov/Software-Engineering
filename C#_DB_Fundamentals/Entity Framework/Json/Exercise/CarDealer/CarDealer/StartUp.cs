using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile<CarDealerProfile>();
            //});

            //string supplisePath = @"D:\Nick\Softuni\C#_DB_Fundamentals\Entity Framework\Json\Exercise\CarDealer\CarDealer\Datasets\suppliers.json";
            //string suppliesJson = File.ReadAllText(supplisePath);

            //string PartssupplisePath = @"D:\Nick\Softuni\C#_DB_Fundamentals\Entity Framework\Json\Exercise\CarDealer\CarDealer\Datasets\parts.json";
            //string partsJson = File.ReadAllText(PartssupplisePath);

            //string carsPath = @"D:\Nick\Softuni\C#_DB_Fundamentals\Entity Framework\Json\Exercise\CarDealer\CarDealer\Datasets\cars.json";
            //string carsJson = File.ReadAllText(carsPath);

            //string customerPath = @"D:\Nick\Softuni\C#_DB_Fundamentals\Entity Framework\Json\Exercise\CarDealer\CarDealer\Datasets\customers.json";
            //string customerJson = File.ReadAllText(customerPath);

            //string salesPath = @"D:\Nick\Softuni\C#_DB_Fundamentals\Entity Framework\Json\Exercise\CarDealer\CarDealer\Datasets\sales.json";
            //string salesJson = File.ReadAllText(salesPath);

            using (CarDealerContext context = new CarDealerContext())
            {
                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            int[] ids = context.Suppliers.Select(s => s.Id).ToArray();

            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                                .Where(x => ids.Contains(x.SupplierId)).ToArray();

            context.Parts.AddRange(parts);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var dtos = JsonConvert.DeserializeObject<CarDto[]>(inputJson);
            HashSet<Car> cars = new HashSet<Car>();

            foreach (CarDto dto in dtos)
            {
                Car currentCar = Mapper.Map<Car>(dto);
                cars.Add(currentCar);
                int[] partIds = dto
                                 .PartsId
                                 .Distinct()
                                 .ToArray();

                if (partIds == null)
                {
                    continue;
                }

                foreach (int partId in partIds)
                {
                    PartCar currentPart = new PartCar()
                    {
                        Car = currentCar,
                        PartId = partId
                    };

                    currentCar.PartCars.Add(currentPart);
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
            int affectedRows = context.Cars.Count();

            return $"Successfully imported {affectedRows}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {

            var customers = context
                               .Customers
                               .OrderBy(c => c.BirthDate)
                               .ThenBy(c => c.IsYoungDriver)
                               .Select(c => new
                               {
                                   Name = c.Name,
                                   BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                                   IsYoungDriver = c.IsYoungDriver
                               })
                               .ToArray();


            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            //string path = @"D:\Nick\Softuni\C#_DB_Fundamentals\Entity Framework\Json\Exercise\CarDealer\CarDealer\Exports\CustomersOrder.json";
            //File.WriteAllText(path, json);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotas = context
                            .Cars
                            .Where(c => c.Make.Equals("Toyota"))
                            .OrderBy(c => c.Model)
                            .ThenByDescending(c => c.TravelledDistance)
                            .Select(c => new
                            {
                                c.Id,
                                c.Make,
                                c.Model,
                                c.TravelledDistance
                            })
                            .ToArray();

            string json = JsonConvert.SerializeObject(toyotas, Formatting.Indented);
            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                                .Suppliers
                                .Where(s => !s.IsImporter)
                                .Select(s => new
                                {
                                    s.Id,
                                    s.Name,
                                    PartsCount = s.Parts.Count
                                })
                                .ToArray();


            var json = JsonConvert.SerializeObject(suppliers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carParts = context
                            .Cars
                            .Include(c => c.PartCars)
                            .ThenInclude(cp => cp.Part)
                            .Select(c => new
                            {
                                car = new
                                {
                                    c.Make,
                                    c.Model,
                                    c.TravelledDistance
                                },
                                parts = c.PartCars.Select(p => new
                                {
                                    p.Part.Name,
                                    Price = $"{p.Part.Price:f2}"
                                })
                            })
                            .ToArray();

            string json = JsonConvert.SerializeObject(carParts, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                                .Customers
                                .Where(c => c.Sales.Any())
                                .Select(c => new
                                {
                                    fullName = c.Name,
                                    boughtCars = c.Sales.Count,
                                    spentMoney = c.Sales
                                                    .Select(s => s.Car)
                                                    .SelectMany(pc => pc.PartCars)
                                                    .Select(p => p.Part.Price)
                                                    .Sum()
                                })
                                .OrderByDescending(c => c.spentMoney)
                                .ThenByDescending(c => c.boughtCars)
                                .ToArray();

            var json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                            .Sales
                            .Take(10)
                            .Select(s => new
                            {
                                car = new
                                {
                                    s.Car.Make,
                                    s.Car.Model,
                                    s.Car.TravelledDistance
                                },
                                customerName = s.Customer.Name,
                                Discount = $"{s.Discount:F2}",
                                price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):F2}",
                                priceWithDiscount = $"{s.Car.PartCars.Sum(pk => pk.Part.Price) - (s.Car.PartCars.Sum(pk => pk.Part.Price) * (s.Discount / 100)):F2}"
                            })
                            .ToArray();

            string json = JsonConvert.SerializeObject(sales, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }
    }
}