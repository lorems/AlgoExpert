using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Easy
{
    [TestFixture]
    class Searching_FindThreeLargestNumbers
    {
        [Test]
        public void DoTest()
        {
            var arr = new int[] { 141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7 };
            var expected = new int[] { 18, 141, 541 };
            CollectionAssert.AreEqual(expected, FindThreeLargestNumbers(arr));

            arr = new int[] { 2,2,2,2,2 };
            expected = new int[] { 2,2,2 };
            CollectionAssert.AreEqual(expected, FindThreeLargestNumbers(arr));
        }

        public static int[] FindThreeLargestNumbers(int[] array)
        {
            var sortedMaxArray = new int[] { Int32.MinValue, Int32.MinValue, Int32.MinValue };

            foreach (var val in array)
                UpdateArray(sortedMaxArray, val);

            return sortedMaxArray;
        }

        public static void UpdateArray(int[] maxArray, int n)
        {
            for (int i = maxArray.Length-1; i >= 0; i--)
            {
                if (n > maxArray[i])
                {
                    InsertShift(maxArray, n, i);
                    break;
                }
            }
        }

        static int[] InsertShift(int[] maxArray, int n, int pos)
        {
            for (int i = 0; i <= pos; i++)
            {
                if (i == pos)
                    maxArray[i] = n;
                else
                    maxArray[i] = maxArray[i+1];
            }
            return maxArray;
        }
    }
}
