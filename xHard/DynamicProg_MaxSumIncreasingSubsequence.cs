using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Given an non-empty array of integers, write a function that returns an array
// of length 2. The first element in the output array should be an integer
// value representing the greatest sum that can be generated from a
// strictly-increasing subsequence in the array.The second element should be
// an array of the numbers in that subsequence. A subsequence is defined as a
// set of numbers that are not necessarily adjacent but that are in the same
// order as they appear in the array. Assume that there will only be one
// increasing subsequence with the greatest sum.

namespace Questions.xHard
{
    [TestFixture]
    class DynamicProg_MaxSumIncreasingSubsequence
    {
        [Test]
        public void DoTest()
        {
            var input = new int[] { 10, 70, 20, 30, 50, 11, 30 };
            var actual = MaxSumIncreasingSubsequence(input);

            var expected = new List<List<int>> { new List<int> { 110 }, new List<int> { 10, 20, 30, 50 } };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DoTest2()
        {
            var input = new int[] { 1 };
            var actual = MaxSumIncreasingSubsequence(input);

            var expected = new List<List<int>> { new List<int> { 1 }, new List<int> { 1 } };

            CollectionAssert.AreEqual(expected, actual);
        }
        // T: O(n^2) S: O(n)
        public static List<List<int>> MaxSumIncreasingSubsequence(int[] array)
        {
            var sums = array.Clone() as int[];
            var indexes = new int[array.Length];
            Array.Fill(indexes, -1);
            int maxSumIndex = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[i] > array[j] // is sequence increasing
                        && sums[i] < array[i] + sums[j]) // is sum the highest so far
                    {
                        indexes[i] = j;
                        sums[i] = array[i] + sums[j];
                    }
                }

                if (sums[i] > sums[maxSumIndex])
                    maxSumIndex = i;
            }

            int maxSums = sums[maxSumIndex];
            var sequence = new LinkedList<int>();

            // if lastIndex is equal to -1, final sequence is of length 1, add first element
            if (maxSumIndex == -1)
                sequence.AddFirst(array[0]);
            
            // Build sequence
            for (/* */; maxSumIndex != -1; maxSumIndex = indexes[maxSumIndex])
                sequence.AddFirst(array[maxSumIndex]);



            var result = new List<List<int>>();
            result.Add(new List<int> { maxSums });
            result.Add(sequence.ToList());

            return result;
        }
    }
}
