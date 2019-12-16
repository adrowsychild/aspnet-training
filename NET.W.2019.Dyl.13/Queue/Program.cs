//-----------------------------------------------------------------------
// <copyright file="Queue.cs" company="EPAM">
//     .NET training
// </copyright>
//-----------------------------------------------------------------------

namespace Queue
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numberQueue = new Queue<int>();
            Console.WriteLine("Creating an empty int queue with default capacity...");
            Console.WriteLine("Enqueuing numbers to the queue...");
            numberQueue.Enqueue(4);
            numberQueue.Enqueue(0);
            numberQueue.Enqueue(4);
            Console.WriteLine("Checking if the queue contains the number...");
            Console.WriteLine("Dequeuing numbers from the queue...");
            int num1 = numberQueue.Dequeue();
            int num2 = numberQueue.Dequeue();
            int num3 = numberQueue.Dequeue();
            Console.WriteLine("Creating an empty char queue with capacity of 2...");
            Queue<char> charQueue = new Queue<char>(2);
            Console.WriteLine("Adding more chars than initial capacity to the queue...");
            charQueue.Enqueue('q');
            charQueue.Enqueue('w');
            charQueue.Enqueue('e');
            charQueue.Enqueue('r');
            Console.WriteLine("Dequeing char from the queue...");
            char ch1 = charQueue.Dequeue();
            char ch2 = charQueue.Dequeue();
            char ch3 = charQueue.Dequeue();
            Console.WriteLine("Getting the char from the beginning of the queue...");
            char ch4 = charQueue.Peek();
            Console.WriteLine("Clearing the queue...");
            charQueue.Clear();
            Console.WriteLine("Checking if the queue is empty...");
            charQueue.IsEmpty();
            Console.ReadKey();
        }
    }
}
