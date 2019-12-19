//-----------------------------------------------------------------------
// <copyright file="SquareMatrix.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Matrixes
{
    using System;

    /// <summary>
    /// Square matrix.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the matrix.</typeparam>
    public class SquareMatrix<T>
    {
        /// <summary>
        /// Matrix itself.
        /// </summary>
        protected T[,] matrix;

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i">Index of row. </param>
        /// <param name="j">Index of column. </param>
        public T this[int i, int j]
        {
            get
            {
                if (i >= Size || j >= Size)
                {
                    throw new ArgumentException("Incorrect indexes.");
                }

                if (i != j)
                    return default(T);

                return matrix[i, j];
            }
            set
            {
                if (i < Size || j < Size)
                {
                    throw new ArgumentException("Incorrect indexes.");
                }

                var oldElement = matrix[i, j];
                matrix[i, j] = value;

                OnElementChanged(new ElementChangedEventArgs<T>(i, j, oldElement, value));
            }
        }

        /// <summary>
        /// Length of the one side.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The event that is called when matrix has changed.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        /// <summary>
        /// Initializes a new instance of the SquareMatrix class.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        public SquareMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix) + "mustn't be null.");
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("Matrix should have the same number of rows and colums.");
            }

            this.matrix = matrix;
        }

        public override string ToString()
        {
            string str = "";
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    str += matrix[i, j];
                    str += "\t";
                }

                str += "\n";
            }

            return str;
        }

        /// <summary>
        /// Event handler when element of the matrix has changed.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected void OnElementChanged(ElementChangedEventArgs<T> eventArgs)
        {
            if (eventArgs == null)
                throw new ArgumentNullException(nameof(eventArgs));

            ElementChanged?.Invoke(this, eventArgs);
        }

    }
}
