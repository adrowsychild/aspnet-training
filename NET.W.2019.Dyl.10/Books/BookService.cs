//-----------------------------------------------------------------------
// <copyright file="BookService.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Books
{
    using System;
    using System.Collections.Generic;

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
        /// Initializes a new instance of the BookService class.
        /// </summary>
        public BookService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BookService class.
        /// </summary>
        /// <param name="books">The list of books.</param>
        public BookService(List<Book> books)
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
                throw new ArgumentNullException(nameof(book));
            }

            if (this.IsContains(book))
            {
                throw new InvalidOperationException(nameof(book));
            }

            this.books.Add(book);
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
                throw new ArgumentNullException(nameof(book));
            }

            if (!this.IsContains(book))
            {
                throw new InvalidOperationException(nameof(book));
            }

            foreach (Book b in this.books)
            {
                if (b.Equals(book))
                {
                    this.books.Remove(b);
                }
            }
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
                throw new ArgumentNullException(nameof(predicate));
            }

            List<Book> found = this.books.FindAll(predicate);
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
                throw new ArgumentNullException(nameof(comparer));
            }

            this.books.Sort(comparer);
        }

        #endregion

        #region IBookListStorage

        /// <summary>
        /// Save list of books to <see cref="storage"/>.
        /// </summary>
        /// <param name="storage"> Storage to save the list of books. </param>
        public void Save(IBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));

            storage.Save(this.books);
        }

        /// <summary>
        /// Load list of books from <see cref="storage"/>.
        /// </summary>
        /// <returns> Storage to load a list of books. </returns>
        public void Load(IBookListStorage storage)
        {
            this.books = storage?.Load() ?? throw new ArgumentNullException(nameof(storage));
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
