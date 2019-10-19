using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class Recursion_Permutations
    {
        [Test]
        public static void DoTest()
        {
            var input = new List<int> { 1, 2, 3 };
            var expected = new List<List<int>> {
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 3, 2 },
                new List<int> { 2, 1, 3 },
                new List<int> { 2, 3, 1 },
                new List<int> { 3, 1, 2 },
                new List<int> { 3, 2, 1 }
            };

            var actual = GetPermutations(input);

            Assert.That(expected.Count, Is.EqualTo(actual.Count));
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public static void DoTestV2()
        {
            var input = new List<int> { 1, 2, 3 };
            var expected = new List<List<int>> {
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 3, 2 },
                new List<int> { 2, 1, 3 },
                new List<int> { 2, 3, 1 },
                new List<int> { 3, 1, 2 },
                new List<int> { 3, 2, 1 }
            };

            var actual = GetPermutationsV2(input);

            Assert.That(expected.Count, Is.EqualTo(actual.Count));
            CollectionAssert.AreEquivalent(expected, actual);
        }
        // T: O(n^2*n!) S: O(n*n!)
        public static List<List<int>> GetPermutations(List<int> array)
        {
            if (array.Count == 0)
                return new List<List<int>>();

            var result = new List<List<int>>();

            PermutationsRec(result, array, array.Count, new List<int>(new int[array.Count]));

            return result;
        }

        public static void PermutationsRec(List<List<int>> result, List<int> arrayX, int length, List<int> currentPermutation)
        {
            for (int i = 0; i < arrayX.Count; i++)            
            {
                int currentIdx = length - arrayX.Count;
                currentPermutation[currentIdx] = arrayX[i];

                if (arrayX.Count == 1)
                {
                    result.Add(new List<int>(currentPermutation)); // add a copy
                }
                else
                {
                    var arrayY = new List<int>(arrayX); // make a copy
                    arrayY.RemoveAt(i);
                    PermutationsRec(result, arrayY, length, currentPermutation);
                }
            }         
        }
        // T: O(n*n!) S: O(n*n!)
        public static List<List<int>> GetPermutationsV2(List<int> array)
        {
            if (array.Count == 0)
                return new List<List<int>>();

            var result = new List<List<int>>();

            PermutationsRecV2(result, array, 0);

            return result;
        }

        public static void PermutationsRecV2(List<List<int>> result, List<int> array, int i)
        {
            for (int j = i; j < array.Count; j++)
            {
                if (i == array.Count - 1)
                {
                    result.Add(new List<int>(array));
                }
                else
                {
                    Swap(array, i, j);
                    PermutationsRecV2(result, array, i + 1);
                    Swap(array, i, j);
                }
            }
        }

        public static void Swap(List<int> array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        public static List<List<int>> GetPermutationsPOC(List<int> array)
        {
            if (array.Count == 0)
                return new List<List<int>>();

            var result = new List<List<int>>();
            var arrayA = new List<int>(array);

            foreach (var a in arrayA)
            {
                var current = new List<int>(new int[3]);

                current[array.Count - arrayA.Count] = a; 
                var arrayB = new List<int>(arrayA);
                arrayB.Remove(a);
                foreach (var b in arrayB)
                {
                    current[array.Count - arrayB.Count] = b;
                    var arrayC = new List<int>(arrayB);
                    arrayC.Remove(b);
                    foreach (var c in arrayC)
                    {
                        current[array.Count - arrayC.Count] = c;
                        result.Add(current.ToList());
                    }
                }
            }

            return result;
        }
    }
}
