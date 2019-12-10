//-----------------------------------------------------------------------
// <copyright file="BookFormat.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Books
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Additional methods for formatting the instance of Book in different ways.
    /// </summary>
    public class BookFormat : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Gets the format needed from the user.
        /// </summary>
        /// <param name="formatType">the format given.</param>
        /// <returns>FormatType instance if can be supplied.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        string result = "";

        /// <summary>
        /// Provides formatting
        /// </summary>
        /// <param name="format">The format given</param>
        /// <param name="arg">The object to provide format onto</param>
        /// <param name="formatProvider">IFormatProvider instance</param>
        /// <returns>Formatted string</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is Book))
            {
                try
                {
                    return this.HandleOtherFormats(format, arg);
                }
                catch (FormatException ex)
                {
                    throw new FormatException(nameof(ex));
                }
            }

            Book book = arg as Book;

            if (string.IsNullOrEmpty(format))
            {
                return book.ToString();
            }

            bool wasFormatted = false;

            foreach (char c in format)
            {
                switch (c)
                {
                    case 'I':
                        if (wasFormatted)
                            result += ", ";
                        else
                            wasFormatted = true;
                        result += "ISBN 13: ";
                        result += book.ISBN;
                        break;
                    case 'A':
                        if (wasFormatted)
                            result += ", ";
                        else
                            wasFormatted = true;
                        result += book.Author;
                        break;
                    case 'T':
                        if (wasFormatted)
                            result += ", ";
                        else
                            wasFormatted = true;
                        result += "\"";
                        result += book.Title;
                        result += "\"";
                        break;
                    case 'Y':
                        if (wasFormatted)
                            result += ", ";
                        else
                            wasFormatted = true;
                        result += book.Year;
                        break;
                    case 'P':
                        if (wasFormatted)
                            result += ", ";
                        else
                            wasFormatted = true;
                        result += book.Price;
                        result += "$";
                        break;
                    case 'R':
                        if (wasFormatted)
                            result += ", ";
                        else
                            wasFormatted = true;
                        result += book.Publisher;
                        break;

                    case 'N':
                        if (wasFormatted)
                            result += ", ";
                        else
                            wasFormatted = true;
                        result += "P. ";
                        result += book.NumOfPages;
                        break;
                }
            }

            if (string.IsNullOrEmpty(result))
            {
                try
                {
                    this.HandleOtherFormats(format, arg);
                }
                catch (FormatException ex)
                {
                    throw new FormatException(nameof(ex));
                }
            }

            return result;
        }

        /// <summary>
        /// Default formatting if instance is not a book.
        /// </summary>
        /// <param name="format">Format given.</param>
        /// <param name="arg">Object to format.</param>
        /// <returns>Formatted string</returns>
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }

            if (arg != null)
            {
                return arg.ToString();
            }

            return string.Empty;
        }
    }
}
