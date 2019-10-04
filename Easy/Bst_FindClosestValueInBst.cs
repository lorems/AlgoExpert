using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Easy
{
//        10
//      /   \
//     5    15
//    /\    /\
//   2  5  13 22
//  /       \
// 1        14
    
    [TestFixture]
    public class Bst_FindClosestValueInBst
    {
        public BST Tree { get; set; }

        [OneTimeSetUp]
        public void Init()
        {
            // root
            Tree = new BST(10);
            // lv 1
            Tree.left = new BST(5);
            Tree.right = new BST(15);
            // lv 2            
            Tree.left.left = new BST(2);
            Tree.left.right = new BST(5);
            Tree.right.left = new BST(13);
            Tree.right.right = new BST(22);
            //lv 3            
            Tree.left.left.left = new BST(1);
            //Tree.left.left.left = Tree; // uncomment to create loop
            Tree.right.left.right = new BST(14);
        }

        [TestCase(12, ExpectedResult = 13)]
        [TestCase(6, ExpectedResult = 5)]
        public int DoTest(int target)
        {
            return FindClosestValueInBstV5(Tree, target);
        }

        static public int FindClosestValueInBstV2(BST tree, int target)
        {
            var visited = new HashSet<BST>();

            var nextToVisit = new Queue<BST>();
            nextToVisit.Enqueue(tree);

            while (nextToVisit.Any())
            {
                var node = nextToVisit.Dequeue();

                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    if (node.left != null) nextToVisit.Enqueue(node.left);
                    if (node.right != null) nextToVisit.Enqueue(node.right);
                }
            }
            int closest = tree.value;

            visited.ToList().ForEach(x => closest =
                                            Math.Abs(target - x.value) < Math.Abs(target - closest)
                                            ? x.value
                                            : closest);
            return closest;
        }

        static public int FindClosestValueInBstV1(BST _tree, int target)
        {
            var visited = new HashSet<BST>();

            void DfsTraverse(BST tree)
            {
                Console.WriteLine(tree.value);
                if (visited.Contains(tree)) return;
                visited.Add(tree);
                if (tree.left != null) DfsTraverse(tree.left);
                if (tree.right != null) DfsTraverse(tree.right);
            }

            int closest = _tree.value;
            DfsTraverse(_tree);

            visited.ToList().ForEach(x => closest =
                                            Math.Abs(target - x.value) < Math.Abs(target - closest)
                                            ? x.value
                                            : closest);
            return closest;
        }

        static public int FindClosestValueInBstV3(BST tree, int target)
        {
            var nextToVisit = new Queue<BST>();
            int closest = tree.value;
            nextToVisit.Enqueue(tree);

            while (nextToVisit.Any() && nextToVisit.Peek() != null)
            {
                var node = nextToVisit.Dequeue();
                closest = (Math.Abs(target - node.value) > Math.Abs(target - closest)) ? closest : node.value;

                if (target > node.value)
                    nextToVisit.Enqueue(node.right ?? null);
                else
                    nextToVisit.Enqueue(node.left ?? null);
            }
            return closest;
        }

        static public int FindClosestValueInBstV4(BST tree, int target)
        {
            int FindClosest(BST node, int closest)
            {
                if (node is null)
                    return closest;

                closest = Math.Abs(target - node.value) < Math.Abs(target - closest) ? node.value : closest;

                if (target > node.value)
                    return FindClosest(node.right, closest);
                else
                    return FindClosest(node.left, closest);
            }

            return FindClosest(tree, tree.value);
        }

        static public int FindClosestValueInBstV5(BST tree, int target)
        {
            var nextToVisit = tree;
            int closest = tree.value;

            while (nextToVisit != null)
            {
                closest = (Math.Abs(target - nextToVisit.value) > Math.Abs(target - closest)) ? closest : nextToVisit.value;
                nextToVisit = (target > nextToVisit.value) ? nextToVisit.right : nextToVisit.left;
            }

            return closest;
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
