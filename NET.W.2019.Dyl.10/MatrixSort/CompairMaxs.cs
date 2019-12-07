//-----------------------------------------------------------------------
// <copyright file="CompairMaxs.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace MatrixSort
{
    using System.Collections.Generic;
    using System.Linq;
    using static MatrixSort;

    /// <summary>
    /// Compares two arrays by their max-values
    /// </summary>
    public class CompairMaxs : IComparer<int[]>
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

            int xMax = x.Max();
            int yMax = y.Max();

            return xMax < yMax ? -1
                               : xMax < yMax ? 0
                                             : 1;
        }
    }
}
