using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.xHard
{
    class Arrays_FourNumberSum
    {
        [Test]
        public static void DoTest()
        {
            var inputArray = new int[] { 7, 6, 4, -1, 1, 2 };
            var expected = new List<int[]> { new int[] { 7, 6, 4, -1 }, new int[] { 7, 6, 1, 2 } };
            var actual = FourNumberSum(inputArray, 16);

            Assert.That(expected.Count, Is.EqualTo(actual.Count));

            actual.ForEach(x => Array.Sort(x));
            expected.ForEach(x => Array.Sort(x));
            
            CollectionAssert.AreEquivalent(expected, actual);
        }

        // Avg   T: O(n^2) S: O(n^2)
        // Worst T: O(n^3) S: O(n^2)
        public static List<int[]> FourNumberSum(int[] array, int targetSum)
        {
            var result = new List<int[]>();
            var dblSum = new Dictionary<int, List<int[]>>();

            for (int i = 0; i < array.Length; i++)
            {
                // Loop right, check for matches
                for (int j = i+1; j < array.Length; j++)
                {
                    int target = targetSum - array[i] - array[j];

                    // Compare pairs
                    if (dblSum.ContainsKey(target)) 
                        dblSum[target].ForEach(x => result.Add(new int[] { x[0], x[1], array[i], array[j] }));
                }
                // Loop left, add possible matches
                for (int k = i-1; k >=0 ; k--)
                {
                    int sum = array[i] + array[k];

                    if (!dblSum.ContainsKey(sum))
                        dblSum[sum] = new List<int[]>();

                    dblSum[sum].Add(new int[] { array[i], array[k] });
                }
            }

            return result;
        }
    }
}
