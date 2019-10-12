using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

//        10
//      /   \
//     5    15
//    /\    /\
//   2  5  13 22
//  /       \
// 1        14

// add 12

//        10
//      /   \
//     5    15
//    /\    /\
//   2  5  13 22
//  /      /\
// 1     12  14

// remove 10

//        12
//      /   \
//     5    15
//    /\    /\
//   2  5  13 22
//  /       \
// 1        14

namespace Questions.Medium
{
    [TestFixture]
    class BST_Construction
    {
        [Test]
        public void DoTest()
        {
            // root
            var bst =new BST(10);
            // lv 1
            bst.Insert(5).Insert(15).Insert(2);

            Assert.That(bst.value, Is.EqualTo(10));
            Assert.That(bst.left.value, Is.EqualTo(5));
            Assert.That(bst.right.value, Is.EqualTo(15));
            Assert.That(bst.left.left.value, Is.EqualTo(2));

            Assert.That(bst.Contains(10), Is.True);
            Assert.That(bst.Contains(5), Is.True);
            Assert.That(bst.Contains(15), Is.True);
            Assert.That(bst.Contains(2), Is.True);
            Assert.That(bst.Contains(99), Is.False);

            bst.Insert(5).Insert(13).Insert(22).Insert(1).Insert(14);

            bst.Insert(12);
            bst.Remove(10);
            Assert.That(bst.Contains(12), Is.True);
            Assert.That(bst.Contains(10), Is.False);

            bst.Remove(2);
            Assert.That(bst.Contains(2), Is.False);

            var test2 = new BST(10);
            test2.Insert(15).Insert(11).Insert(22);
            test2.Remove(10);
            Assert.That(test2.Contains(10), Is.False);

            var test3 = new BST(10);
            test3.Insert(9).Insert(8).Insert(7);
            test3.Remove(10);
            Assert.That(test3.Contains(10), Is.False);

            var test4 = new BST(10);
            test4.Insert(5).Insert(15).Insert(22).Insert(17).Insert(34).Insert(7).Insert(2).
            Insert(5).Insert(1).Insert(35).Insert(27).Insert(16);
            test4.Insert(30);
            
            Assert.That(test4.Contains(30), Is.True);
            test4.Remove(22);
            Assert.That(test4.Contains(30), Is.True);
            //Traverse(test4);
            test4.Remove(17);
            //Traverse(test4);
        }

        static public void Traverse(BST node)
        {
            if (node.left != null)
                Traverse(node.left);

            Console.WriteLine(node.value);

            if (node.right != null)
                Traverse(node.right);
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

            public BST Insert(int value)
            {
                if (value >= this.value)
                {
                    if (right == null)
                        right = new BST(value);
                    else
                        right.Insert(value);
                }
                else
                {
                    if (left == null)
                        left = new BST(value);
                    else
                        left.Insert(value);
                }
                return this;
            }

            public bool Contains(int value)
            {
                if (this.value == value)
                    return true;
                else if (value >= this.value && right != null)
                    return right.Contains(value);
                else if(left != null)
                    return left.Contains(value);
                else
                    return false;
            }

            public BST Remove(int value)
            {
                if (value == this.value)
                {
                    if (left != null && right != null)
                    {
                        var parent = GetMinParent(right);

                        // Alternatif
                        //var temp = parent.left.value;
                        //Remove(parent.left.value);
                        //this.value = temp;

                        this.value = parent.left.value;
                        parent.left = parent.left.right;
                    }
                    else if (left == null && right == null)
                    {
                        return null; // ??? delete root
                    }
                    else if (left == null)
                    {
                        this.value = right.value;
                        left = right.left;
                        right = right.right;
                    }
                    else
                    {
                        this.value = left.value;
                        right = left.right;
                        left = left.left;
                    }
                }
                else
                {
                    if (value >= this.value)
                        right = right.Remove(value);
                    else
                        left = left.Remove(value);
                }
                return this;
            }
            static public BST GetMinParent(BST parent)
            {
                if (parent.left.left == null)
                    return parent;
                else
                    return GetMinParent(parent.left);
            }
        }
    }
}
