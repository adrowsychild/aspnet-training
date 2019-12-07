using System;
using NUnit.Framework;
using MatrixSort;
using System.Collections.Generic;

namespace MatrixSortTests
{
    [TestFixture]
    public class BubbleSortTests
    {
        #region using Interface

        [Test]
        [Category("MatrixSort")]
        public void SortBySumUsingInterface_UnsortedArray_ReturnsSortedArray()
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

            var comparer = new CompairSums();

            Array.Sort(testArr, comparer.Compare);

            Assert.AreEqual(testArr, sortedExpectedArr);
        }

        [Test]
        [Category("MatrixSort")]
        public void SortByMaxUsingInterface_UnsortedArray_ReturnsSortedArray()
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

            var comparer = new CompairMaxs();

            Array.Sort(testArr, comparer.Compare);

            Assert.AreEqual(testArr, sortedExpectedArr);
        }

        [Test]
        [Category("MatrixSort")]
        public void SortByMinUsingInterface_UnsortedArray_ReturnsSortedArray()
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

            var comparer = new CompairMins();

            Array.Sort(testArr, comparer.Compare);

            Assert.AreEqual(testArr, sortedExpectedArr);
        }

        #endregion

        #region using Delegate

        [Test]
        [Category("MatrixSort")]
        public void SortBySumUsingDelegate_UnsortedArray_ReturnsSortedArray()
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

            var comparer = new CompairSums();

            Array.Sort(testArr, comparer);

            Assert.AreEqual(testArr, sortedExpectedArr);
        }

        [Test]
        [Category("MatrixSort")]
        public void SortByMaxUsingDelegate_UnsortedArray_ReturnsSortedArray()
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

            var comparer = new CompairMaxs();

            Array.Sort(testArr, comparer);

            Assert.AreEqual(testArr, sortedExpectedArr);
        }

        [Test]
        [Category("MatrixSort")]
        public void SortByMinUsingDelegate_UnsortedArray_ReturnsSortedArray()
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

            var comparer = new CompairMins();

            Array.Sort(testArr, comparer);

            Assert.AreEqual(testArr, sortedExpectedArr);
        }

        #endregion

        #region NullException

        [Test]
        [Category("MatrixSort")]
        public void SortBySum_NullArray_ThrowsArgumentNullExceptions()
        {
            var comparer = new CompairSums();

            var ex = Assert.Catch<ArgumentNullException>(() => Array.Sort(null, comparer));
            StringAssert.Contains("Value cannot be null.", ex.Message);
        }

        [Test]
        [Category("MatrixSort")]
        public void SortBySum_NullComparer_ThrowsArgumentNullExceptions()
        {
            IComparer<int[]> comparer = null;

            var ex = Assert.Catch<ArgumentNullException>(() => Array.Sort(null, comparer));
            StringAssert.Contains("Value cannot be null.", ex.Message);
        }

        #endregion
    }
}