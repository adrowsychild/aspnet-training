using System;

namespace NET.W._2019.Dyl._02
{
    class Program
    {
	/// <summary>
        /// A method that inserts bits (from j to i) from one number to another
        /// so that bits of the second number took the positions from j to i
        /// </summary>
        /// <param name="numSourse"></param>
        /// <param name="numIn"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>Int32</returns>
        public static int InsertNumber(int numSourse, int numIn, int i, int j)
        {
            int result = 0;
            int mask = 0;
            int numInShifted = numIn << i;

            
            for (int k = i; k <= j; k++)
                mask = setOne(mask, k);

            result = (mask & numInShifted) | (~mask & numSourse);

            return result;
    }

        private static int setOne(int numSourse, int i)
        {
            int tmp = 1 << i;
            numSourse = numSourse | tmp;

            return numSourse;
        }
	}
}
