using NUnit.Framework;
using System.Collections.Generic;
using BinarySearchTree;
using Books;
using System;

namespace BinarySearchTreeTests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Int

        [Test]
        public void Int32_DefaultCompare()
        {
            BinarySearchTree<int> intTree = new BinarySearchTree<int>();
            intTree.Insert(5);
            intTree.Insert(7);
            intTree.Insert(3);
            intTree.Insert(8);
            intTree.Insert(2);
            intTree.Insert(4);
            intTree.Insert(1);
            intTree.Insert(7);

            List<int> numbers = new List<int>();
            foreach (var n in intTree.PreorderTraversal())
            {
                numbers.Add(n);
            }

            List<int> preorderExpectedNumbers = new List<int> { 5, 3, 2, 1, 4, 7, 7, 8 };
            Assert.AreEqual(preorderExpectedNumbers, numbers.ToArray());

            numbers.Clear();
            foreach (var n in intTree.InorderTraversal())
            {
                numbers.Add(n);
            }

            List<int> inorderExpectedNumbers = new List<int> { 1, 2, 3, 4, 5, 7, 7, 8 };
            Assert.AreEqual(inorderExpectedNumbers, numbers);

            numbers.Clear();
            foreach (var n in intTree.PostorderTraversal())
            {
                numbers.Add(n);
            }
            List<int> postorderExpectedNumbers = new List<int> { 1, 2, 4, 3, 7, 8, 7, 5 };
            Assert.AreEqual(postorderExpectedNumbers, numbers);
        }

        #endregion

        #region String
        [Test]
        public void String_DefaultCompare()
        {
            BinarySearchTree<string> stringTree = new BinarySearchTree<string>();
            stringTree.Insert("qwerty");
            stringTree.Insert("ewq");
            stringTree.Insert("weq");
            stringTree.Insert("ytr");
            stringTree.Insert("rew");
            stringTree.Insert("ewq");
            stringTree.Insert("werty");
            stringTree.Insert("ert");

            List<string> strings = new List<string>();
            foreach (var n in stringTree.PreorderTraversal())
            {
                strings.Add(n);
            }

            List<string> preorderExpectedStrings = new List<string>
            {
                "qwerty", "ewq", "ewq", "ert", "weq", "rew", "ytr", "werty"
            };
            Assert.AreEqual(preorderExpectedStrings, strings.ToArray());

            strings.Clear();
            foreach (var n in stringTree.InorderTraversal())
            {
                strings.Add(n);
            }

            List<string> inorderExpectedStrings = new List<string> { "ert", "ewq", "ewq", "qwerty", "rew", "weq", "werty", "ytr" };
            Assert.AreEqual(inorderExpectedStrings, strings);

            strings.Clear();
            foreach (var n in stringTree.PostorderTraversal())
            {
                strings.Add(n);
            }
            List<string> postorderExpectedStrings = new List<string> { "ert", "ewq", "ewq", "rew", "werty", "ytr", "weq", "qwerty" };
            Assert.AreEqual(postorderExpectedStrings, strings);
        }

        [Test]
        public void String_SpecialCompare()
        {
            Comparison<string> comparer = (string x, string y) =>
            {
                if (x.Length > y.Length)
                    return 1;
                else if (x.Length == y.Length)
                    return 0;
                else
                    return -1;
            };

            BinarySearchTree<string> stringTree = new BinarySearchTree<string>(comparer);
            stringTree.Insert("qwerty");
            stringTree.Insert("ewq");
            stringTree.Insert("eq");
            stringTree.Insert("r");
            stringTree.Insert("rew");
            stringTree.Insert("eqwerty");
            stringTree.Insert("wty");
            stringTree.Insert("t");

            List<string> strings = new List<string>();
            foreach (var n in stringTree.PreorderTraversal())
            {
                strings.Add(n);
            }

            List<string> preorderExpectedStrings = new List<string>
            {
                "qwerty", "ewq", "eq", "r", "t", "rew", "wty", "eqwerty"
            };
            Assert.AreEqual(preorderExpectedStrings, strings.ToArray());

            strings.Clear();
            foreach (var n in stringTree.InorderTraversal())
            {
                strings.Add(n);
            }

            List<string> inorderExpectedStrings = new List<string> { "t", "r", "eq", "wty", "rew", "ewq", "qwerty", "eqwerty" };
            Assert.AreEqual(inorderExpectedStrings, strings);

            strings.Clear();
            foreach (var n in stringTree.PostorderTraversal())
            {
                strings.Add(n);
            }
            List<string> postorderExpectedStrings = new List<string> { "t", "r", "wty", "rew", "eq", "ewq", "eqwerty", "qwerty" };
            Assert.AreEqual(postorderExpectedStrings, strings);
        }

        #endregion

        #region Book

        [Test]
        public void Book_DefaultCompare()
        {
            BinarySearchTree<Book> bookTree = new BinarySearchTree<Book>();
            Book b1 = new Book("123-4-56-78910-1", "John", "Thoughts", "Unfamous publisher", 2019, 404, 20);
            Book b2 = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 29.99m);
            Book b3 = new Book("978-5-699-96201-3", "Markus Zusak", "The Book Thief", "EKSMO", 2018, 512, 6m);
            bookTree.Insert(b1);
            bookTree.Insert(b2);
            bookTree.Insert(b3);

            List<Book> books = new List<Book>();
            foreach (var n in bookTree.PreorderTraversal())
            {
                books.Add(n);
            }

            List<Book> preorderExpectedBooks = new List<Book>()
            {
                b1, b2, b3
            };
            Assert.AreEqual(preorderExpectedBooks, books.ToArray());

            books.Clear();

            List<Book> inorderExpectedBooks = new List<Book>();
            inorderExpectedBooks.Add(b2);
            inorderExpectedBooks.Add(b1);
            inorderExpectedBooks.Add(b3);
            Assert.AreEqual(inorderExpectedBooks, books.ToArray());

            books.Clear();

            List<Book> postorderExpectedBooks = new List<Book>();
            postorderExpectedBooks.Add(b2);
            postorderExpectedBooks.Add(b3);
            postorderExpectedBooks.Add(b1);
            Assert.AreEqual(postorderExpectedBooks, books.ToArray());
        }

        [Test]
        public void Book_SpecialCompare()
        {
            Comparison<Book> comparer = (Book x, Book y) =>
            {
                if (x.NumOfPages > y.NumOfPages)
                    return 1;
                else if (x.NumOfPages == y.NumOfPages)
                    return 0;
                else
                    return -1;
            };

            BinarySearchTree<Book> bookTree = new BinarySearchTree<Book>(comparer);
            Book b1 = new Book("123-4-56-78910-1", "John", "Thoughts", "Unfamous publisher", 2019, 404, 20);
            Book b2 = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 29.99m);
            Book b3 = new Book("978-5-699-96201-3", "Markus Zusak", "The Book Thief", "EKSMO", 2018, 512, 6m);
            bookTree.Insert(b1);
            bookTree.Insert(b2);
            bookTree.Insert(b3);

            List<Book> books = new List<Book>();
            foreach (var n in bookTree.PreorderTraversal())
            {
                books.Add(n);
            }

            List<Book> preorderExpectedBooks = new List<Book>();
            preorderExpectedBooks.Add(b1);
            preorderExpectedBooks.Add(b3);
            preorderExpectedBooks.Add(b2);
            Assert.AreEqual(preorderExpectedBooks, books.ToArray());
        }

        #endregion

        #region Point

        [Test]
        public void PointTests()
        {
            Comparison<Point> comparer = (Point x, Point y) =>
            {
                if ((x.x + x.y) > (y.x + y.y))
                    return 1;
                else if ((x.x + x.y) == (y.x + y.y))
                    return 0;
                else
                    return -1;
            };

            BinarySearchTree<Point> pointTree = new BinarySearchTree<Point>(comparer);
            pointTree.Insert(new Point(0, 1));
            pointTree.Insert(new Point(2, 1));
            pointTree.Insert(new Point(0, 0));
            pointTree.Insert(new Point(1, 1));

            List<Point> points = new List<Point>();
            foreach (var n in pointTree.PreorderTraversal())
            {
                points.Add(n);
            }

            List<Point> preorderExpectedPoints = new List<Point>
            {
                new Point(0, 1),
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 1),
            };
            Assert.AreEqual(preorderExpectedPoints, points.ToArray());

            points.Clear();

            List<Point> inorderExpectedPoints = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(1, 1),
                new Point(2, 1),
            };
            Assert.AreEqual(inorderExpectedPoints, points.ToArray());

            points.Clear();

            List<Point> postorderExpectedPoints = new List<Point>
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 1),
                new Point(0, 1),
            };
            Assert.AreEqual(postorderExpectedPoints, points.ToArray());


        }

        internal struct Point
        {
            internal readonly int x;
            internal readonly int y;

            internal Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        #endregion
    }
}