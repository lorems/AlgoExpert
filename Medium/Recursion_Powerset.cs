using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// Find all subsets

namespace Questions.Medium
{
    [TestFixture]
    class Recursion_Powerset
    {
        [Test]
        public static void DoTest()
        {
            var input = new List<int> { 1, 2, 3 };
            var input2 = new List<int> { 1, 2, 3 };
            var expected = new List<List<int>>
            {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 2, 3 },
                new List<int> { 1, 2, 3 }
            };

            CollectionAssert.AreEquivalent(expected, Powerset(input));
            CollectionAssert.AreEquivalent(expected, PowersetV2(input2));
        }
        // Iterative
        // T: O(n*2^n) S: O(n*2^n)
        public static List<List<int>> Powerset(List<int> array)
        {
            var subsets = new List<List<int>>() { new List<int>() }; // init with empty set

            foreach (var v in array)
            {
                var extraSet = new List<List<int>>();
                foreach (var set in subsets)
                {
                    var copy = new List<int>(set);
                    copy.Add(v);
                    extraSet.Add(copy);
                }
                subsets.AddRange(extraSet);
            }

            return subsets;
        }

        // Recursive
        public static List<List<int>> PowersetV2(List<int> array)
        {
            var result =  PowersetRec(array, array.Count - 1);
            return result;
        }

        public static List<List<int>> PowersetRec(List<int> array, int i)
        {
            if (i < 0)
                return new List<List<int>>() { new List<int>() }; // init with empty set

            int v = array[i];
            var subsets = PowersetRec(array, i - 1);
            int length = subsets.Count;

            for (int j = 0; j < length; j++)
            {
                var copy = new List<int>(subsets[j]);
                copy.Add(v);
                subsets.Add(copy);
            }
            return subsets;
        }
    }
}
