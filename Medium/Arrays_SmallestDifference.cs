using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
// { -1, 5, 10, 20, 28, 3 }
// { 26, 134, 135, 15, 17 }

// { -1, 3, 5, 10, 20, 28 }
// { 15, 17, 26, 134, 135 }

namespace Questions.Medium
{
    class Arrays_SmallestDifference
    {
        [TestCase(new int[] { -1, 5, 10, 20, 28, 3 }, new int[] { 26, 134, 135, 15, 17 }, ExpectedResult = new int[] { 28,26 })]
        [TestCase(new int[] { 1, 50 }, new int[] { 55 }, ExpectedResult = new int[] { 50, 55 })]
        [TestCase(new int[] { 50 }, new int[] { 55 }, ExpectedResult = new int[] { 50, 55 })]
        [TestCase(new int[] { 999 }, new int[] { 3,55,100 }, ExpectedResult = new int[] { 999,100 })]
        // Time O(nlog(n) + mlog(m)) Space: O(1)
        public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);
            
            int val1 = arrayOne[0];
            int val2 = arrayTwo[0];
            int[] result = new int[] { val1, val2 };
            int j = 0;

            for (int i = 0; i < arrayOne.Length; i++)
            {
                val1 = arrayOne[i];
                result = setMinDiff(result, val1, val2);

                if (val1 < val2)
                    continue;

                while (val1 > val2 && j < arrayTwo.Length - 1)
                {
                    ++j;
                    val2 = arrayTwo[j];
                    result = setMinDiff(result, val1, val2);
                }
            }

            return result;
        }

        public static int[] setMinDiff(int[] result, int val1, int val2)
        {
            int maybeMin = Math.Abs(val1 - val2);
            int min = Math.Abs(result[0] - result[1]);
            if (maybeMin < min)
            {
                result[0] = val1;
                result[1] = val2;
            }
            return result;
        }

        [TestCase(new int[] { -1, 5, 10, 20, 28, 3 }, new int[] { 26, 134, 135, 15, 17 }, ExpectedResult = new int[] { 28, 26 })]
        [TestCase(new int[] { 1, 50 }, new int[] { 55 }, ExpectedResult = new int[] { 50, 55 })]
        [TestCase(new int[] { 50 }, new int[] { 55 }, ExpectedResult = new int[] { 50, 55 })]
        [TestCase(new int[] { 999 }, new int[] { 3, 55, 100 }, ExpectedResult = new int[] { 999, 100 })]
        public static int[] SmallestDifferenceV2(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);
            int i = 0;
            int j = 0;
            int[] result = new int[] { arrayOne[i], arrayTwo[j] };

            while (i < arrayOne.Length && j < arrayTwo.Length)
            {
                int val1 = arrayOne[i];
                int val2 = arrayTwo[j];
                int maybeMin = Math.Abs(val1 - val2);
                int min = Math.Abs(result[0] - result[1]);

                if (maybeMin < min)
                    result = new int[] { val1, val2 };

                if (val1 < val2)
                    ++i;
                else
                    ++j;

            }
            return result;
        }
    }
}
