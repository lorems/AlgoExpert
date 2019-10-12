using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class BinaryTrees_Invert
    {
        //   10
        //   /\
        //  5  15
        [Test]
        public void DoTest()
        {
            BinaryTree btree = new BinaryTree(1);
            btree.left = new BinaryTree(2);
            btree.right = new BinaryTree(3);

            //InvertBinaryTree(btree);
            //InvertBinaryTreeIterative(btree);
            InvertBinaryTreeIterativeV2(btree);

            Assert.That(btree.right.value, Is.EqualTo(2));
        }

        // T: O(n)
        // S: O(d)
        public static void InvertBinaryTree(BinaryTree tree)
        {
            if (tree.left != null)
                InvertBinaryTree(tree.left);

            if (tree.right != null)
                InvertBinaryTree(tree.right);

            Swap(tree);
        }
        // T: O(n)
        // S: O(n)
        public static void InvertBinaryTreeIterative(BinaryTree tree)
        {
            var queue = new Queue<BinaryTree>();
            queue.Enqueue(tree);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                Swap(node);

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }

        public static void InvertBinaryTreeIterativeV2(BinaryTree tree)
        {
            var list = new List<BinaryTree>();
            list.Add(tree);
            int i = 0;

            while (i < list.Count)
            {
                var node = list[i];
                ++i;
                Swap(node);

                if (node.left != null)
                    list.Add(node.left);

                if (node.right != null)
                    list.Add(node.right);
            }
        }

        public static void Swap(BinaryTree node)
        {
            BinaryTree temp = node.left;
            node.left = node.right;
            node.right = temp;
        }

        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
            }
        }
    }
}
