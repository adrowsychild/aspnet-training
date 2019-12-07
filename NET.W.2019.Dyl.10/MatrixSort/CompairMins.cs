﻿//-----------------------------------------------------------------------
// <copyright file="CompairMins.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace MatrixSort
{
    using System.Collections.Generic;
    using System.Linq;
    using static MatrixSort;

    /// <summary>
    /// Compares two arrays by their min-values
    /// </summary>
    public class CompairMins : IComparer<int[]>
    {
        /// <summary>
        /// IComparer realization
        /// </summary>
        /// <param name="x">The first array to compare</param>
        /// <param name="y">The second array to compare</param>
        /// <returns>
        /// Integer that indicates the relativity between x and y
        /// </returns>
        public int Compare(int[] x, int[] y)
        {
            CheckArr(x);
            CheckArr(y);

            int xMin = x.Min();
            int yMin = y.Min();

            return xMin < yMin ? -1
                               : xMin < yMin ? 0
                                             : 1;
        }
    }
}
