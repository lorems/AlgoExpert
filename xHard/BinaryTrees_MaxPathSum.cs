using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// Write a function that takes in a Binary Tree and returns its max path sum.A
// path is a collection of connected nodes where no node is connected to more
// than two other nodes; a path sum is the sum of the values of the nodes in a
// particular path.Each Binary Tree node has a value stored in a property
// called "value" and two children nodes stored in properties called "left" and
// "right," respectively.Children nodes can either be Binary Tree nodes
// themselves or the None(null) value.

//      1
//    /  \
//   2    3
//  / \  / \
// 4   5 6  7

//        1
//     //   \\
//    //     \\
//    2       3
//   / \\    / \\
//  /   \\  /   \\
// 4     5  6    7

// 18 -> 5 + 2 + 1 + 3 + 7

namespace Questions.xHard
{
    [TestFixture]
    class BinaryTrees_MaxPathSum
    {
        [Test]
        public void DoTest()
        {
            var bTree = new BinaryTree(1);

            bTree.left = new BinaryTree(2);
            bTree.left.left = new BinaryTree(4);
            bTree.left.right = new BinaryTree(5);

            bTree.right = new BinaryTree(3);
            bTree.right.left = new BinaryTree(6);
            bTree.right.right = new BinaryTree(7);

            var actual = MaxPathSum(bTree);

            Assert.That(actual, Is.EqualTo(18));
        }

        // T: O(n) S: average O(log(n))
        public static int MaxPathSum(BinaryTree tree)
        {
            var max = MPS(tree);
            return max.Item2;
        }

        public static Tuple<int, int> MPS(BinaryTree tree)
        {
            var leftMax = (tree.left != null) ? MPS(tree.left) : new Tuple<int, int>(0, 0);
            var rightMax = (tree.right != null) ? MPS(tree.right) : new Tuple<int, int>(0, 0);

            int maxChildBranch = Math.Max(leftMax.Item1, rightMax.Item1);
            int maxBranch = Math.Max(tree.value, tree.value + maxChildBranch);

            int triangleValue = Math.Max(maxBranch, tree.value + leftMax.Item1 + rightMax.Item1);

            int maxTriangleValue = Math.Max(triangleValue,
                Math.Max(leftMax.Item2, rightMax.Item2));

            return new Tuple<int, int>(maxBranch, maxTriangleValue);
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
