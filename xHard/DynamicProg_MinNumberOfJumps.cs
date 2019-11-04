using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.xHard
{
    [TestFixture]
    class DynamicProg_MinNumberOfJumps
    {
        //                    0, 1,       2,    3,          4
        //                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        [TestCase(new int[] { 3, 4, 2, 1, 2, 3, 7, 1, 1, 1, 3 }, ExpectedResult = 4)] // (3 -> 4 -> 3 -> 7 -> 3)
        // T: O(n^2) S: O(n)
        public static int MinNumberOfJumpsV1(int[] array)
        {
            var jumps = new int[array.Length];
            Array.Fill(jumps, int.MaxValue);
            jumps[0] = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length && j <= i + array[i]; j++)
                {
                    if (jumps[i] + 1 < jumps[j])
                        jumps[j] = jumps[i] + 1;
                }
            }

            return jumps.Last();
        }

        //                    0, 1,       2,    3,          4
        //                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        [TestCase(new int[] { 3, 4, 2, 1, 2, 3, 7, 1, 1, 1, 3 }, ExpectedResult = 4)] // (3 -> 4 -> 3 -> 7 -> 3)
        [TestCase(new int[] { 1, 1 }, ExpectedResult = 1)]
        // T: O(n) S: O(1)
        public static int MinNumberOfJumpsV2(int[] array)
        {
            if (array.Length == 1)
                return 0;

            int maxReach = array[0];
            int steps = array[0];
            int jumps = 0;

            for (int i = 1; i < array.Length - 1; i++)
            {
                maxReach = Math.Max(maxReach, array[i] + i);
                --steps;

                if (steps == 0)
                {
                    ++jumps;
                    steps = maxReach - i;
                }
            }
            return jumps + 1;
        }
    }
}
