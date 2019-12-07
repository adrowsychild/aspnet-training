using System;
using NUnit.Framework;
using static Polynomial.Polynomial;

namespace PolynomialTests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        [Category("Polynomial")]
        public void Polynomial_NullArray_ThrowsArguementException()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => new Polynomial.Polynomial(null));
        }

        [Test]
        [Category("Polynomial")]
        public void Polynomial_EmptyArray_ThrowsArgumentException()
        {
            double[] arr = { };

            var ex = Assert.Catch<ArgumentException>(() => new Polynomial.Polynomial(arr));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }

        [Test]
        [Category("Polynomial")]
        public void Polynomial_ArrayWithNullMembers_ThrowsArgumentException()
        {
            double[] arr = { 7, 3, 0, 9 };

            var ex = Assert.Catch<ArgumentException>(() => new Polynomial.Polynomial(arr));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }

        [Test]
        [Category("Polynomial")]
        public void CalculateSum_5CoefficientsAndNum2_Returns129()
        {
            double[] coeffs = { 7.0, 5.0, 3.0, 1.0 };
            Polynomial.Polynomial pol = new Polynomial.Polynomial(coeffs);
            double expectedResult = 83;   
            //7*2^3 + 5*2^2 + 3*2^1 + 1*2^0 = 56+20+6+1=83

            double res = pol.CalculateSum(2);

            Assert.AreEqual(expectedResult, res);
        }

        public void Indexer_Pass4_Returns2ndCoefficient()
        {
            double[] arr = { 5.0, 4.0, 3.0, 2.0 };
            Polynomial.Polynomial pol = new Polynomial.Polynomial(arr);
            double expetedRes = 4.0;

            double res = pol[1];

            Assert.AreEqual(expetedRes, res);
        }

        [Test]
        [Category("Polynomial")]
        public void EqualsObj_RefEquals_RetrunsTrue()
        {
            double[] arr = { 12.34, 12.1 };
            Polynomial.Polynomial ob1 = new Polynomial.Polynomial(arr);
            object ob2 = ob1;

            Assert.True(ob1.Equals(ob2));
        }

        [Test]
        [Category("Polynomial")]
        public void EqualsPol_PolEquals_RetrunsTrue()
        {
            double[] arr = { 12.34, 12.1 };
            Polynomial.Polynomial ob1 = new Polynomial.Polynomial(arr);
            Polynomial.Polynomial ob2 = ob1;

            Assert.True(ob1.Equals(ob2));
        }

        [Test]
        [CategoryAttribute("Polynomial")]
        public void OperatorPlus_TwoPolynomial_ReturnsPolynomial()
        {
            double[] arr1 = { 12.5, 13.0, 13.5 };
            double[] arr2 = { 7.5, 7.0 };
            double[] expectedArr = { 20, 20, 13.5 };

            Polynomial.Polynomial pol1 = new Polynomial.Polynomial(arr1);
            Polynomial.Polynomial pol2 = new Polynomial.Polynomial(arr2);
            Polynomial.Polynomial expectedPol = new Polynomial.Polynomial(expectedArr);

            Polynomial.Polynomial resPol = pol1 + pol2;

            Assert.True(expectedPol == resPol);
        }

        [Test]
        [CategoryAttribute("Polynomial")]
        public void OperatorMinus_TwoPolynomial_ReturnsPolynomial()
        {
            double[] arr1 = { 7.5, 7.0 };
            double[] arr2 = { 12.5, 13.0, 13.5 };
            double[] expectedArr = { -5, -6, -13.5 };

            Polynomial.Polynomial pol1 = new Polynomial.Polynomial(arr1);
            Polynomial.Polynomial pol2 = new Polynomial.Polynomial(arr2);
            Polynomial.Polynomial expectedPol = new Polynomial.Polynomial(expectedArr);

            Polynomial.Polynomial resPol = pol1 * pol2;

            Assert.True(expectedPol == resPol);
        }

        [Test]
        [CategoryAttribute("Polynomial")]
        public void OperatorMultiply_TwoPolynomial_ReturnsPolynomial()
        {
            double[] arr1 = { -3, -2, -1 };
            double[] arr2 = { -1, -2, -4 };
            double[] expectedArr = { 3, 8, 17, 10, 4 };

            Polynomial.Polynomial pol1 = new Polynomial.Polynomial(arr1);
            Polynomial.Polynomial pol2 = new Polynomial.Polynomial(arr2);
            Polynomial.Polynomial expectedPol = new Polynomial.Polynomial(expectedArr);

            Polynomial.Polynomial resPol = pol1 * pol2;

            Assert.True(expectedPol == resPol);
        }


    }
}