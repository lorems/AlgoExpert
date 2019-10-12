using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class BST_Traversal
    {
        //   10
        //   /\
        //  5  15
        [Test]
        public void InOrderTest()
        {
            BST bst = new BST(10);
            bst.left = new BST(5);
            bst.right = new BST(15);

            CollectionAssert.AreEqual(new List<int>() { 5, 10, 15 }, InOrderTraverse(bst, new List<int>()));
        }

        [Test]
        public void PreOrderTest()
        {
            BST bst = new BST(10);
            bst.left = new BST(5);
            bst.right = new BST(15);

            CollectionAssert.AreEqual(new List<int>() { 10, 5, 15 }, PreOrderTraverse(bst, new List<int>()));
        }

        [Test]
        public void PostOrderTest()
        {
            BST bst = new BST(10);
            bst.left = new BST(5);
            bst.right = new BST(15);

            CollectionAssert.AreEqual(new List<int>() { 5, 15, 10 }, PostOrderTraverse(bst, new List<int>()));
        }
        public static List<int> InOrderTraverse(BST tree, List<int> array)
        {
            if (tree.left != null)
                InOrderTraverse(tree.left, array);

            array.Add(tree.value);

            if (tree.right != null)
                InOrderTraverse(tree.right, array);

            return array;
        }

        public static List<int> PreOrderTraverse(BST tree, List<int> array)
        {
            array.Add(tree.value);

            if (tree.left != null)
                PreOrderTraverse(tree.left, array);

            if (tree.right != null)
                PreOrderTraverse(tree.right, array);

            return array;
        }

        public static List<int> PostOrderTraverse(BST tree, List<int> array)
        {
            if (tree.left != null)
                PostOrderTraverse(tree.left, array);
            
            if (tree.right != null)
                PostOrderTraverse(tree.right, array);

            array.Add(tree.value);

            return array;
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }
    }
}
