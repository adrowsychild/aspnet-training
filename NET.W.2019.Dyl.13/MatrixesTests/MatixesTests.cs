using NUnit.Framework;
using System;
using System.Collections.Generic;
using Matrixes;

namespace MatrixesTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CtorWithArray_ThrowsArgumentNullException()
        {
            SquareMatrix<int> matr;
            Assert.Catch<ArgumentNullException>(() => matr = new SquareMatrix<int>(null));
        }

        [Test]
        public void CtorWithArray_ThrowsArgumentException()
        {
            SquareMatrix<int> matr;
            Assert.Catch<ArgumentException>(() => matr = new SquareMatrix<int>(new int[,] { { 1, 2, 0 }, { 1, 2, 3 } }));
        }

        [Test]
        public void CtorSymmMatrix_ThowsArgumentException()
        {
            SymmetricalMatrix<int> matr;
            Assert.Catch<ArgumentException>(() => matr = new SymmetricalMatrix<int>(new int[,] { { 1, 4, 0 }, { 3, 2, 6 }, { 0, 6, 5 } }));
        }

        [Test]
        public void CtorSymmMatrix_Successully()
        {
            SymmetricalMatrix<int> matr;
            Assert.DoesNotThrow(() => matr = new SymmetricalMatrix<int>(new int[,] { { 1, 3, 0 }, { 3, 2, 6 }, { 0, 6, 5 } }));
        }

        [Test]
        public void CtorDiagMatrix_ThrowsArgumentException()
        {
            DiagonalMatrix<int> matr;
            Assert.Catch<ArgumentException>(() => matr = new DiagonalMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 1, 1 } }));
        }

        [Test]
        public void CtorDiagMatrix_Successfully()
        {
            DiagonalMatrix<int> matr;
            Assert.DoesNotThrow(() => matr = new DiagonalMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }));
        }

        [Test]
        public void SumsTwoMatrixes_Successfully()
        {
            DiagonalMatrix<int> matr1 = new DiagonalMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            SymmetricalMatrix<int> matr2 = new SymmetricalMatrix<int>(new int[,] { { 1, 3, 0 }, { 3, 2, 6 }, { 0, 6, 5 } });

            SquareMatrix<int> res = matr1.Add(matr2);
            SquareMatrix<int> expectedRes = new SquareMatrix<int>( new int [,] { { 2, 3, 0 }, { 3, 3, 6 }, { 0, 6, 6 } });

            Assert.AreEqual(expectedRes, res);
        }
    }
}