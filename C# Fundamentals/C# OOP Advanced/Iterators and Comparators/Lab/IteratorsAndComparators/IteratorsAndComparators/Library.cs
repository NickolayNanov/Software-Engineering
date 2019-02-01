using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);

        }

        public IEnumerator<Book> GetEnumerator()
        {
            this.books.Sort();
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            public object Current => this.books[currentIndex];

            Book IEnumerator<Book>.Current => this.books[currentIndex];

            public void Dispose()
            {
               
            }

            public bool MoveNext()
            {
                return ++currentIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }

            
        }

       
    }
}
