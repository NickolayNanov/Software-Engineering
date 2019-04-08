namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                List<ICollection<BookCategory>> booksSelect = db
                                  .Books
                                  .Include(b => b.BookCategories)
                                  .ThenInclude(bc => bc.Book)
                                  .Include(b => b.BookCategories)
                                  .ThenInclude(bc => bc.Category)
                                  .Select(b => b.BookCategories)
                                  .ToList();

                List<BookCategory> booksSelectMany = db
                                       .Books
                                       .SelectMany(b => b.BookCategories)
                                       .Include(bc => bc.Book)
                                       .Include(bc => bc.Category)
                                       .ToList();

                foreach (var book in booksSelectMany)
                {
                    //Console.WriteLine(book.);
                }

            }
        }

        // Done
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction restriction = Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitles = context.Books
                                            .Where(b => b.AgeRestriction == restriction)
                                            .Select(b => b.Title)
                                            .OrderBy(t => t)
                                            .ToArray();

            string result = string.Join(Environment.NewLine, bookTitles);
            return result;
        }

        // Done
        public static string GetGoldenBooks(BookShopContext context)
        {
            EditionType editionType = Enum.Parse<EditionType>("gold", true);

            string[] goldEditions = context.Books
                                            .Where(b => b.EditionType == editionType && b.Copies < 5000)
                                            .OrderBy(b => b.BookId)
                                            .Select(b => b.Title)
                                            .ToArray();

            string result = string.Join(Environment.NewLine, goldEditions);
            return result;
        }

        // Done
        public static string GetBooksByPrice(BookShopContext context)
        {
            string[] books = context.Books
                                        .Where(b => b.Price > 40)
                                        .OrderByDescending(b => b.Price)
                                        .Select(b => $"{b.Title} - ${b.Price:F2}")
                                        .ToArray();

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        // Done
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] titles = context.Books
                                        .Where(b => b.ReleaseDate.Value.Year != year)
                                        .OrderBy(b => b.BookId)
                                        .Select(b => b.Title)
                                        .ToArray();

            string result = string.Join(Environment.NewLine, titles);
            return result;
        }

        // Done
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] titels = context.Books
                                        .Where(b => b.BookCategories
                                                        .Any(c => categories
                                                            .Contains(c.Category.Name.ToLower())))
                                        .Select(b => b.Title)
                                        .OrderBy(t => t)
                                        .ToArray();

            string result = string.Join(Environment.NewLine, titels);
            return result;
        }

        // Done
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            ;
            string[] books = context.Books
                                       .Where(b => b.ReleaseDate < dateTime)
                                       .OrderByDescending(b => b.ReleaseDate)
                                       .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                                       .ToArray();

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        // Done
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] authors = context.Authors
                                        .Where(a => a.FirstName.EndsWith(input))
                                        .Select(a => $"{a.FirstName} {a.LastName}")
                                        .OrderBy(a => a)
                                        .ToArray();

            string result = string.Join(Environment.NewLine, authors);
            return result;
        }

        // Done
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();

            string[] titles = context.Books
                                        .Where(b => b.Title.ToLower().Contains(input))
                                        .Select(b => b.Title)
                                        .OrderBy(t => t)
                                        .ToArray();

            string result = string.Join(Environment.NewLine, titles);
            return result;
        }

        // Done
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();
            string[] titles = context.Books
                                        .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                                        .OrderBy(b => b.BookId)
                                        .Select(b => $"{b.Title} ({b.Author.FirstName + " " + b.Author.LastName})")
                                        .ToArray();

            string result = string.Join(Environment.NewLine, titles);
            return result;
        }

        // Done
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }

        // Done
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            string[] authors = context.Authors
                                    .OrderByDescending(a => a.Books.Sum(b => b.Copies))
                                    .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
                                    .ToArray();

            string result = string.Join(Environment.NewLine, authors);
            return result;
        }

        // Done
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            string[] categories = context
                                .Categories
                                .OrderByDescending(c => c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies))
                                .ThenBy(c => c.Name)
                                .Select(c => $"{c.Name} ${c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies):F2}")
                                .ToArray();

            string result = string.Join(Environment.NewLine, categories);
            return result;
        }

        // Пререши
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                                    .Select(x => new
                                    {
                                        CategoryName = x.Name,
                                        Books = x.CategoryBooks.Select(e => new
                                        {
                                            e.Book.Title,
                                            e.Book.ReleaseDate
                                        })
                                        .OrderByDescending(e => e.ReleaseDate)
                                        .Take(3)
                                        .ToArray()
                                    })
                                    .OrderBy(e => e.CategoryName)
                                    .ToArray();

            foreach (var category in books)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString();
        }

        // Done
        public static void IncreasePrices(BookShopContext context)
        {
            Book[] books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Done
        public static int RemoveBooks(BookShopContext context)
        {
            int rows = context
                            .Books
                            .Where(b => b.Copies < 4200)
                            .Delete();

            return rows;
        }
    }
}
