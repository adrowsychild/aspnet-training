//-----------------------------------------------------------------------
// <copyright file="FileStorage.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Books
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Class for storage in binary file.
    /// </summary>
    public class FileStorage : IBookListStorage
    {
        /// <summary>
        /// The path of the file to store at and load from
        /// </summary>
        private readonly string filePath;

        /// <summary>
        /// Initializes a new instance of the FileStorage class.
        /// </summary>
        /// <param name="filePath">The path to store file at.</param>
        public FileStorage(string filePath)
        {
            if (this.filePath == filePath)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
        }

        /// <summary>
        /// Implementation of IBookListService to store information in binary file.
        /// </summary>
        /// <param name="books">The list of books to store information about.</param>
        public void Save(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(this.filePath, FileMode.Create)))
            {
                IFormatProvider fmt = new BookFormat();
                foreach (Book b in books)
                {
                    writer.Write(b.ToString("IATYP", fmt));
                }
            }
        }

        /// <summary>
        /// Implementation of IBookListService to load information from binary file.
        /// </summary>
        /// <returns>The list of books.</returns>
        public List<Book> Load()
        {
            if (!File.Exists(this.filePath))
            {
                throw new InvalidOperationException("Enter a correct filepath");
            }

            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(this.filePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string authorName = reader.ReadString();
                    string title = reader.ReadString();
                    string publisher = reader.ReadString();
                    int numberOfPages = reader.ReadInt32();
                    int year = reader.ReadInt32();
                    decimal price = reader.ReadDecimal();

                    books.Add(new Book(isbn, authorName, title, publisher, numberOfPages, year, price));
                }
            }

            return books;
        }
    }
}
