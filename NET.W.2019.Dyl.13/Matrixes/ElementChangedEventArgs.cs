//-----------------------------------------------------------------------
// <copyright file="ElementChangedEventArgs.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Matrixes
{
    using System;

    /// <summary>
    /// Event arguments for ElementChanged event of
    /// </summary>
    /// <typeparam name="T"> Type of elements in matrix. </typeparam>
    public class ElementChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Row of changed element.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Column of changed element.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Old value of element.
        /// </summary>
        public T OldValue { get; }

        /// <summary>
        /// New value of element.
        /// </summary>
        public T NewValue { get; }

        /// <summary>
        /// Initializes a new instance of the ElementChangedEventArgs class.
        /// </summary>
        /// <param name="i"> Row of changed element. </param>
        /// <param name="j"> Column of changed element. </param>
        /// <param name="oldValue"> Old value of changed element. </param>
        /// <param name="value"> New value of element. </param>
        public ElementChangedEventArgs(int i, int j, T oldValue, T value)
        {
            Row = i;
            Column = j;
            OldValue = oldValue;
            NewValue = value;
        }
    }
}
