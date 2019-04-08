using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                Console.WriteLine(GetCategoriesByProductsCount(context));
            }
        }

        //Imports

        //100/100
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] user = JsonConvert.DeserializeObject<User[]>(inputJson)
                                            .Where(u => u.LastName != null && u.LastName.Length >= 3)
                                            .ToArray();

            context.Users.AddRange(user);

            return $"Successfully imported {context.SaveChanges()}";
        }

        //100/100
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson).Where(p => !string.IsNullOrEmpty(p.Name)).ToArray();

            context.Products.AddRange(products);

            return $"Successfully imported {context.SaveChanges()}";
        }

        //100/100
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson).Where(c => c.Name != null).ToArray();

            context.Categories.AddRange(categories);

            return $"Successfully imported {context.SaveChanges()}";
        }

        //100/100
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(categoryProducts);

            return $"Successfully imported {context.SaveChanges()}";
        }

        //Exports

        //100/100
        public static string GetProductsInRange(ProductShopContext context)
        {
            //Get all products in a specified price range:  500 to 1000 (inclusive). Order them by price (from lowest to highest). 

            var products = context
                                    .Products
                                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                                    .Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price,
                                        seller = $"{(p.Seller.FirstName + " " ?? "")}{p.Seller.LastName}"
                                    })
                                    .OrderBy(p => p.price)
                                    .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            //string path = @"D:\Nick\Softuni\C#_DB_Fundamentals\Entity Framework\Json\Exercise\Product Shop\ProductShop\Exports\productsInRange.json";
            //File.WriteAllText(path, json);

            return json;
        }

        //100/100
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                            .Users
                            .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                            .OrderBy(u => u.LastName)
                            .ThenBy(u => u.FirstName)
                            .Select(u => new
                            {
                                firstName = u.FirstName,
                                lastName = u.LastName,
                                soldProducts = u.ProductsSold.Select(ps => new
                                {
                                    name = ps.Name,
                                    price = ps.Price,
                                    buyerFirstName = ps.Buyer.FirstName,
                                    buyerLastName = ps.Buyer.LastName
                                }).ToArray()
                            });

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            
            //string path = @"D:\Nick\Softuni\C#_DB_Fundamentals\Entity Framework\Json\Exercise\Product Shop\ProductShop\Exports\usersWithSells.json";
            //File.WriteAllText(path, json);

            return json;
        }

        //100/100
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):f2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}",
                }).ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //100/100
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .Include(u => u.ProductsSold)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Count(),
                        products = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToList()
                    }

                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();


            var withUserCount = new
            {
                usersCount = users.Count,
                users,

            };

            var json = JsonConvert.SerializeObject(withUserCount, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            return json;
        }       
    }
}