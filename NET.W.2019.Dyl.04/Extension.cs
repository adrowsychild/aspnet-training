//-------------------------
// <copyright file="Extension.cs" company="EPAM">
//     .NET training
// </copyright>
//-------------------------

namespace NET.W._2019.Dyl._04
{
    using System;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// A class for extension
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Implementing binary conversion using bit converter
        /// </summary>
        /// <param name="db">Double value</param>
        /// <returns>String in binary format</returns>
        public static string DoubleToBinaryString(this double db)
        {
            BitArray bitArray = new BitArray(BitConverter.GetBytes(db));
            StringBuilder res = new StringBuilder(64);

            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                if (bitArray[i] == false)
                {
                    res.Append('0');
                }
                else
                {
                    res.Append('1');
                }
            }

            return res.ToString();
        }
    }

    public class Program
    {
        public static void Main()
        {
            
        }
    }
}