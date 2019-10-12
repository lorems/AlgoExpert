using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class BST_Validate
    {
        [Test]
        public void DoTest()
        {
            var bst = new BST(10);
            bst.left = new BST(15);

            Assert.That(ValidateBst(bst), Is.False);
        }
        [Test]
        public void DoTest2()
        {
            var bst = new BST(10);
            bst.left = new BST(5);
            bst.left.right = new BST(15);

            Assert.That(ValidateBst(bst), Is.False);
        }

        [Test]
        public void DoTest3()
        {
            var bst = new BST(10);
            bst.left = new BST(5);
            bst.left.right = new BST(10);

            Assert.That(ValidateBst(bst), Is.False);
        }
        // T: O(n)
        // S: O(d)
        public static bool ValidateBst(BST tree)
        {
            return RecValidateV2(tree, int.MinValue, int.MaxValue); 
        }

        public static bool RecValidate(BST node, int min, int max)
        {
            if (node.value >= min && node.value < max)
            {
                if (node.left != null)
                {
                    bool isValid = RecValidate(node.left, min, node.value);
                    if (!isValid)
                        return false;
                }

                if (node.right != null)
                {
                    bool isValid = RecValidate(node.right, node.value, max);
                    if (!isValid)
                        return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RecValidateV2(BST node, int min, int max)
        {
            if (node.value < min || node.value >= max)
                return false;

            if (node.left != null && !RecValidateV2(node.left, min, node.value)) 
                return false;

            if (node.right != null && !RecValidateV2(node.right, node.value, max))
                return false;

            return true;
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
