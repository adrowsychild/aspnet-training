//-----------------------------------------------------------------------
// <copyright file="BubbleSort.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------
namespace BubbleSort
{
    using System;

    /// <summary>
    /// A class for sorting a jagged array by different ways
    /// </summary>
    public static class BubbleSort
    {
        /// <summary>
        /// Sorts array by the sum of the elements of the row
        /// In the order given
        /// </summary>
        /// <param name="arr">The input array</param>
        /// <param name="order">The order given</param>
        /// <returns>Sorted array</returns>
        public static int[][] SortBySum(int[][] arr, bool order)
        {
            if (CheckArr(arr) == null)
            {
                return arr;
            }

            int[] sum = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sum[i] += arr[i][j];
                }
            }

            int tempNum;
            int[] tempArr;
            int swapcounter = -1;
            while (swapcounter != 0)
            {
                swapcounter = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (order)
                    {
                        if (sum[i] > sum[i + 1])
                        {
                            tempNum = sum[i];
                            sum[i] = sum[i + 1];
                            sum[i + 1] = tempNum;

                            tempArr = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = tempArr;
                            swapcounter++;
                        }
                    }
                    else
                    {
                        if (sum[i] < sum[i + 1])
                        {
                            tempNum = sum[i];
                            sum[i] = sum[i + 1];
                            sum[i + 1] = tempNum;

                            tempArr = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = tempArr;
                            swapcounter++;
                        }
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// Sorts array by the Max elements of the row
        /// In the order given
        /// </summary>
        /// <param name="arr">The input array</param>
        /// <param name="order">The order given</param>
        /// <returns>Sorted array</returns>
        public static int[][] SortByMax(int[][] arr, bool order)
        {
            if (CheckArr(arr) == null)
            {
                return arr;
            }

            int[] max = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                max[i] = int.MinValue;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] > max[i])
                    {
                        max[i] = arr[i][j];
                    }
                }
            }

            int tempNum;
            int[] tempArr;
            int swapcounter = -1;
            while (swapcounter != 0)
            {
                swapcounter = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (order)
                    {
                        if (max[i] > max[i + 1])
                        {
                            tempNum = max[i];
                            max[i] = max[i + 1];
                            max[i + 1] = tempNum;

                            tempArr = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = tempArr;
                            swapcounter++;
                        }
                    }
                    else
                    {
                        if (max[i] < max[i + 1])
                        {
                            tempNum = max[i];
                            max[i] = max[i + 1];
                            max[i + 1] = tempNum;

                            tempArr = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = tempArr;
                            swapcounter++;
                        }
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// Sorts array by the Max elements of the row
        /// In the order given
        /// </summary>
        /// <param name="arr">The input array</param>
        /// <param name="order">The order given</param>
        /// <returns>Sorted array</returns>
        public static int[][] SortByMin(int[][] arr, bool order)
        {
            if (CheckArr(arr) == null)
            {
                return arr;
            }

            int[] min = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                min[i] = int.MaxValue;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] < min[i])
                    {
                        min[i] = arr[i][j];
                    }
                }
            }

            int tempNum;
            int[] tempArr;
            int swapcounter = -1;
            while (swapcounter != 0)
            {
                swapcounter = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (order)
                    {
                        if (min[i] > min[i + 1])
                        {
                            tempNum = min[i];
                            min[i] = min[i + 1];
                            min[i + 1] = tempNum;

                            tempArr = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = tempArr;
                            swapcounter++;
                        }
                    }
                    else
                    {
                        if (min[i] < min[i + 1])
                        {
                            tempNum = min[i];
                            min[i] = min[i + 1];
                            min[i + 1] = tempNum;

                            tempArr = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = tempArr;
                            swapcounter++;
                        }
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// Private method to check the input
        /// </summary>
        /// <param name="arr">The array to check</param>
        /// <returns>The array, if it suits the constrains</returns>
        private static int[][] CheckArr(int[][] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Value cannot be null.");
            }

            if (arr.Length == 1)
            {
                return null;
            }

            return arr;
        }
    }
}
