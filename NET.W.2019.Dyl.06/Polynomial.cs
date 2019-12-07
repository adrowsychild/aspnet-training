//-----------------------------------------------------------------------
// <copyright file="Polynomial.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------
namespace Polynomial
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class to work with polynomials
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// A readonly field to store the coefficients
        /// </summary>
        private readonly double[] coeffs;
        
        /// <summary>
        /// Initializes a new instance of the Polynomial class
        /// </summary>
        /// <param name="inputCoeffs">A double array of input</param>
        public Polynomial(params double[] inputCoeffs)
        {
            CheckInputCoeffs(inputCoeffs);

            this.coeffs = new double[inputCoeffs.Length];
            inputCoeffs.CopyTo(this.coeffs, 0);
        }

        /// <summary>
        /// Gets the number of monomials in polynomial
        /// </summary>
        public int Length
        {
            get { return this.coeffs.Length; }
        }

        /// <summary>
        /// Indexers to get the coefficients
        /// </summary>
        /// <param name="index">The index given</param>
        /// <returns>Coefficients to get</returns>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= this.coeffs.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.coeffs[index];
            }
        }

        /// <summary>
        /// Implicit conversion to double array
        /// </summary>
        /// <param name="p">Polynomial to convert</param>
        public static implicit operator double[](Polynomial p)
        {
            return p.GetCoefficients();
        }

        #region Operators == and !=

        /// <summary>
        /// Operator overloading '=='
        /// </summary>
        /// <param name="p1">The first polynomial</param>
        /// <param name="p2">The second polynomial</param>
        /// <returns>Boolean of equality</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if ((p1 == null) || p2 == null)
            {
                return false;
            }

            return p1.GetCoefficients().SequenceEqual(p2.GetCoefficients());
        }

        /// <summary>
        /// Operator overloading '!='
        /// </summary>
        /// <param name="p1">The first polynomial</param>
        /// <param name="p2">The second polynomial</param>
        /// <returns>Boolean of equality</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #region Operator +

        /// <summary>
        /// Operator overloading '+'
        /// </summary>
        /// <param name="p1">The first polynomial</param>
        /// <param name="p2">The second polynomial</param>
        /// <returns>The sum of the two</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Sum(p1, p2));
        }

        /// <summary>
        /// Operator overloading '+'
        /// </summary>
        /// <param name="p1">The array of double</param>
        /// <param name="p2">The second polynomial</param>
        /// <returns>The sum of the two</returns>
        public static Polynomial operator +(double[] p1, Polynomial p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Sum(p1, p2));
        }

        /// <summary>
        /// Operator overloading '+'
        /// </summary>
        /// <param name="p1">The first polynomial</param>
        /// <param name="p2">The array of double</param>
        /// <returns>The sum of the two</returns>
        public static Polynomial operator +(Polynomial p1, double[] p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Sum(p1, p2));
        }

        #endregion

        #region Operator -

        /// <summary>
        /// Operator overloading '-'
        /// </summary>
        /// <param name="p1">The first polynomial</param>
        /// <param name="p2">The second polynomial</param>
        /// <returns>The subtraction of the two</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Subtr(p1, p2));
        }

        /// <summary>
        /// Operator overloading '-'
        /// </summary>
        /// <param name="p1">The array of double</param>
        /// <param name="p2">The second polynomial</param>
        /// <returns>The subtraction of the two</returns>
        public static Polynomial operator -(double[] p1, Polynomial p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Subtr(p1, p2));
        }

        /// <summary>
        /// Operator overloading '-'
        /// </summary>
        /// <param name="p1">The first polynomial</param>
        /// <param name="p2">The array of double</param>
        /// <returns>The subtraction of the two</returns>
        public static Polynomial operator -(Polynomial p1, double[] p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Subtr(p1, p2));
        }

        #endregion

        #region Operator *

        /// <summary>
        /// Operator overloading '*'
        /// </summary>
        /// <param name="p1">The first polynomial</param>
        /// <param name="p2">The second polynomial</param>
        /// <returns>The multiplication of the two</returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Mult(p1, p2));
        }

        /// <summary>
        /// Operator overloading '*'
        /// </summary>
        /// <param name="p1">The array of double</param>
        /// <param name="p2">The second polynomial</param>
        /// <returns>The multiplication of the two</returns>
        public static Polynomial operator *(double[] p1, Polynomial p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Mult(p1, p2));
        }

        /// <summary>
        /// Operator overloading '*'
        /// </summary>
        /// <param name="p1">The first polynomial</param>
        /// <param name="p2">The array of double</param>
        /// <returns>The multiplication of the two</returns>
        public static Polynomial operator *(Polynomial p1, double[] p2)
        {
            CheckInputArray(p1);
            CheckInputArray(p2);

            return new Polynomial(Mult(p1, p2));
        }

        #endregion

        #region Overloading System.Object's methods

        /// <summary>
        /// The overloading of System.ToString
        /// </summary>
        /// <returns>The string of coefficients</returns>
        public override string ToString()
        {
            string str = string.Empty;

            for (int i = 0; i < this.Length; i++)
            {
                str += this[i];
                str += ' ';
            }

            return str;
        }

        /// <summary>
        /// The overloading of System.Equals
        /// </summary>
        /// <param name="obj">The object given to compare</param>
        /// <returns>The bool of equality</returns>
        public override bool Equals(object obj)
        {
            Polynomial p = obj as Polynomial;
            if (p == null)
            {
                return false;
            }

            return this.GetCoefficients().SequenceEqual(p.GetCoefficients());
        }

        /// <summary>
        /// The overloading of System.Equals
        /// </summary>
        /// <param name="p">The polynomial given to compare</param>
        /// <returns>The bool of equality</returns>
        public bool Equals(Polynomial p)
        {
            if (p == null)
            {
                return false;
            }

            return this.GetCoefficients().SequenceEqual(p.GetCoefficients());
        }

        /// <summary>
        /// The overloading of System.GetHashCode
        /// </summary>
        /// <returns>Returns the HashCode of the coefficients</returns>
        public override int GetHashCode()
        {
            return this.GetCoefficients().GetHashCode();
        }

        #endregion

        /// <summary>
        /// Returns array of coefficients
        /// </summary>
        /// <returns>
        /// Double array of coefficients
        /// </returns>
        public double[] GetCoefficients()
        {
            double[] coeffsToReturn = new double[this.coeffs.Length];

            this.coeffs.CopyTo(coeffsToReturn, 0);

            return coeffsToReturn;
        }

        /// <summary>
        /// Calculate sum of monomials.
        /// </summary>
        /// <returns>
        /// Sum of monomials in double.
        /// </returns>
        /// <param name="num">
        /// Double variable for polynomial.
        /// </param>
        public double CalculateSum(double num)
        {
            double sum = 0;

            for (int i = 0; i < this.Length; i++)
            {
                sum += this[i] * Math.Pow(num, i);
            }

            return sum;
        }

        #region CheckInputs

        /// <summary>
        /// Checks the input of the given array of double
        /// </summary>
        /// <param name="coeffs">The array of double given</param>
        private static void CheckInputCoeffs(double[] coeffs)
        {
            if (coeffs == null)
            {
                throw new ArgumentNullException();
            }

            if (coeffs.Length == 0)
            {
                throw new ArgumentException();
            }

            foreach (double d in coeffs)
            {
                if (d == 0)
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Checks the given array on null
        /// </summary>
        /// <param name="arr1">The array given</param>
        private static void CheckInputArray(double[] arr1)
        {
            if (arr1 == null)
            {
                throw new ArgumentNullException();
            }
        }

        #endregion

        #region MathsOperations

        /// <summary>
        /// Provides the sum operation
        /// </summary>
        /// <param name="arr1">The first array of doubles</param>
        /// <param name="arr2">The second array of doubles</param>
        /// <returns>The sum of the arrays in double array</returns>
        private static double[] Sum(double[] arr1, double[] arr2)
        {
            double[] longest = (arr1.Length > arr2.Length) ? arr1 : arr2;
            double[] shortest = (longest == arr1) ? arr2 : arr1;

            double[] resArr = new double[longest.Length];
            longest.CopyTo(resArr, 0);

            for (int i = 0; i < shortest.Length; i++)
            {
                resArr[i] += shortest[i];
            }

            return resArr;
        }

        /// <summary>
        /// Provides the subtract operation
        /// </summary>
        /// <param name="arr1">The first array of doubles</param>
        /// <param name="arr2">The second array of doubles</param>
        /// <returns>The subtraction of the arrays in double array</returns>
        private static double[] Subtr(double[] arr1, double[] arr2)
        {
            double[] longest = (arr1.Length > arr2.Length) ? arr1 : arr2;
            double[] shortest = (longest == arr1) ? arr2 : arr1;

            double[] resArr = new double[longest.Length];
            longest.CopyTo(resArr, 0);

            for (int i = 0; i < shortest.Length; i++)
            {
                resArr[i] = shortest[i];
            }

            return resArr;
        }

        /// <summary>
        /// Provides the multiplicate operation
        /// </summary>
        /// <param name="arr1">The first array of doubles</param>
        /// <param name="arr2">The second array of doubles</param>
        /// <returns>The multiplication of the arrays in double array</returns>
        private static double[] Mult(double[] arr1, double[] arr2)
        {
            double[] res = new double[arr1.Length + arr2.Length - 1];

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    res[i + j] += arr1[i] * arr2[j];
                }
            }

            return res;
        }

        #endregion
    }
}
