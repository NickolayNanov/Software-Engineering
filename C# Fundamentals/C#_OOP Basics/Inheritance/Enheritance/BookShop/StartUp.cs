using System;

namespace BookShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();            
            decimal price = decimal.Parse(Console.ReadLine());

            Book book = new Book(author, title, price);
            GoldenEditionBook gBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book);
            Console.WriteLine();
            Console.WriteLine(gBook);

        }
    }
}
