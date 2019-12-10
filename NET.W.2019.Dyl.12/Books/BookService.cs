//-----------------------------------------------------------------------
// <copyright file="BookService.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Books
{
    using System;
    using System.Collections.Generic;
    using static Books.NLogLogger;

    /// <summary>
    /// Class for working with Books.
    /// </summary>
    public class BookService
    {
        /// <summary>
        /// List of Book.
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// Logger of any type.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the BookService class.
        /// </summary>
        /// /// <param name="logger">Given logger.</param>
        public BookService(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the BookService class.
        /// </summary>
        /// <param name="books">The list of books.</param>
        /// <param name="logger">Give logger.</param>
        public BookService(List<Book> books, ILogger logger) : this(logger)
        {
            foreach (Book book in books)
            {
                this.AddBook(book);
            }
        }

        #region MainOperations

        /// <summary>
        /// Add book to the list of books.
        /// </summary>
        /// <param name="book">Book to be added.</param>
        /// <exception cref="ArgumentNullException">Argument must not be null.</exception>
        /// <exception cref="InvalidOperationException">This book is already exist in list.</exception>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                this.logger.Warn("Refused to add the book.", new ArgumentNullException(nameof(book)), book);
                throw new ArgumentNullException(nameof(book));
            }

            if (this.IsContains(book))
            {
                this.logger.Warn("Refused to add the book. Book " + book.Title + " by " + book.Author + "already exists.", new InvalidOperationException(nameof(book)), book);
                throw new InvalidOperationException(nameof(book));
            }

            this.books.Add(book);
            this.logger.Debug("Book " + book.Title + " by " + book.Author + "successfully added.");
        }

        /// <summary>
        /// Remove book from the list of books.
        /// </summary>
        /// <param name="book">Book to be removed.</param>
        /// <exception cref="ArgumentNullException">Argument must not be null.</exception>
        /// <exception cref="InvalidOperationException">No such element in list.</exception>
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                this.logger.Warn("Refused to remove the book.", new ArgumentNullException(nameof(book)), book);
                throw new ArgumentNullException(nameof(book));
            }

            if (!this.IsContains(book))
            {
                this.logger.Warn("Refused to remove the book. Book " + book.Title + " by " + book.Author + "doesn't exists.", new InvalidOperationException(nameof(book)), book);
                throw new InvalidOperationException(nameof(book));
            }

            foreach (Book b in this.books)
            {
                if (b.Equals(book))
                {
                    this.books.Remove(b);
                }
            }

            this.logger.Debug("Book " + book.Title + " by " + book.Author + "successfully removed.");
        }

        /// <summary>
        /// Find book by tag.
        /// </summary> 
        /// <param name="predicate"> Tag by which to search.</param>
        /// <exception cref="ArgumentNullException">Argument must not be null.</exception>
        /// <returns>List of found books.</returns>
        public List<Book> FindBookByTag(Predicate<Book> predicate)
        {
            if (predicate == null)
            {
                this.logger.Warn("Refused to find the book. Tag is invalid.", new ArgumentNullException(nameof(predicate)), predicate);
                throw new ArgumentNullException(nameof(predicate));
            }

            List<Book> found = this.books.FindAll(predicate);
            this.logger.Debug("Needed books were successfully found.");
            return found;
        }

        /// <summary>
        /// Sort book by tag.
        /// </summary> 
        /// <param name="comparer"> Tag by which sorting.</param>
        /// <exception cref="ArgumentNullException">Argument must not be null</exception>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer == null)
            {
                this.logger.Warn("Refused to sort the books. Comparer is invalid.", new ArgumentNullException(nameof(comparer)), comparer);
                throw new ArgumentNullException(nameof(comparer));
            }

            this.books.Sort(comparer);
            this.logger.Debug("Books were successfully sorted.");
        }

        #endregion

        #region IBookListStorage

        /// <summary>
        /// Save list of books to the storage.
        /// </summary>
        /// <param name="storage"> Storage to save the list of books. </param>
        public void Save(IBookListStorage storage)
        {
            if (storage == null)
            {
                this.logger.Error("Refused to store the books. Invalid storage.", new ArgumentNullException(nameof(storage)), storage);
                throw new ArgumentNullException(nameof(storage));
            }

            storage.Save(this.books);
            this.logger.Debug("Books were successfully saved in the storage.");
        }

        /// <summary>
        /// Load list of books from the storage.
        /// </summary>
        /// <param name="storage"> Storage to load the list of books from. </param>
        public void Load(IBookListStorage storage)
        {
            if (storage?.Load() == null)
            {
                this.logger.Error("Refused to load the books. Invalid storage.", new ArgumentNullException(nameof(storage)), storage);
                throw new ArgumentNullException(nameof(storage));
            }
            else
            {
                this.books = storage.Load();
                this.logger.Debug("Books were successfully loaded to the storage.");
            }
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Check if the book contains in the books.
        /// </summary>
        /// <param name="book">The book given.</param>
        /// <returns>True if contains.</returns>
        private bool IsContains(Book book)
        {
            if (book == null)
            {
                return false;
            }

            foreach (Book i in this.books)
            {
                if (book.Equals(i))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
