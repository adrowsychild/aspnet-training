//-----------------------------------------------------------------------
// <copyright file="SymmetricalMatrix.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Matrixes
{
    using System;

    /// <summary>
    /// Symmetrical matrix.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the matrix.</typeparam>
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the SymmetricalMatrix class.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        public SymmetricalMatrix(T[,] matrix) : base(matrix)
        {
            Size = matrix.GetLength(0);

            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    if (!matrix[i,j].Equals(matrix[j,i]))
                    {
                        throw new ArgumentException("Input matrix must be symmetrical.");
                    }
                }
            }
        }
    }
}
