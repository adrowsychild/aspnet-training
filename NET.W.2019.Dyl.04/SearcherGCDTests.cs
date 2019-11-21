using System;
using NUnit.Framework;
using static NET.W._2019.Dyl._04.SearcherGCD;

namespace NET.W._2019.Dyl._04
{
    [TestFixture]
    public class SearcherGCDTests
    {

        [TestCase(18, -12, 6)]
        [TestCase(1000, 975, 25)]
        [TestCase(24, 24, 24)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 0, 0)]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_LeftNumGreaterThenRight_ReturnsGCD(long a, long b, long expectedRes)
        {
            //act
            long gcd = SearchByEuclid(a, b);

            //assert 
            Assert.AreEqual(expectedRes, gcd);
        }

        [TestCase(975, 1000, 25)]
        [TestCase(-18, 12, 6)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_RightNumGreaterThenLeft_ReturnsGCD(long a, long b, long expectedRes)
        {
            //act
            double gcd = SearchByEuclid(a, b);

            //assert 
            Assert.AreEqual(expectedRes, gcd);
        }

        [TestCase(18, -12, 24, 6)]
        [TestCase(1000, 975, 250, 25)]
        [TestCase(24, 24, -24, 24)]
        [TestCase(1, 0, 0, 1)]
        [TestCase(0, 0, 0, 0)]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_ThreeParams_ReturnsGCD(long a, long b, long c, long expectedRes)
        {
            //act
            long time;
            long gcd = SearchByEuclid(out time, a, b, c);

            //assert 
            Assert.AreEqual(expectedRes, gcd);
        }


        [TestCase(6, 18, -12, 24, 36)]
        [TestCase(25, 1000, 975, 250, -1250, 250, -625)]
        [TestCase(24, 24, -24, 24, 24, 24, -24)]
        [TestCase(1, 0, 0, 0, 0, 0, 0, 1)]
        [TestCase(0, 0, 0, 0, 0)]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_GoodNums_ReturnsGCD(long expectedRes, params long[] nums)
        {
            //act
            long time;
            long gcd = SearchByEuclid(out time, nums);

            //assert 
            Assert.AreEqual(expectedRes, gcd);
        }


        [Test]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_NullArray_ThrowsArgumentNullExceptions()
        {
            long time;
            var ex = Assert.Catch<ArgumentNullException>(() => SearchByEuclid(out time, null));
            StringAssert.Contains("Value cannot be null.", ex.Message);
        }

        [TestCase(new long[] { })]
        [TestCase(new long[] { 1 })]
        [Category("Classical Euclidean algorithm")]
        public void SearchByEuclid_ArrayLengthLessThanTwo_ThrowsArgumentExceptions(params long[] nums)
        {
            long time;
            var ex = Assert.Catch<ArgumentException>(() => SearchByEuclid(out time, nums));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }

        [TestCase(18, -12, 6)]
        [TestCase(1000, 975, 25)]
        [TestCase(24, 24, 24)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 0, 0)]
        [Category("Stein's algorithm")]
        public void SearchByStein_LeftNumGreaterThenRight_ReturnsGCD(long a, long b, long expectedRes)
        {
            //act
            long gcd = SearchByStein(a, b);

            //assert 
            Assert.AreEqual(expectedRes, gcd);
        }

        [TestCase(975, 1000, 25)]
        [TestCase(-18, 12, 6)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [Category("Stein's algorithm")]
        public void SearchByStein_RightNumGreaterThenLeft_ReturnsGCD(long a, long b, long expectedRes)
        {
            //act
            long gcd = SearchByStein(a, b);

            //assert 
            Assert.AreEqual(expectedRes, gcd);
        }

 
        [TestCase(18, -12, 24, 6)]
        [TestCase(1000, 975, 250, 25)]
        [TestCase(24, 24, -24, 24)]
        [TestCase(1, 0, 0, 1)]
        [TestCase(0, 0, 0, 0)]
        [Category("Stein's algorithm")]
        public void SearchByStein_ThreeParams_ReturnsGCD(long a, long b, long c, long expectedRes)
        {
            //act
            long time;
            long gcd = SearchByStein(out time, a, b, c);

            //assert 
            Assert.AreEqual(expectedRes, gcd);
        }

        [TestCase(6, 18, -12, 24, 36)]
        [TestCase(25, 1000, 975, 250, -1250, 250, -625)]
        [TestCase(24, 24, -24, 24, 24, 24, -24)]
        [TestCase(1, 0, 0, 0, 0, 0, 0, 1)]
        [TestCase(0, 0, 0, 0, 0)]
        [Category("Stein's algorithm")]
        public void SearchByStein_GoodNums_ReturnsGCD(long expectedRes, params long[] nums)
        {
            long time;

            //act
            long gcd = SearchByStein(out time, nums);

            //assert 
            Assert.AreEqual(expectedRes, gcd);
        }


        [Test]
        [Category("Stein's algorithm")]
        public void SearchByStein_NullArray_ThrowsArgumentNullExceptions()
        {
            long time;
            var ex = Assert.Catch<ArgumentNullException>(() => SearchByStein(out time, null));
            StringAssert.Contains("Value cannot be null.", ex.Message);
        }

        [TestCase(new long[] { })]
        [TestCase(new long[] { 1 })]
        [Category("Stein's algorithm")]
        public void SearchByStein_ArrayLengthLessThanTwo_ThrowsArgumentExceptions(params long[] nums)
        {
            long time;
            var ex = Assert.Catch<ArgumentException>(() => SearchByStein(out time, nums));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }

    }
}