//-----------------------------------------------------------------------
// <copyright file="Queue.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace QueueTests
{
    using NUnit.Framework;
    using System;
    using Queue;

    [TestFixture]
    public class QueueTests
    {
        #region Constructors tests

        [Test]
        public void CtorWithIEnumerable_NullRef_ThrowsArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                Queue<int> queue = new Queue<int>(null);
            }
            );
        }

        [Test]
        public void CtorWithCapacity_NegativeNumber_ThrowsArgumentException()
        {
            Assert.Catch<ArgumentException>(() =>
            {
                Queue<int> queue = new Queue<int>(-5);
            }
            );
        }

        #endregion

        #region Methods tests

        [Test]
        public void Enqueue_NullRef_ThrowsArgumentNullException()
        {
            Queue<string> queue = new Queue<string>();
            Assert.Catch<ArgumentNullException>(() => queue.Enqueue(null));
        }

        [Test]
        public void Dequeue_EmptyEqueue_ThrowsNullReferenceException()
        {
            Queue<int> queue = new Queue<int>();
            Assert.Catch<NullReferenceException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_EmptyEqueue_ThrowsNullReferenceException()
        {
            Queue<int> queue = new Queue<int>();
            Assert.Catch<NullReferenceException>(() => queue.Peek());
        }

        #endregion
    }
}