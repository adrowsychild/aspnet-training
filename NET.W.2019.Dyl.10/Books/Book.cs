//-----------------------------------------------------------------------
// <copyright file="Book.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Books
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class representing a single book.
    /// </summary>
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>, IFormattable
    {
        #region Fields
        /// <summary>
        /// Unique ISBN.
        /// </summary>
        private string isbn;

        /// <summary>
        /// Author name.
        /// </summary>
        private string author;

        /// <summary>
        /// Book title.
        /// </summary>
        private string title;

        /// <summary>
        /// Publishing house.
        /// </summary>
        private string publisher;

        /// <summary>
        /// Year of publication
        /// </summary>
        private int year;

        /// <summary>
        /// Number of pages.
        /// </summary>
        private int numOfPages;

        /// <summary>
        /// Book price.
        /// </summary>
        private decimal price;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Book class.
        /// </summary>
        /// <param name="isbn">Given ISBN</param>
        /// <param name="authorName">Given AuthorName</param>
        /// <param name="title">Given Title</param>
        /// <param name="publisher">Given Publisher</param>
        /// <param name="year">Given Year</param>
        /// <param name="numberOfPages">Given Number of pages</param>
        /// <param name="price">Given Price</param>
        public Book(string isbn, string authorName, string title, string publisher, int year, int numberOfPages, decimal price)
        {
            this.ISBN = isbn;
            this.Author = authorName;
            this.Title = title;
            this.Publisher = publisher;
            this.Year = year;
            this.NumOfPages = numberOfPages;
            this.Price = price;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets ISBN.
        /// </summary>
        public string ISBN
        {
            get => this.isbn;
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                var regex = new Regex("(ISBN[-]*(1[03])*[-]*(: ){0,1})*(([0-9Xx][-]*){13}|([0-9Xx][-]*){10})");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                this.isbn = value;
            }
        }

        /// <summary>
        /// Gets authorName.
        /// </summary>
        public string Author
        {
            get => this.author;
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                this.author = value;
            }
        }

        /// <summary>
        /// Gets title.
        /// </summary>
        public string Title
        {
            get => this.title;
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                this.title = value;
            }
        }

        /// <summary>
        /// Gets publisher..
        /// </summary>
        public string Publisher
        {
            get => this.publisher;
            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                this.publisher = value;
            }
        }

        /// <summary>
        /// Gets year.
        /// </summary>
        public int Year
        {
            get => this.year;
            internal set
            {
                if (value < 0 || value > DateTime.Today.Year)
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                this.year = value;
            }
        }

        /// <summary>
        /// Gets numberOfPages.
        /// </summary>
        public int NumOfPages
        {
            get => this.numOfPages;
            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                this.numOfPages = value;
            }
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        public decimal Price
        {
            get => this.price;
            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                this.price = value;
            }
        }
        #endregion

        #region Override methos
        /// <summary>
        /// override ToString() methods.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            string str = string.Empty;
            str = "Isbn: " + this.ISBN + "\tTitle: " + this.Title + "\tAuthor: " + this.Title + "\tYear: " + this.Year
                + "\tNumber of pages: " + this.NumOfPages + "\tPublisher: " + this.Publisher + "\tPrice: " + this.Price;
            return str;
        }

        /// <summary>
        /// IIFormattable ToString()
        /// </summary>
        /// <param name="format">Type of format.</param>
        /// <param name="formatProvider"> Format provider.</param>
        /// <returns>String representation.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(formatProvider, null))
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "G";
            }

            BookFormat bookFormat = new BookFormat();

            string result = bookFormat.Format(format, this, null);

            return result;
        }

        /// <summary>
        /// override Equals() methods.
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>True if objects are equivalent, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() == GetType())
            {
                Book book = obj as Book;
                return this.Equals(book);
            }

            return false;
        }

        /// <summary>
        /// override Equals() methods.
        /// </summary>
        /// <returns>Hash code with ISBN, publish house,  year, name divided by 4</returns>
        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode();
        }

        #endregion

        #region IComparable, IComparable<Book> and IEquatable<Book> Methods

        /// <summary>
        /// Implementation of IEquatable
        /// </summary>
        /// <param name="other">object to compare</param>
        /// <returns>true if other and this equals.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return other.ISBN == ISBN;
        }

        /// <summary>
        /// Implementation of IComparable
        /// </summary>
        /// <param name="obj">Given object to Compare</param>
        /// <returns>Integer representing the relativity.</returns>
        public int CompareTo(object obj)
        {
            Book b = (Book)obj;
            return string.Compare(this.Author, b.Author);
        }

        /// <summary>
        /// Implementation of IComparable
        /// </summary>
        /// <param name="b">Given Book to Compare</param>
        /// <returns>Integer representing the relativity.</returns>
        int IComparable<Book>.CompareTo(Book b)
        {
            return string.Compare(this.Author, b.Author);
        }

        /// <summary>
        /// Implementation of IComparer for Year Property.
        /// </summary>
        /// <returns>The instance of IComparer.</returns>
        public static IComparer<Book> SortYear()
        {
            return (IComparer<Book>)new SortYearHelper();
        }

        /// <summary>
        /// Implementation of IComparer for NumOfPages Property.
        /// </summary>
        /// <returns>The instance of IComparer.</returns>
        public static IComparer<Book> SortNumOfPages()
        {
            return (IComparer<Book>)new SortNumOfPagesHelper();
        }

        /// <summary>
        /// Implementation of IComparer for Price Property.
        /// </summary>
        /// <returns>The instance of IComparer.</returns>
        public static IComparer<Book> SortPrice()
        {
            return (IComparer<Book>)new SortPriceHelper();
        }

        /// <summary>
        /// Implementation of IComparer for Author Property.
        /// </summary>
        /// <returns>The instance of IComparer.</returns>
        public static IComparer<Book> SortAuthor()
        {
            return (IComparer<Book>)new SortAuthorHelper();
        }

        /// <summary>
        /// Implementation of IComparer for Title Property.
        /// </summary>
        /// <returns>The instance of IComparer.</returns>
        public static IComparer<Book> SortTitle()
        {
            return (IComparer<Book>)new SortTitleHelper();
        }

        /// <summary>
        /// Implementation of IComparer for Publisher Property.
        /// </summary>
        /// <returns>The instance of IComparer.</returns>
        public static IComparer<Book> SortPublisher()
        {
            return (IComparer<Book>)new SortPublisherHelper();
        }

        /// <summary>
        /// Private class for comparing Books by Year. 
        /// </summary>
        private class SortYearHelper : IComparer<Book>
        {
            /// <summary>
            /// Implementation of Icomparer for comparing by Year
            /// </summary>
            /// <param name="a">The first book to compare.</param>
            /// <param name="b">The second book to compare.</param>
            /// <returns>The instance of IComparer</returns>
            int IComparer<Book>.Compare(Book a, Book b)
            {
                Book c1 = (Book)a;
                Book c2 = (Book)b;

                if (c1.Year > c2.Year)
                {
                    return 1;
                }
                else if (c1.Year < c2.Year)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Private class for comparing Books by Number of Pages. 
        /// </summary>
        private class SortNumOfPagesHelper : IComparer<Book>
        {
            /// <summary>
            /// Implementation of Icomparer for comparing by Number of Pages
            /// </summary>
            /// <param name="a">The first book to compare.</param>
            /// <param name="b">The second book to compare.</param>
            /// <returns>The instance of IComparer</returns>
            int IComparer<Book>.Compare(Book a, Book b)
            {
                if (a.NumOfPages > b.NumOfPages)
                {
                    return 1;
                }
                else if (a.NumOfPages < b.NumOfPages)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Private class for comparing Books by Price. 
        /// </summary>
        private class SortPriceHelper : IComparer<Book>
        {
            /// <summary>
            /// Implementation of Icomparer for comparing by Price
            /// </summary>
            /// <param name="a">The first book to compare.</param>
            /// <param name="b">The second book to compare.</param>
            /// <returns>The instance of IComparer</returns>
            int IComparer<Book>.Compare(Book a, Book b)
            {
                if (a.Price > b.Price)
                {
                    return 1;
                }
                else if (a.Price < b.Price)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Private class for comparing Books by Author. 
        /// </summary>
        private class SortAuthorHelper : IComparer<Book>
        {
            /// <summary>
            /// Implementation of Icomparer for comparing by Author
            /// </summary>
            /// <param name="a">The first book to compare.</param>
            /// <param name="b">The second book to compare.</param>
            /// <returns>The instance of IComparer</returns>
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Author, b.Author);
            }
        }

        /// <summary>
        /// Private class for comparing Books by Title. 
        /// </summary>
        private class SortTitleHelper : IComparer<Book>
        {
            /// <summary>
            /// Implementation of Icomparer for comparing by Title
            /// </summary>
            /// <param name="a">The first book to compare.</param>
            /// <param name="b">The second book to compare.</param>
            /// <returns>The instance of IComparer</returns>
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Title, b.Title);
            }
        }

        /// <summary>
        /// Private class for comparing Books by Publisher. 
        /// </summary>
        private class SortPublisherHelper : IComparer<Book>
        {
            /// <summary>
            /// Implementation of Icomparer for comparing by Publisher
            /// </summary>
            /// <param name="a">The first book to compare.</param>
            /// <param name="b">The second book to compare.</param>
            /// <returns>The instance of IComparer</returns>
            int IComparer<Book>.Compare(Book a, Book b)
            {
                return string.Compare(a.Publisher, b.Publisher);
            }
        }

        #endregion
    }
}
