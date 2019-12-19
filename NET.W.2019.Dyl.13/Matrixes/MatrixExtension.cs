//-----------------------------------------------------------------------
// <copyright file="SquareMatrix.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Matrixes
{
    using System;

    /// <summary>
    /// Extends the SquareMatrix class and its derived ones.
    /// </summary>
    public static class MatrixExtension 
    {
        /// <summary>
        /// Checks input and sums to matrixes.
        /// </summary>
        /// <typeparam name="T">Specifies the type of elements in the matrix.</typeparam>
        /// <param name="source">The first matrix.</param>
        /// <param name="other">The second matrix.</param>
        /// <returns>Result matrix.</returns>
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> source, SquareMatrix<T> other)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (source.Size != other.Size)
            {
                throw new ArgumentException("Matrices must have the same sizes.");
            }

            return DynamicAdd<T>(source, other);
        }

        /// <summary>
        /// Sums two matrixes.
        /// </summary>
        /// <typeparam name="T">Specifies the type of elements in the matrix.</typeparam>
        /// <param name="source">The first matrix.</param>
        /// <param name="other">The second matrix.</param>
        /// <returns>Result matrix.</returns>
        private static dynamic DynamicAdd<T>(dynamic source, dynamic other)
        {
            T[,] res = new T[source.Size, source.Size];

            for (int i = 0; i < source.Size; i++)
            {
                for (int j = 0; j < source.Size; j++)
                {
                    res[i, j] = source[i, j] + other[i, j];
                }
            }

            return new SquareMatrix<T>(res);
        }
    }
}
