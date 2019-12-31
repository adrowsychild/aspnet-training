//-----------------------------------------------------------------------
// <copyright file="URL.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace toXML
{
    using System;
    using System.Collections.Generic;

    public class URL
    {
        /// <summary>
        /// Gets or sets whether http or https
        /// </summary>
        public string TransferProtocol { get; set; }

        /// <summary>
        /// Gets or sets the Host Name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the collection of segments in the URL.
        /// </summary>
        public List<string> Segments { get; set; } = new List<string>();

        /// <summary>
        /// Parameters by pair "key-value".
        /// </summary>
        public List<KeyValuePair<string, string>> ParametersKeyValue { get; set; } =
            new List<KeyValuePair<string, string>>();
    }
}
