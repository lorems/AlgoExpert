using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// Write a function that takes in an array of integers and returns an array of
// length 2 representing the largest range of numbers contained in that array.
// The first number in the output array should be the first number in the range
// while the second number should be the last number in the range. A range of
// numbers is defined as a set of numbers that come right after each other in
// the set of real integers. For instance, the output array [2, 6] represents
// the range {2, 3, 4, 5, 6}, which is a range of length 5. Note that numbers
// do not need to be ordered or adjacent in the array in order to form a range.
// Assume that there will only be one largest range.

namespace Questions.xHard
{
    [TestFixture]
    class Arrays_LargestRange
    {
        [TestCase(new int[] { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6 }, ExpectedResult = new int[] { 0, 7 })] // [0 ,1 , 2, 3, 4, 5, 6, 7]
        public static int[] LargestRange(int[] array)
        {
            var dic = new Dictionary<int, bool>();
            int maxStart = 0;
            int maxLength = 0;

            foreach (var v in array)
                dic[v] = false;

            foreach (var center in new Dictionary<int, bool>(dic).Keys)
            {
                if (dic[center]) // If already visited
                    continue;

                dic[center] = true; 
                int left = center - 1;
                int right = center + 1;
                int length = 1;

                while (dic.ContainsKey(left))
                {
                    dic[left] = true;
                    ++length;
                    --left;
                }

                while (dic.ContainsKey(right))
                {
                    dic[right] = true;
                    ++length;
                    ++right;
                }

                if (length > maxLength)
                {
                    maxStart = left + 1;
                    maxLength = length;
                }
            }

            return new int[] { maxStart, maxStart + maxLength - 1 };
        }
    }
}
