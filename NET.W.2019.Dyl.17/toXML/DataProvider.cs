//-----------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace toXML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides the list of URLs.
    /// </summary>
    public class DataProvider
    {
        private readonly string filePath;
        private readonly IParser parser;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the DataProvider class.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="parser"></param>
        /// <param name="logger"></param>
        public DataProvider(string filePath, IParser parser, ILogger logger)
        {
            this.filePath = filePath ?? throw new ArgumentNullException();
            this.parser = parser ?? throw new ArgumentNullException();
            this.logger = logger ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Gets the list of parsed URLs.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<URL> Load()
        {
            IEnumerable<string> urlList = File.ReadLines(filePath);
            var parsedUrls = new List<URL>();

            foreach (var url in urlList)
            {
                parsedUrls.Add(parser.Parse(url, logger));
            }

            return parsedUrls;
        }
    }
}
