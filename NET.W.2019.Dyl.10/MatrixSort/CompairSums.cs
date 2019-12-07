//-----------------------------------------------------------------------
// <copyright file="CompairSums.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace MatrixSort
{
    using System.Collections.Generic;
    using System.Linq;
    using static MatrixSort;

    /// <summary>
    /// Compares two arrays by their sum-values
    /// </summary>
    public class CompairSums : IComparer<int[]>
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

            int xSum = x.Sum();
            int ySum = y.Sum();

            return xSum < ySum ? -1
                              : xSum < ySum ? 0
                                            : 1;
        }
    }
}
