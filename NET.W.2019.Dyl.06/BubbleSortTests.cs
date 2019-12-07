using System;
using NUnit.Framework;
using static BubbleSort.BubbleSort;

namespace BubbleSortTests
{
    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        [Category("BubbleSort")]
        public void SortBySum_UnsortedArray_ReturnsSortedArray()
        {
            int[][] testArr = new int[5][] {
            new int[3] { 10, 4, 8 },        // 22
            new int[5] { 7, 3, 8, 1, 2 },   // 21
            new int[2] { -10, 25 },         // 15
            new int[4] { -2, 0, 27, -5 },   // 20
            new int[1] { 25 }               // 25
            };

            int[][] sortedExpectedArr = new int[5][]
            {
                    new int[] { -10, 25 },
                    new int[] { -2, 0, 27, -5 },
                    new int[] { 7, 3, 8, 1, 2 },
                    new int[] { 10, 4, 8 },
                    new int[] { 25 }
            };

            int[][] reversedExpectedArr = new int[][]
            {
                new int[] { 25 },
                new int[] { 10, 4, 8 },
                new int[] { 7, 3, 8, 1, 2 },
                new int[] { -2, 0, 27, -5 },
                new int[] { -10, 25}
            };

            int[][] resSortedArray = SortBySum(testArr, true);
            int[][] resReversedArray = SortBySum(testArr, false);

            Assert.AreEqual(resSortedArray, sortedExpectedArr);
            Assert.AreEqual(resReversedArray, reversedExpectedArr);
        }

        [Test]
        [Category("BubbleSort")]
        public void SortByMax_UnsortedArray_ReturnsSortedArray()
        {
            int[][] testArr = new int[5][] {
            new int[3] { 10, 4, 8 },        // 10
            new int[5] { 7, 3, 8, 1, 2 },   // 8
            new int[2] { -10, 25 },         // 25
            new int[4] { -2, 0, 27, -5 },   // 27
            new int[1] { 25 }               // 25
            };

            int[][] sortedExpectedArr = new int[5][]
            {
                    new int[] { 7, 3, 8, 1, 2 },
                    new int[] { 10, 4, 8 },
                    new int[] { -10, 25 },
                    new int[] { 25 },
                    new int[] { -2, 0, 27, -5 }
            };

            int[][] reversedExpectedArr = new int[][]
            {
                new int[] { -2, 0, 27, -5 },
                new int[] { 25 },
                new int[] { -10, 25},
                new int[] { 10, 4, 8 },
                new int[] { 7, 3, 8, 1, 2 }
            };


            int[][] resSortedArray = SortBySum(testArr, true);
            int[][] resReversedArray = SortBySum(testArr, false);

            Assert.AreEqual(resSortedArray, sortedExpectedArr);
            Assert.AreEqual(resReversedArray, reversedExpectedArr);
        }

        [Test]
        [Category("BubbleSort")]
        public void SortByMin_UnsortedArray_ReturnsSortedArray()
        {
            int[][] testArr = new int[5][] {
            new int[3] { 10, 4, 8 },        // 4
            new int[5] { 7, 3, 8, 1, 2 },   // 1
            new int[2] { -10, 25 },         // -10
            new int[4] { -2, 0, 27, -5 },   // -5
            new int[1] { 25 }               // 25)
            };

            int[][] sortedExpectedArr = new int[5][]
            {
                new int[] { -10, 25 },
                new int[] { -2, 0, 27, -5 },
                new int[] { 7, 3, 8, 1, 2},
                new int[] { 10, 4, 8 },
                new int[] { 25}
            };

            int[][] reversedExpectedArr = new int[5][]
            {
                new int[] { 25 },
                new int[] { 10, 4, 8 },
                new int[] { 7, 3, 8, 1, 2 },
                new int[] { -2, 0, 27, -5 },
                new int[] { -10, 25 }
            };

            int[][] resSortedArray = SortByMin(testArr, true);
            int[][] resReversedArray = SortByMin(testArr, false);

            Assert.AreEqual(resSortedArray, sortedExpectedArr);
            Assert.AreEqual(resReversedArray, reversedExpectedArr);
        }
        public void SortBySum_NullArray_ThrowsArgumentNullExceptions()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => SortBySum(null, true));
            StringAssert.Contains("Value cannot be null.", ex.Message);
        }
    }
}