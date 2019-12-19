//-----------------------------------------------------------------------
// <copyright file="DiagonalMatrix.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Matrixes
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the matrix.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the DiagonalMatrix class.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            Size = matrix.GetLength(0);

            bool diag1, diag2;
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    diag1 = EqualityComparer<T>.Default.Equals(matrix[i,j], default(T));
                    diag2 = EqualityComparer<T>.Default.Equals(matrix[j,i], default(T));

                    if (diag1 && diag2 == false)
                        throw new ArgumentException("Input matrix must be diagonal.");
                }
            }
        }
    }
}
