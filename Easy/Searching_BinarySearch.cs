using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    [TestFixture]
    public class Searching_BinarySearch
    {
        [Test]
        public void DoTest()
        {
            var arr = new int[] { 0, 1, 21, 33, 44, 45, 61, 71, 72, 73 };
            Assert.That(BinarySearch(arr, 0), Is.EqualTo(0));
            Assert.That(BinarySearch(arr, 33), Is.EqualTo(3));
            Assert.That(BinarySearch(arr, 71), Is.EqualTo(7));
            Assert.That(BinarySearch(arr, 73), Is.EqualTo(9));
            Assert.That(BinarySearch(arr, 44), Is.EqualTo(4));
        }
        [Test]
        public void DoTest2()
        {
            var arr = new int[] { 0, 1, 21, 33, 44, 45, 61, 71, 72, 73 };
            Assert.That(BinarySearchV2(arr, 0), Is.EqualTo(0));
            Assert.That(BinarySearchV2(arr, 33), Is.EqualTo(3));
            Assert.That(BinarySearchV2(arr, 71), Is.EqualTo(7));
            Assert.That(BinarySearchV2(arr, 73), Is.EqualTo(9));
            Assert.That(BinarySearchV2(arr, 44), Is.EqualTo(4));
        }
        [Test]
        public void DoTest3()
        {
            var arr = new int[] { 0, 1, 21, 33, 44, 45, 61, 71, 72, 73 };
            Assert.That(BinarySearchV3(arr, 0), Is.EqualTo(0));
            Assert.That(BinarySearchV3(arr, 33), Is.EqualTo(33));
            Assert.That(BinarySearchV3(arr, 71), Is.EqualTo(71));            
            Assert.That(BinarySearchV3(arr, 73), Is.EqualTo(73));
            Assert.That(BinarySearchV3(arr, 44), Is.EqualTo(44));
        }

        // Return index or -1
        public static int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int pivot = (left + right) / 2;
                int maybeMatch = array[pivot];

                if (target > maybeMatch)
                    left = pivot + 1;
                else if (target < maybeMatch)
                    right = pivot - 1;                
                else if (target == maybeMatch)
                    return pivot;
            }

            return -1;
        }

        // Return index or -1
        public static int BinarySearchV2(int[] array, int target)
        {
            return InnerSearchV2(array, target, 0, array.Length - 1);
        }

        static int InnerSearchV2(int[] array, int target, int left, int right)
        {
            if (right < left)
                return -1;

            int pivot = (left + right) / 2;
            int maybeMatch = array[pivot];

            if (maybeMatch == target)
                return pivot;
            else if (target > maybeMatch)
                return InnerSearchV2(array, target, pivot + 1, right);
            else
                return InnerSearchV2(array, target, left, pivot - 1);
        }

        // Return target or -1
        public static int BinarySearchV3(int[] array, int target)
        {
            if (array.Length == 0)
                return -1;

            int pivot = array.Length / 2;

            if (array[pivot] == target)
                return target;
            else
                if (target > array[pivot]) // array.Length - 
                    return BinarySearchV3(new ArraySegment<int>(array, pivot+1, array.Length - pivot - 1).ToArray(), target);
                else
                    return BinarySearchV3(new ArraySegment<int>(array, 0, pivot).ToArray(), target);
        }
    }
}
