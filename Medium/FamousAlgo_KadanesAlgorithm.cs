using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// The maximum subarray problem is the task of finding the largest possible sum of a contiguous subarray, within a given one-dimensional array A[1…n] of numbers.

namespace Questions.Medium
{
    [TestFixture]
    class FamousAlgo_KadanesAlgorithm
    {
        [TestCase(new int[] { -10, -2, -9, -4, -8, -6, -7, -1, -3, -5 }, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 2, 3, -10, 2, 50 }, ExpectedResult = 52)]
        [TestCase(new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 }, ExpectedResult = 19)] // [1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1]
        public static int KadanesAlgorithm(int[] array)
        {
            if (array.Length == 0)
                return 0;

            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                int maybeMax = array[i] + array[i-1];                

                if (maybeMax >= array[i])
                {
                    array[i] = maybeMax;
                    max = Math.Max(max, maybeMax);
                }
                else
                {
                    max = Math.Max(max, array[i]);
                }
            }

            return max;
        }

        [TestCase(new int[] { -10, -2, -9, -4, -8, -6, -7, -1, -3, -5 }, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 2, 3, -10, 2, 50 }, ExpectedResult = 52)]
        [TestCase(new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 }, ExpectedResult = 19)] // [1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1]
        public static int KadanesAlgorithmV2(int[] array)
        {
            int max = array[0];
            int lastMax = max;

            for (int i = 1; i < array.Length; i++)
            {
                int maybeMax = array[i] + lastMax;
                lastMax = Math.Max(array[i], maybeMax);
                max = Math.Max(max, lastMax);
            }

            return max;
        }
    }
}
