using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class Searching_SearchInSortedMatrix
    {
        [Test]
        public static void DoTest()
        {
            var input = new int[,]
            {
                { 1, 4, 7, 12, 15, 1000 },
                { 2, 5, 19, 31, 32, 1001 },
                { 3, 8, 24, 33, 35, 1002 },
                { 40, 41, 42, 44, 45, 1003 },
                { 99, 100, 103, 106, 128, 1004 }
            };

            var expected = new int[] { 3, 3 };
            CollectionAssert.AreEqual(expected, SearchInSortedMatrix(input, 44));

            var expected2 = new int[] { 4, 0 };
            CollectionAssert.AreEqual(expected2, SearchInSortedMatrix(input, 99));

            var expected3 = new int[] { 0, 5 };
            CollectionAssert.AreEqual(expected3, SearchInSortedMatrix(input, 1000));
        }
        // T: O(n+m)
        // S: O(1)
        public static int[] SearchInSortedMatrix(int[,] matrix, int target)
        {
            int x = matrix.GetLength(1) - 1;
            int y = 0;

            while (x >= 0 && y < matrix.GetLength(0))
            {
                if (target < matrix[y, x])
                    --x;
                else if (target > matrix[y, x])
                    ++y;
                else
                    return new int[] { y, x };
            }

            return new int[] { -1, -1 };
        }
    }
}
