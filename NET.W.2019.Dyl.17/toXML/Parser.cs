//-----------------------------------------------------------------------
// <copyright file="Parser.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace toXML
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Parser.
    /// </summary>
    public class Parser : IParser
    {
        /// <summary>
        /// Parses the string to url.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public URL Parse(string input, ILogger logger)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            if (!IsURL(input))
            {
                logger.Error("Wrong string.");
            }

            URL url = new URL();
            string[] splitedURL;
            if (input.Contains("http://"))
            {
                url.TransferProtocol = input.Substring(0, 7);
                splitedURL = input.Substring(7).Split('/', '?');
            }
            else
            {
                url.TransferProtocol = input.Substring(0, 8);
                splitedURL = input.Substring(8).Split('/', '?');
            }

            url.HostName = splitedURL[0];

            for (int i = 1; i < splitedURL.Length; i++)
            {
                if (!splitedURL[i].Contains("="))
                {
                    url.Segments.Add(splitedURL[i]);
                }
                else
                {
                    var parameters = splitedURL[i].Split('=');
                    url.ParametersKeyValue.Add(new KeyValuePair<string, string>(parameters[0], parameters[1]));
                }
            }

            return url;
        }

        /// <summary>
        /// Checks weather given string is a url or not. 
        /// </summary>
        /// <param name="input">Given string.</param>
        /// <returns>Yes or no.</returns>
        private bool IsURL(string input)
        {
            Regex regex = new Regex(@"(http://|https://)", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(input))
            {
                return false;
            }

            return true;
        }
    }
}
