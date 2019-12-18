//-----------------------------------------------------------------------
// <copyright file="BinarySearchTree.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Binary Search Tree.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the tree.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>, IEnumerable
    {
        /// <summary>
        /// Initializes a new instance of the BinarySearchTree class.
        /// </summary>
        /// <param name="comparer">The comparer given in Comparison-form.</param>
        public BinarySearchTree(Comparison<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default.Compare;
            }

            this.Comparer = comparer;

            this.Root = null;
            this.Size = 0;
        }

        /// <summary>
        /// Initializes a new instance of the BinarySearchTree class.
        /// </summary>
        /// <param name="comparer">The comparer given in IComparer-form.</param>
        public BinarySearchTree(IComparer<T> comparer) : this(comparer.Compare)
        {
        }

        /// <summary>
        /// Gets or sets the root of the BinarySearchTree
        /// </summary>
        internal Node<T> Root { get; set; }

        /// <summary>
        /// Gets or sets the number of elements in the tree.
        /// </summary>
        internal int Size { get; set; }

        /// <summary>
        /// Gets or sets the comparer for comparing objects.
        /// </summary>
        private Comparison<T> Comparer { get; set; }

        /// <summary>
        /// Inserts data in the tree.
        /// </summary>
        /// <param name="data">The data to insert.</param>
        /// <returns>The root of the updated tree.</returns>
        public void Insert(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data) + "mustn't be null.");
            }

            if (this.Root == null)
            {
                this.Root = new Node<T>(data);
            }
            else
            {
                Insert(this.Root, data);
            }
        }

        /// <summary>
        /// Inserts data in the tree.
        /// </summary>
        /// <param name="root">The root of the tree to insert to.</param>
        /// <param name="data">The data to insert.</param>
        /// <returns>The root of the updated tree.</returns>
        public void Insert(Node<T> root, T data)
        {
            if (Comparer(root.Data, data) > 0 || (Comparer(root.Data, data) == 0))
            {
                if (root.Left == null)
                {
                    root.Left = new Node<T>(data);
                }

                else
                {
                    Insert(root.Left, data);
                }
            }

            else
            {
                if (root.Right == null)
                {
                    root.Right = new Node<T>(data);
                }

                else
                {
                    Insert(root.Right, data);
                }
            }
        }

        /// <summary>
        /// Provides in-order traversal of the tree.
        /// </summary>
        /// <returns>The collection of elements in the tree.</returns>
        public IEnumerable<T> InorderTraversal() => this.InorderTraversal(this.Root);

        /// <summary>
        /// Provides in-order traversal of the tree.
        /// </summary>
        /// <param name="root">The root of the tree to traverse through.</param>
        /// <returns>The collection of elements in the tree.</returns>
        public IEnumerable<T> InorderTraversal(Node<T> root)
        {
            if (root.Left != null)
            {
                foreach (T element in InorderTraversal(root.Left))
                {
                    yield return element;
                }
            }

            yield return root.Data;

            if (root.Right != null)
            {
                foreach (T element in InorderTraversal(root.Right))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Provides pre-order traversal of the tree.
        /// </summary>
        /// <returns>The collection of elements in the tree.</returns>
        public IEnumerable<T> PreorderTraversal() => this.PreorderTraversal(this.Root);


        /// <summary>
        /// Provides pre-order traversal of the tree.
        /// </summary>
        /// <param name="root">The root of the tree to traverse.</param>
        /// <returns>The collection of elements in the tree.</returns>
        public IEnumerable<T> PreorderTraversal(Node<T> root)
        {
            yield return root.Data;

            if (root.Left != null)
            {
                foreach (T element in PreorderTraversal(root.Left))
                {
                    yield return element;
                }
            }

            if (root.Right != null)
            {
                foreach (T element in PreorderTraversal(root.Right))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Provides post-order traversal of the tree.
        /// </summary>
        /// <returns>The collection of elements in the tree.</returns>
        public IEnumerable<T> PostorderTraversal() => this.PostorderTraversal(this.Root);

        /// <summary>
        /// Provides post-order traversal of the tree.
        /// </summary>
        /// <param name="root">The root of the tree to traverse.</param>
        /// <returns>The collection of elements in the tree.</returns>
        public IEnumerable<T> PostorderTraversal(Node<T> root)
        {
            if (root.Left != null)
            {
                foreach (T element in PostorderTraversal(root.Left))
                {
                    yield return element;
                }
            }

            if (root.Right != null)
            {
                foreach (T element in PostorderTraversal(root.Right))
                {
                    yield return element;
                }
            }

            yield return root.Data;
        }

        /// <summary>
        /// Generic iterator.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return this.InorderTraversal(this.Root).GetEnumerator();
        }

        /// <summary>
        /// Simple iterator.
        /// </summary>
        /// <returns>The enumerator that iterates through a collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
