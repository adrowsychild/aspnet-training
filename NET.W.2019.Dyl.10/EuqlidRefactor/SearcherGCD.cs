﻿//-----------------------------------------------------------------------
// <copyright file="SearcherGCD.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace EuqlidRefactor
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The class to compute the Greatest Common Divisor (GCD) of numbers.
    /// </summary>
    public static class SearcherGCD
    {
        /// <summary>
        /// Computes GCD of two numbers by classical Euclidian algorithm.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>GCD of two numbers in long representation.</returns>
        public static long SearchByEuclid(long a, long b)
        {
            while (a != 0)
            {
                long temp = a;
                a = b % a;
                b = temp;
            }

            return Math.Abs(b);
        }

        /// <summary>
        /// Computes GCD of two numbers by classical Euclidian algorithm.
        /// </summary>
        /// <param name="time">The algorithm running time in long representation.</param>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>GCD of two numbers in long representation and also the running time. </returns>
        public static long SearchByEuclid(out long time, long a, long b) => GCD(SearchByEuclid, a, b, out time);

        /// <summary>
        /// Computes GCD of some numbers by classical Euclidian algorithm.
        /// </summary>
        /// <param name="nums">Array of numbers</param>
        /// <returns>GCD of some numbers in long representation</returns>
        public static long SearchByEuclid(params long[] nums) => GCD(SearchByStein, nums);

        /// <summary>
        /// Computes GCD of some numbers by classical Euclidian algorithm.
        /// </summary>
        /// <returns>
        /// GCD of some numbers in long representation and also the running time.
        /// </returns>
        /// <param name="time">The algorithm running time in long representation. </param>
        /// <param name="nums">Array of numbers</param>
        public static long SearchByEuclid(out long time, params long[] nums) => GCD(SearchByStein, out time, nums);

        /// <summary>
        /// Computes GCD of two numbers by Stein's algorithm.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>GCD of two numbers in long representation</returns>
        public static long SearchByStein(long a, long b)
        {
            long? gcd = null;

            if (a == 0)
            {
                gcd = b;
            }
            else if (b == 0)
            {
                gcd = a;
            }
            else if (a == b)
            {
                gcd = a;
            }
            else if (a == 1 || b == 1)
            {
                gcd = 1;
            }

            if (gcd != null)
            {
                return Math.Abs((long)gcd);
            }

            if ((a & 1) == 0)
            {
                gcd = ((b & 1) == 0)
                    ? SearchByStein(a >> 1, b >> 1) << 1
                    : SearchByStein(a >> 1, b);
            }
            else
            {
                gcd = ((b & 1) == 0)
                    ? SearchByStein(a, b >> 1)
                    : SearchByStein(b, a > b ? a - b : b - a);
            }

            return Math.Abs((long)gcd);
        }

        /// <summary>
        /// Computes GCD of two numbers by Stein's algorithm.
        /// </summary>
        /// <param name="time">The algorithm running time in long representation.</param>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>GCD of two numbers in long representation and also the running time.</returns>
        public static long SearchByStein(out long time, long a, long b) => GCD(SearchByStein, a, b, out time);

        /// <summary>
        /// Computes GCD of some numbers by Stein's algorithm.
        /// </summary>
        /// <param name="nums">Array of numbers</param>
        /// <returns>GCD of some numbers in long representation</returns>
        public static long SearchByStein(params long[] nums) => GCD(SearchByStein, nums);

        /// <summary>
        /// Computes GCD of some numbers by Stein's algorithm.
        /// </summary>
        /// <param name="time">The algorithm running time in long representation.</param>
        /// <param name="nums">Array of numbers</param>
        /// <returns>GCD of some numbers in long representation and also the running time. </returns>
        public static long SearchByStein(out long time, params long[] nums) => GCD(SearchByStein, out time, nums);

        /// <summary>
        /// Checks input array
        /// </summary>
        /// <param name="nums">Array of numbers</param>
        private static void CheckInputArray(long[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException();
            }

            if (nums.Length < 2)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Performs methods for finding GCD for two numbers with detecting time.
        /// </summary>
        /// <param name="gcdFunc">Method taking two numbers</param>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <param name="time">The running time</param>
        /// <returns>
        /// GCD of two numbers in long representation and the running time of the algorithm
        /// </returns>
        private static long GCD(Func<long, long, long> gcdFunc, long a, long b, out long time)
        {
            var sw = Stopwatch.StartNew();

            long gcd = gcdFunc(a, b);

            time = sw.ElapsedTicks;

            return gcd;
        }

        /// <summary>
        /// Performs methods for finding GCD for some numbers.
        /// </summary>
        /// <param name="gcdFunc">Method taking an array of numbers</param>
        /// <param name="nums">Array of numbers</param>
        /// <returns>GCD of some numbers in long representation and the running time of the algorithm</returns>
        private static long GCD(Func<long, long, long> gcdFunc, params long[] nums)
        {
            CheckInputArray(nums);

            long gcd = gcdFunc(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = gcdFunc(gcd, nums[i]);
            }

            return gcd;
        }

        /// <summary>
        /// /// Performs methods for finding GCD for some numbers with detecting time.
        /// </summary>
        /// <param name="gcdFunc">Method taking an array of numbers and the running time.</param>
        /// <param name="time">The running time</param>
        /// <param name="nums">Array of numbers</param>
        /// <returns>GCD of some numbers in long representation and the running time of the algorithm</returns>
        private static long GCD(Func<long[], long> gcdFunc, out long time, params long[] nums)
        {
            var sw = Stopwatch.StartNew();

            long gcd = gcdFunc(nums);

            time = sw.ElapsedTicks;

            return gcd;
        }
    }
}