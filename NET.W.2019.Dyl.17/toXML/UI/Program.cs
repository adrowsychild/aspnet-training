//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace toXML
{
    using System;

    public class Program
    {
        static void Main()
        {
            DataProvider provider = new DataProvider(@"C:\Users\Hp\source\repos\NET.W.2019.Dyl.17\toXML\UI\urls.txt", new Parser(), new NLogger());
            XMLCreator.CreateXml(provider.Load(), @"C:\Users\Hp\source\repos\NET.W.2019.Dyl.17\toXML\UI\urls.xml");
        }
    }
}
