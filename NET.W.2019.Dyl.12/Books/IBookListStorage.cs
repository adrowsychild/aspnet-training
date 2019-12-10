//-----------------------------------------------------------------------
// <copyright file="IBookListStorage.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Books
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for doing different kinds of storage.
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Save list of books in a specified storage.
        /// </summary>
        /// <param name="books"> List of books. </param>
        void Save(IEnumerable<Book> books);

        /// <summary>
        /// Save list of books in specified storage.
        /// </summary>
        /// <returns> List of books. </returns>
        List<Book> Load();
    }
}
