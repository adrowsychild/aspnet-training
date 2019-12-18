//-----------------------------------------------------------------------
// <copyright file="Node.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace BinarySearchTree
{
    using System;

    /// <summary>
    /// Node.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the node.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        internal Node()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        /// <param name="data">Data to put in the node.</param>
        internal Node(T data)
        {
            //Node<T> node = new Node<T>();
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// Gets or sets data in the node.
        /// </summary>
        internal T Data { get; set; }

        /// <summary>
        /// Gets or sets reference to the left node of the root.
        /// </summary>
        internal Node<T> Left { get; set; }

        /// <summary>
        /// Gets or sets reference to the right node of the root.
        /// </summary>
        internal Node<T> Right { get; set; }
    }
}