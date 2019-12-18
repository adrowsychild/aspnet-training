using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
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

            foreach (var s in stringTree)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
