//-----------------------------------------------------------------------
// <copyright file="XMLCreator.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace toXML
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public static class XMLCreator
    {
        /// <summary>
        /// Creates XML file with the list of URLs.
        /// </summary>
        /// <param name="urls">The list of URLs.</param>
        /// <param name="fileName">The path to the xml-file.</param>
        public static void CreateXml(IEnumerable<URL> urls, string fileName)
        {
            XDocument document = new XDocument();
            XElement root = new XElement("urlAddresses");

            foreach (var item in urls)
            {
                root.Add(CreateXmlElement(item));
            }

            document.Add(root);
            document.Save(fileName);
        }

        private static XElement CreateXmlElement(URL url)
        {
            XElement xmlElement = new XElement("urlAdresses");
            XElement hostElement = new XElement("host", new XAttribute("name", url.HostName));
            xmlElement.Add(hostElement);

            XElement uri = new XElement("uri");
            foreach (var item in url.Segments)
            {
                uri.Add(new XElement("segment", item));
            }
            xmlElement.Add(uri);

            XElement parameters = new XElement("parameters");
            foreach (var item in url.ParametersKeyValue)
            {
                parameters.Add(new XElement("parameter", new XAttribute("value", item.Value),
                    new XAttribute("key", item.Key)));
            }
            xmlElement.Add(parameters);

            return xmlElement;
        }
    }
}
