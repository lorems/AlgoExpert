using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    class DynamicProg_MaxSubsetSumNoAdjacent
    {
        // 330 = (75 + 120 + 135)
        [TestCase(new int[] { 75, 105, 120, 75, 90, 135 }, ExpectedResult = 330)]
        [TestCase(new int[] { 1, 100, 5, 200 }, ExpectedResult = 300)]
        [TestCase(new int[] { 1,  }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 100 }, ExpectedResult = 100)]
        [TestCase(new int[] {  }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 9)]
        [TestCase(new int[] { 4, 3, 5, 200, 5, 3 }, ExpectedResult = 207)]
        public static int MaxSubsetSumNoAdjacent(int[] array)
        {
            if (array.Length == 0)
                return 0;
            else if (array.Length == 1)
                return array[0];

            var maxSums = new int[array.Length];
            maxSums[0] = array[0];
            maxSums[1] = Math.Max(array[0],array[1]);

            var max = Math.Max(maxSums[0], maxSums[1]);

            for (int i = 2; i < array.Length; i++)
            {
                maxSums[i] = 
                    (maxSums[i - 1] > maxSums[i - 2] + array[i]) 
                    ? maxSums[i - 1] 
                    : maxSums[i - 2] + array[i];

                max = Math.Max(max, maxSums[i]);
            }

            return max;
        }
        [TestCase(new int[] { 75, 105, 120, 75, 90, 135 }, ExpectedResult = 330)]
        [TestCase(new int[] { 1, 100, 5, 200 }, ExpectedResult = 300)]
        [TestCase(new int[] { 1, }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 9)]
        [TestCase(new int[] { 4, 3, 5, 200, 5, 3 }, ExpectedResult = 207)]
        public static int MaxSubsetSumNoAdjacentV2(int[] array)
        {
            if (array.Length == 0)
                return 0;
            else if (array.Length == 1)
                return array[0];

            var maxSums = new int[array.Length];
            maxSums[0] = array[0];
            maxSums[1] = Math.Max(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                maxSums[i] = Math.Max(maxSums[i - 1], maxSums[i - 2] + array[i]);
            }

            return Math.Max(maxSums[array.Length-1], maxSums[array.Length-2]);
        }

        [TestCase(new int[] { 75, 105, 120, 75, 90, 135 }, ExpectedResult = 330)]
        [TestCase(new int[] { 1, 100, 5, 200 }, ExpectedResult = 300)]
        [TestCase(new int[] { 1, }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 9)]
        [TestCase(new int[] { 4, 3, 5, 200, 5, 3 }, ExpectedResult = 207)]
        // S: O(1)
        public static int MaxSubsetSumNoAdjacentV3(int[] array)
        {
            if (array.Length == 0)
                return 0;
            else if (array.Length == 1)
                return array[0];

            int left = array[0];
            int right = Math.Max(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                int temp = right;
                right = Math.Max(right, left + array[i]);
                left = temp;
            }

            return Math.Max(left, right);
        }
    }
}
