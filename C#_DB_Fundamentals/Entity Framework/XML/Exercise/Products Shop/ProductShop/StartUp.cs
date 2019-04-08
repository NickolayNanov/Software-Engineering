using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            //string userPath =
            //            @"..\..\..\Datasets\users.xml";

            //string productsPath =
            //            @"..\..\..\Datasets\products.xml";

            //string categoriesPath =
            //            @"..\..\..\Datasets\categories.xml";

            //string categoriesProductsPath =
            //            @"..\..\..\Datasets\categories-products.xml";

            using (ProductShopContext db = new ProductShopContext())
            {

                Console.WriteLine(GetUsersWithProducts(db));
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
        //Imports
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Load(inputXml);

            List<XElement> elements = xdoc.Root.Elements().ToList();

            IList<User> users = new List<User>();

            elements.ForEach(element =>
            {
                User user = new User()
                {
                    FirstName = element.Element("firstName").Value,
                    LastName = element.Element("lastName").Value,
                    Age = (int?)int.Parse(element.Element("age").Value)
                };

                users.Add(user);
            });

            context.AddRange(users);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Load(inputXml);

            List<XElement> elements = xdoc.Root.Elements().ToList();
            IList<Product> products = new List<Product>();

            elements.ForEach(element =>
            {
                Product product = new Product()
                {
                    Name = element.Element("name").Value,
                    Price = decimal.Parse(element.Element("price").Value)
                };

                int sellerId = Convert.ToInt32(element.Element("sellerId").Value);
                int buyerId = Convert.ToInt32(element.Element("sellerId").Value);

                product.SellerId = sellerId;
                product.BuyerId = buyerId == 0 ? null : (int?)buyerId;

                products.Add(product);
            });

            context.Products.AddRange(products);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Load(inputXml);

            var elements = xdoc.Root.Elements().ToList();
            var categories = new List<Category>();

            elements.ForEach(element =>
            {
                Category category = new Category()
                {
                    Name = element.Element("name").Value
                };
                categories.Add(category);
            });

            context.Categories.AddRange(categories);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XDocument xdoc = XDocument.Load(inputXml);
            List<XElement> elements = xdoc.Root.Elements().ToList();

            IList<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var element in elements)
            {
                int productId = Convert.ToInt32(element.Element("ProductId").Value);
                int categoryId = Convert.ToInt32(element.Element("CategoryId").Value);

                if (categoryId == 0 || productId == 0)
                {
                    continue;
                }

                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };

                categoryProducts.Add(categoryProduct);
            };

            context.CategoryProducts.AddRange(categoryProducts);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }

        //Exports
        public static string GetProductsInRange(ProductShopContext context)
        {
            //Get all products in a specified price range between 500 and 1000(inclusive).
            //Order them by price(from lowest to highest).Select only the product name, price 
            //and the full name of the buyer.Take top 10 records.

            var products = context
                                .Products
                                .Include(p => p.Buyer)
                                .Where(p => p.Price >= 500 && p.Price <= 1000)
                                .OrderBy(p => p.Price)
                                .Take(10)
                                .ProjectTo<ProductInRangeDTO>(Mapper.Configuration)
                                .ToList();

            string xml = SerializeObject(products, "Products", false);
            return xml;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold item. Order them by last name, then by first name.
            //Select the person's first and last name. For each of the sold products, select the product's 
            //name and price. Take top 5 records.

            var users = context.Users
               .Include(u => u.ProductsSold)
               .Where(u => u.ProductsSold.Count > 0)
               .OrderBy(u => u.LastName)
               .ThenBy(u => u.FirstName)
               .Take(5)
               .ProjectTo<GetSoldProductsDto>()
               .ToList();

            string xml = SerializeObject(users, "Users");
            return xml;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            List<CategoriesByProductsDto> categories = context.Categories
                .ProjectTo<CategoriesByProductsDto>()
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var xml = SerializeObject(categories, "Categories", false);
            return xml;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                                .Include(x => x.ProductsSold)
                                .Where(u => u.ProductsSold.Count > 0)
                                .OrderByDescending(u => u.ProductsSold.Count)
                                .ProjectTo<UserDto>()
                                .ToList();

            var facade = Mapper.Map<UsersAndProductsDto>(users.ToList());

            var xml = SerializeObject(facade, "Users", true);
            return xml;

        }
    }
}