//-----------------------------------------------------------------------
// <copyright file="IParser.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace toXML
{
    using System;

    /// <summary>
    /// URL-parser.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Converts the given string to URL.
        /// </summary>
        /// <param name="input">String to convert.</param>
        /// <param name="logger">Logger to inform about the failure.</param>
        /// <returns></returns>
        URL Parse(string input, ILogger logger);
    }
}
