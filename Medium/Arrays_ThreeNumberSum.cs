using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class Arrays_ThreeNumberSum
    {
        [Test]
        public void DoTest()
        {
            var expectedResult = new List<int[]> { new int[] { -8, 2, 6 }, new int[] { -8, 3, 5 }, new int[] { -6, 1, 5 } };
            var result = ThreeNumberSum(new int[] { 12, 3, 1, 2, -6, 5, -8, 6 }, 0);
            CollectionAssert.AreEqual(expectedResult, result);

            var result2 = ThreeNumberSumV2(new int[] { 12, 3, 1, 2, -6, 5, -8, 6 }, 0);
            CollectionAssert.AreEqual(expectedResult, result2);
        }
        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            var result = new List<int[]>();
            var set = new HashSet<int>(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    int target = targetSum - array[i] - array[j];
                    if (set.Contains(target) && target > array[j])
                    {
                        result.Add(new int[3] { array[i], array[j], target });
                    }
                }
            }

            return result;
        }
        // Time  O(n^2)
        // Space O(n)
        public static List<int[]> ThreeNumberSumV2(int[] array, int targetSum)
        {
            Array.Sort(array);
            var result = new List<int[]>();

            for (int i = 0; i < array.Length; i++)
            {
                int left = i + 1;
                int right = array.Length - 1;

                while (left < right)
                {
                    if (array[i] + array[right] + array[left] == targetSum)
                    {
                        result.Add(new int[3] { array[i], array[left], array[right] });
                        ++left;
                        --right;
                    }
                    else if (array[i] + array[right] + array[left] > targetSum)
                    {
                        --right;
                    }
                    else
                    {
                        ++left;
                    }
                }
            }
            return result;
        }
    }
}
