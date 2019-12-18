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
    }
}