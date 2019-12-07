using System;

namespace NET.W._2019.Dyl._02
{
    class Program
    {
	/// <summary>
        /// A method that takes a integer and
        /// returns the largest integer consisting of the digits of the original number,
        /// and - 1 (null), if there is no such number
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Int32</returns>
		public static int FindNextBiggerNumber(int num)
        {
            if (num < 0 || num >=int.MaxValue)
                throw new ArgumentException();

            int[] input = new int[num.ToString().Length];
            
            for (int i = input.Length - 1; i > -1; i--)
            {
                input[i] = num % 10;
                num /= 10;
            }

            int index = findIndex(input);

            if (index == -1)
                return -1;

            int temp;

            if (index < input.Length - 1)
            {
                temp = input[index];
                input[index] = input[index + 1];
                input[index + 1] = temp;
                Array.Sort(input, index + 1, input.Length - index - 1);
            }

            int output = 0;
            for (int i = 0; i < input.Length; i++)
                output += (int)(input[i] * Math.Pow(10, input.Length - 1 - i));

            return output;
        }

        private static int findIndex(int[] input)
        {
            for (int i = input.Length - 1; i > 0; i--)
            {
                if (input[i] > input[i - 1])
                    return (i - 1);
            }

            return -1;
        }
}
