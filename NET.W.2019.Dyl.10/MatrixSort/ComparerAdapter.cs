//-----------------------------------------------------------------------
// <copyright file="ComparerAdapter.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace MatrixSort
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for adapting interface's methods of IComparer for using specified delegate.   
    /// </summary>
    public class ComparerAdapter : IComparer<int[]>
    {
        /// <summary>
        /// Delegate for sorting logic
        /// </summary>
        private readonly Func<int[], int[], int> comparer;

        /// <summary>
        /// Initializes a new instance of the ComparerAdapter class
        /// </summary>
        /// <param name="comparer">Delegate with sorting logic</param>
        public ComparerAdapter(Func<int[], int[], int> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("Comparer cannot be null.");
            }

            this.comparer = comparer;
        }

        /// <summary>
        /// Adapts this method for use the specified delegate.
        /// </summary>
        /// <param name="a">The first array to compare</param>
        /// <param name="b">The second array to compare</param>
        /// <returns>
        /// Integer that indicates the relativity between x and y
        /// </returns>
        public int Compare(int[] a, int[] b)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            return this.comparer.Invoke(a, b);
        }
    }
}
