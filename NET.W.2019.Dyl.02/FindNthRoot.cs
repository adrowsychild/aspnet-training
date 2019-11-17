using System;

namespace NET.W._2019.Dyl._02
{
    class Program
    {
		/// <summary>
        /// A method that finds the root of the nth power from the number
        /// with the given presicion
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        /// <param name="eps"></param>
        /// <returns>double</returns>
        public static double FindNthRoot(double number, double n, double eps)
        {
            if (n <= 0)
                throw new ArgumentException();

            if ((number <= 0) && n % 2 == 0)
                throw new ArgumentException();

            if (eps <= 0)
                throw new ArgumentException();

            double output = number/n;
            double prev = 0;
            while (Math.Abs(prev - output) >= eps)
            {
                prev = output;
                output = (1.0 / n) * ((n - 1) * output + number / (Math.Pow(output, n - 1)));
            }
			
            return output;
        }
	}
}