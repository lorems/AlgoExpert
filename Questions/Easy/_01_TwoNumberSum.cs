using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AlgoExpert.Easy
{
    [TestFixture]
    class _01_TwoNumberSum
    {
        [TestCase(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10, ExpectedResult = new int[] { -1, 11 })]
        [TestCase(new int[] { 3, 5, -4, 8, 11, 1, 6 }, 10, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 111, 6, 4 }, 10, ExpectedResult = new int[] { 4, 6 })]
        public static int[] TwoNumberSum(int[] array, int targetSum)
        {
            var set = new HashSet<int>(array);

            foreach (var n in array)
            {
                set.Remove(n);
                int match = targetSum - n;
                if (set.Contains(match))
                    return new int[] { Math.Min(match, n), Math.Max(match, n) };
            }
            return Array.Empty<int>();
        }

        [TestCase(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10, ExpectedResult = new int[] { -1, 11 })]
        [TestCase(new int[] { 3, 5, -4, 8, 11, 1, 6 }, 10, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 111, 6, 4 }, 10, ExpectedResult = new int[] { 4, 6 })]
        public static int[] TwoNumberSum2(int[] array, int targetSum)
        {
            int left = 0;
            int right = array.Length - 1;
            Array.Sort(array);

            while (left < right)
            {
                int potentialMatch = array[left] + array[right];
                if (potentialMatch == targetSum)
                    return new int[] { Math.Min(array[left], array[right]), Math.Max(array[left], array[right]) };
                else if (targetSum > potentialMatch)
                    ++left;
                else
                    --right;
            }
            return new int[0];
        }
    }
}
