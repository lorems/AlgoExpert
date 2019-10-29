using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// Write a function that takes in an array of integers of length at least 2.
// The function should return an array of the starting and ending indices of 
// the smallest subarray in the input array that needs to be sorted in place 
// in order for the entire input array to be sorted. If the input array is 
// already sorted, the function should return [-1, -1].

namespace Questions.xHard
{
    [TestFixture]
    class Arrays_SubarraySort
    {
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 1, }, ExpectedResult = new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 }, ExpectedResult = new int[] { 3, 9 })]
        public static int[] SubarraySort(int[] array)
        {
            int outOfOrderMin = int.MaxValue;
            int outOfOrderMax = int.MinValue;
            bool isOutOfOrder = false;

            for (int i = 1; i < array.Length; i++)
            {
                isOutOfOrder = isOutOfOrder || array[i - 1] > array[i];
                outOfOrderMin = isOutOfOrder ? Math.Min(outOfOrderMin, array[i]) : outOfOrderMin;
            }

            if (!isOutOfOrder)
                return new int[] { -1, -1 };

            isOutOfOrder = false;

            for (int i = array.Length - 2; i >= 0; i--)
            {
                isOutOfOrder = isOutOfOrder || array[i] > array[i + 1];
                outOfOrderMax = isOutOfOrder ? Math.Max(outOfOrderMax, array[i]) : outOfOrderMax;
            }

            int left = 0;

            while (left < array.Length && array[left] <= outOfOrderMin)
                ++left;

            int right = array.Length - 1;

            while (right >= 0 && array[right] >= outOfOrderMax)
                --right;

            return new int[] { left, right };
        }

        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = new int[] { -1, -1 })]
        [TestCase(new int[] { 2, 1, }, ExpectedResult = new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 }, ExpectedResult = new int[] { 3, 9 })]
        public static int[] SubarraySortV2(int[] array)
        {
            int outOfOrderMin = int.MaxValue;
            int outOfOrderMax = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (IsOutOfOrder(i, array))
                {
                    outOfOrderMin = Math.Min(outOfOrderMin, array[i]);
                    outOfOrderMax = Math.Max(outOfOrderMax, array[i]);
                }
            }

            if (outOfOrderMin == int.MaxValue)
                return new int[] { -1, -1 };

            int left = 0;

            while (left < array.Length && array[left] <= outOfOrderMin)
                ++left;

            int right = array.Length - 1;

            while (right >= 0 && array[right] >= outOfOrderMax)
                --right;

            return new int[] { left, right };
        }

        public static bool IsOutOfOrder(int i, int[] array)
        {
            if (i == 0)
                return array[i] > array[i + 1];

            if (i == array.Length - 1)
                return array[i] < array[i - 1];

            return array[i] > array[i + 1] || array[i] < array[i - 1];
        }
    }
}
