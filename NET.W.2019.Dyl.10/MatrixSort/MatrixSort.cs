//-----------------------------------------------------------------------
// <copyright file="MatrixSort.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace MatrixSort
{
    using System;
    using System.Collections.Generic;
   
    /// <summary>
    /// A class for sorting a jagged array by different ways
    /// </summary>
    public static class MatrixSort
    {
        /// <summary>
        /// Sorts array by the sum of the elements of the row
        /// In the order given
        /// </summary>
        /// <param name="arr">The input array</param>
        /// <param name="comparer">The way of sorting in interface</param>>
        public static void Sort(this int[][] arr, IComparer<int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("Comparer cannot be null.");
            }

            CheckArr(arr);

            Array.Sort(arr, comparer.Compare);
        }

        /// <summary>
        /// Sorts array by the sum of the elements of the row
        /// In the order given
        /// </summary>
        /// <param name="arr">The input array</param>
        /// <param name="comparer">The way of sorting in delegate</param>>
        public static void Sort(this int[][] arr, Func<int[], int[], int> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("Comparer cannot be null.");
            }

            CheckArr(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    int resOfCompare = comparer.Invoke(arr[j], arr[j + 1]);

                    if (resOfCompare == 1)
                    {
                        arr.Swap(j, j + 1);
                    }
                    else if (resOfCompare == -1)
                    {
                        arr.Swap(j + 1, j);
                    }
                }
            }
        }

        /// <summary>
        /// Method to check the input for null
        /// </summary>
        /// <param name="arr">The array of arrays to check</param>
        public static void CheckArr(int[][] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array cannot be null.");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                CheckArr(arr[i]);
            }
        }

        /// <summary>
        /// Method to check the input for null
        /// </summary>
        /// <param name="arr">The single-dimensional array to check</param>
        public static void CheckArr(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array cannot be null.");
            }
        }

        /// <summary>
        /// Swaps two 
        /// </summary>
        /// <param name="arr">Array to swap rows in</param>
        /// <param name="a">The row to swap</param>
        /// <param name="b">The row to be swapped with</param>
        private static void Swap(this int[][] arr, int a, int b)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array cannot be null.");
            }

            var tmpArr = arr[a];
            arr[a] = arr[b];
            arr[b] = tmpArr;
        }
    }
}