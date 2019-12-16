//-----------------------------------------------------------------------
// <copyright file="Queue.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents 'queue' collection of objects.
    /// </summary>
    /// <typeparam name="T">  Specifies the type of elements in the queue. </typeparam>
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        #region Private fields

        /// <summary>
        /// Array to queue objects into.
        /// </summary>
        private T[] array;

        /// <summary>
        /// The index of first element in the queue.
        /// </summary>
        private int head;

        /// <summary>
        /// The index of last element in the queue.
        /// </summary>
        private int tail;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Queue class
        /// with the default capacity (10).
        /// </summary>
        public Queue() : this(10) 
        {
        }

        /// <summary>   
        /// Initializes a new instance of the Queue class.
        /// with the specified initial capacity.
        /// </summary>
        /// <param name="capacity">
        /// The initial number of elements that the queue can contain.
        /// </param>
        public Queue(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("Capacity can't be less than 1.");
            }

            this.head = 0;
            this.tail = 0;
            this.Count = 0;
            this.array = new T[capacity];
        }

        /// <summary>
        /// Initializes a new instance of the Queue class
        /// by adding the collection of given objects.
        /// </summary>
        /// <param name="array"> 
        /// The collection of given objects.
        /// </param>
        public Queue(IEnumerable<T> array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("The collection of elements can't be null.");
            }

            this.array = new T[array.Count()];

            foreach (var element in array)
            {
                this.Enqueue(element);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of elements contained in the queue.
        /// </summary>
        /// <returns> The number of elements contained in the queue. </returns>
        public int Count { get; private set; }

        #endregion

        #region Queue logic methods

        /// <summary>
        /// Adds an object to the end of the queue
        /// </summary>
        /// <param name="element"> 
        /// The object to add to the queue.
        /// </param>
        public void Enqueue(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("The element to enqueue can't be null.");
            }

            if (this.Count == this.array.Length)
            {
                T[] objArray = new T[this.Count + 8];
                Array.Copy(this.array, objArray, this.Count);

                this.array = objArray;
            }

            this.array[this.Count] = element;
            this.tail++;
            this.Count++;
        }

        /// <summary>
        /// Removes and returns the object from the beginning of the queue.
        /// </summary>
        /// <returns> The object removed. </returns>
        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new NullReferenceException("The queue is empty.");
            }

            T obj = this.array[0];

            this.head++;
            this.Count--;

            return obj;
        }

        /// <summary>
        /// Returns the object from the beginning of the queue without removing it.
        /// </summary>
        /// <returns>
        /// The object to give.
        /// </returns>
        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new NullReferenceException("The queue is empty.");
            }

            return this.array[this.head];
        }

        /// <summary>
        /// Check if the queue contains the element.
        /// </summary>
        /// <param name="element">Element to be checked</param>
        /// <returns>True if the queue contains the element, false otherwise.</returns>
        public bool Contains(T element)
        {
            foreach (T elem in this.array)
            {
                if (elem.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if queue is empty.
        /// </summary>
        /// <returns>Bool saying whether the queue is empty.</returns>
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes all objects from the queue.
        /// </summary>
        public void Clear()
        {
            this.array = new T[this.array.Length];

            this.head = 0;
            this.tail = 0;
            this.Count = 0;
        }

        #endregion

        #region IEnumerable, IEnumerable<T> implementations

        /// <summary>
        /// Generic iterator.
        /// </summary>
        /// <returns>An enumerator that iterates through a collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(this);
        }

        /// <summary>
        /// Non-generic iterator.
        /// </summary>
        /// <returns>An enumerator that iterates through a collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Custom iterator

        /// <summary>
        /// Custom iterator.
        /// </summary>
        private struct CustomIterator : IEnumerator<T>
        {
            /// <summary>
            /// Initializes a new instance of the CustomIterator struct.
            /// </summary>
            /// <param name="container">The queue to iterate over.</param>
            internal CustomIterator(Queue<T> container)
            {
                this.container = container;
                this.currentIndex = container.head - 1;
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// True if the enumerator was successfully advanced to the next element
            /// False if the enumerator has passed the end of the collection.
            /// </returns>
            public bool MoveNext()
            {
                this.currentIndex++;

                return this.currentIndex != this.container.tail;
            }

            /// <summary>
            /// Sets the enumerator to its initial position.
            /// </summary>
            public void Reset()
            {
                this.currentIndex = this.container.head - 1;
            }

            /// <summary>
            /// Returns current element of the collection.
            /// </summary>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Gets the current element of the collection.
            /// </summary>
            public T Current
            {
                get
                {
                    if (this.currentIndex < 0 ||
                        this.currentIndex >= this.container.tail)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.container.array[this.currentIndex];
                }
            }

            /// <summary>
            /// Implementation of Dispose method.
            /// </summary>
            public void Dispose() 
            {
            }

            /// <summary>
            /// Queue to iterate over.
            /// </summary>
            private readonly Queue<T> container;

            /// <summary>
            /// The index of current object.
            /// </summary>
            private int currentIndex;
        }

        #endregion
    }
}