namespace NET.W._2019.Dyl._02
{
    class Program
    {
	/// <summary>
        /// A method that takes a list of numbers
        /// and filters the list so that it contains only the numbers
        /// that has a given digit in it
        /// </summary>
        /// <param name="num"></param>
        /// <param name="input"></param>
        /// <returns>List<int></returns>
        public static List<int> FilterDigit(int num, params int[] input)
        {
            if (input == null)
                throw new ArgumentNullException();

            if (input.Length == 0 || (num.ToString().Length > 1))
                throw new ArgumentException();

            List<int> output = new List<int>();

            string tempdig;
            char numchar = (num.ToString())[0];

            for (int i = 0; i < input.Length; i++)
            {
                tempdig = input[i].ToString();
                foreach (char c in tempdig)
                {
                    if (c == numchar)
                    {
                        output.Add(input[i]);
                        break;
                    }
                }
            }
		
            return output;
        }
}
