namespace Library
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class BookListService
    {
        public static void DoingStorage()
        {
            Console.WriteLine("Enter the path to store information at: ");
            string path = Console.ReadLine();

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book b in library)
                {
                    writer.Write(b.ToString());
                }
            }
        }

        public static List<Book> library;

        public static int bookCounter = 0;

        static BookListService()
        {
            library = new List<Book>();
        }

        public static void AddBook()
        {
            Console.WriteLine("Enter the Isbn of the book: ");

            string tempIsbn = Console.ReadLine();

            while (tempIsbn.Length != 13 || (!long.TryParse(tempIsbn, out long tryint)))
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Isbn must consist of 13 digits.");
                tempIsbn = Console.ReadLine();
            }

            if (library.Count == 0)
                ;
            else
            {
                foreach (var b in library)
                {
                    if (tempIsbn.Equals(b.Isbn))
                    {
                        //Console.WriteLine("We already have book with the same ISBN.");
                        throw new ArgumentException();
                    }
                }
            }

            Book book = new Book();


            book.Isbn = tempIsbn;

            Console.WriteLine("Enter the Author o the book: ");

            book.Author = Console.ReadLine();

            Console.WriteLine("Enter the Title of the book: ");

            book.Title = Console.ReadLine();

            Console.WriteLine("Enter the publisher: ");

            book.Publisher = Console.ReadLine();

            Console.WriteLine("Enter the year of publishing: ");

            int tempYear;

            while (!int.TryParse(Console.ReadLine(), out tempYear) || tempYear > 2020)
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Enter numbers less than 2020.");
            }

            book.Year = tempYear;

            Console.WriteLine("Enter the number of pages: ");

            int tempPages;

            while ((!int.TryParse(Console.ReadLine(), out tempPages)) || tempPages < 0)
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Enter numbers.");
            }

            book.NumOfPages = tempPages;

            Console.WriteLine("Enter the price: ");

            decimal tempPrice;
            while (!decimal.TryParse(Console.ReadLine(), out tempPrice) || tempPrice < 0)
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Enter numbers.");
            }

            book.Price = tempPrice;

            library.Add(book);

            bookCounter++;
        }

        public static void RemoveBook()
        {
            Console.WriteLine("Enter isbn of the book: ");
            string tempIsbn = Console.ReadLine();

            if ((long.TryParse(tempIsbn, out long tryint)) || tempIsbn.Length != 13)
            {
                Console.WriteLine("Incorrect output.");
            }

            Book book = FindBookByTag("isbn", "tryint");
            if (book != null)
            {
                library.Remove(book);
                bookCounter--;
            }
            else
            {
                //Console.WriteLine("There is no such book in the library.");
                throw new ArgumentException();
            }
        }

        public static void FindBook()
        {
            Console.WriteLine("Which tag do you want to search by?");
            string tag = Console.ReadLine();
            Console.WriteLine("Enter what you want to find: ");
            string arg = Console.ReadLine();
            if (BookListService.FindBookByTag(tag, arg) == null)
            {
                Console.WriteLine("There is no such book.");
            }
            else
            {
                Console.WriteLine("We've found the book!");
            }
        }

        public static void Sort()
        {
            library.Sort();
        }

        public static void Sort(string arg)
        {
            switch (arg)
            {
                case ("title"):
                    library.Sort(Book.sortTitle());
                    break;
                case ("year"):
                    library.Sort(Book.sortYear());
                    break;
                case ("author"):
                    library.Sort(Book.sortAuthor());
                    break;
                case ("numOfPages"):
                    library.Sort(Book.sortNumOfPages());
                    break;
                case ("price"):
                    library.Sort(Book.sortPrice());
                    break;
                case ("publisher"):
                    library.Sort(Book.sortPublisher());
                    break;
            }
        }

        public static Book FindBookByTag(string tag, string toFind)
        {
            Console.WriteLine("Enter the tag to find by: ");

            if (tag == "year" || tag == "Year")
            {
                if (!int.TryParse(toFind, out int year))
                {
                    Console.WriteLine("Incorrect input!");
                    return null;
                }

                for (int i = 0; i < library.Count; i++)
                {
                    if (library[i].Year == year)
                    {
                        return library[i];
                    }
                }
            }
            if (tag == "numOfPages" || tag == "NumOfPages" || tag == "pages")
            {
                if (!int.TryParse(toFind, out int pages))
                {
                    Console.WriteLine("Incorrect input!");
                    return null;
                }

                for (int i = 0; i < library.Count; i++)
                {
                    if (library[i].NumOfPages == pages)
                    {
                        return library[i];
                    }
                }
            }
            if (tag == "price" || tag == "Price")
            {
                if (!decimal.TryParse(toFind, out decimal price))
                {
                    Console.WriteLine("Incorrect input!");
                    return null;
                }

                for (int i = 0; i < library.Count; i++)
                {
                    if (library[i].Price == price)
                    {
                        return library[i];
                    }
                }
            }
            if (tag == "Title" || tag == "title")
            {
                if (toFind == null)
                {
                    Console.WriteLine("Incorrect input!");
                    return null;
                }

                for (int i = 0; i < library.Count; i++)
                {
                    if (string.Compare(library[i].Title, toFind)==0)
                    {
                        return library[i];
                    }
                }
            }
            if (tag == "Author" || tag == "author")
            {
                if (toFind == null)
                {
                    Console.WriteLine("Incorrect input!");
                    return null;
                }

                for (int i = 0; i < library.Count; i++)
                {
                    if (string.Compare(library[i].Author, toFind) == 0)
                    {
                        return library[i];
                    }
                }
            }
            if (tag == "Publisher" || tag == "publisher")
            {
                if (toFind == null)
                {
                    Console.WriteLine("Incorrect input!");
                    return null;
                }

                for (int i = 0; i < library.Count; i++)
                {
                    if (string.Compare(library[i].Publisher, toFind)==0)
                    {
                        return library[i];
                    }
                }
            }
            if (tag == "Isbn" || tag == "isbn" || tag == "ISBN")
            {
                
            }
            return null;
        }

        public static void ShowLibray()
        {
            foreach (Book b in library)
            {
                Console.WriteLine(b.ToString());
            }
        }


        // inner class to have full access over it
        // and to make it impossible to manipulate objects directly

        public class Book : IComparable<Book>, IEquatable<Book>
        {
            public string Isbn { get; set; }
            public string Author { get; set; }

            public string Title { get; set; }

            public string Publisher { get; set; }

            public int Year { get; set; }

            public int NumOfPages { get; set; }

            public decimal Price { get; set; }

            public Book()
            {

            }

            public Book(string isbn, string title, string author, string publisher, int numOfPages, decimal price)
            {
                this.Isbn = isbn;
                this.Title = title;
                this.Author = author;
                this.Publisher = publisher;
                this.NumOfPages = numOfPages;
                this.Price = price;
            }

            #region System.Object overrides
            public override string ToString()
            {
                string str = string.Empty;
                str = "Isbn: " + this.Isbn + "\tTitle: " + this.Title + "\tAuthor: " + this.Title + "\tYear: " + this.Year
                    + "\tNumber of pages: " + this.NumOfPages + "\tPublisher: " + this.Publisher + "\tPrice: " + this.Price;
                return str;
            }

            public override bool Equals(Object obj)
            {
                Book b = obj as Book;

                if (b == null || this.GetHashCode() != b.GetHashCode())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public bool Equals(Book other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;

                return Title.Equals(other.Title) && Author.Equals(other.Author) && Publisher.Equals(other.Publisher)
                        && Year.Equals(other.Year) && NumOfPages.Equals(other.NumOfPages) && Price.Equals(other.Price);
            }
            public override int GetHashCode()
            {
                return this.Isbn.GetHashCode();
            }

            #endregion

            #region IComparer

            public int CompareTo(object obj)
            {
                Book b = (Book)obj;
                return String.Compare(this.Author, b.Author);
            }

            int IComparable<Book>.CompareTo(Book b)
            {
                return String.Compare(this.Author, b.Author);
            }

            public int Compare(Book obj)
            {
                return String.Compare(this.Author, obj.Author);
            }

            public static IComparer<Book> sortYear()
            {
                return (IComparer<Book>)new sortYearHelper();
            }

            public static IComparer<Book> sortNumOfPages()
            {
                return (IComparer<Book>)new sortNumOfPagesHelper();
            }

            public static IComparer<Book> sortPrice()
            {
                return (IComparer<Book>)new sortPriceHelper();
            }

            public static IComparer<Book> sortAuthor()
            {
                return (IComparer<Book>)new sortAuthorHelper();
            }

            public static IComparer<Book> sortTitle()
            {
                return (IComparer<Book>)new sortTitleHelper();
            }

            public static IComparer<Book> sortPublisher()
            {
                return (IComparer<Book>)new sortPublisherHelper();
            }
            private class sortYearHelper : IComparer<Book>
            {
                int IComparer<Book>.Compare(Book a, Book b)
                {
                    Book c1 = (Book)a;
                    Book c2 = (Book)b;

                    if (c1.Year > c2.Year)
                        return 1;

                    if (c1.Year < c2.Year)
                        return -1;

                    else
                        return 0;
                }
            }

            private class sortNumOfPagesHelper : IComparer<Book>
            {
                int IComparer<Book>.Compare(Book a, Book b)
                {
                    if (a.NumOfPages > b.NumOfPages)
                        return 1;

                    if (a.NumOfPages < b.NumOfPages)
                        return -1;

                    else
                        return 0;
                }
            }

            private class sortPriceHelper : IComparer<Book>
            {
                int IComparer<Book>.Compare(Book a, Book b)
                {
                    if (a.Price > b.Price)
                        return 1;

                    if (a.Price < b.Price)
                        return -1;

                    else
                        return 0;
                }
            }

            private class sortAuthorHelper : IComparer<Book>
            {
                int IComparer<Book>.Compare(Book a, Book b)
                {
                    return String.Compare(a.Author, b.Author);
                }
            }

            private class sortTitleHelper : IComparer<Book>
            {
                int IComparer<Book>.Compare(Book a, Book b)
                {
                    return String.Compare(a.Title, b.Title);
                }
            }

            private class sortPublisherHelper : IComparer<Book>
            {
                int IComparer<Book>.Compare(Book a, Book b)
                {
                    return String.Compare(a.Publisher, b.Publisher);
                }
            }

            #endregion

        }

    }

   class Library
   {
        public static void Main(string[] args)
        {
            Console.WriteLine("Adding books: ");
            
            BookListService.AddBook();
            BookListService.AddBook();
            BookListService.AddBook();

            BookListService.DoingStorage();

            Console.WriteLine("Before sort: ");
            BookListService.ShowLibray();

            Console.WriteLine("After sort: ");
            BookListService.Sort();
            BookListService.ShowLibray();
            Console.WriteLine();

            Console.WriteLine("Sort by Title: ");
            BookListService.Sort("title");
            BookListService.ShowLibray();
            Console.WriteLine();

            Console.WriteLine("Sort by Author");
            BookListService.Sort("author");
            BookListService.ShowLibray();
            Console.WriteLine();

            Console.WriteLine("Sort by Year: ");
            BookListService.Sort("year");
            BookListService.ShowLibray();
            Console.WriteLine();

            Console.WriteLine("Sort by Price: ");
            BookListService.Sort("price");
            BookListService.ShowLibray();
            Console.WriteLine();

            Console.WriteLine("Searching: ");
            BookListService.FindBook();

            Console.WriteLine("Removing: ");
            BookListService.RemoveBook();
            Console.ReadLine();
        }
    }
}
