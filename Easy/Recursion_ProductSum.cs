using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    [TestFixture]
    public class Recursion_ProductSum
    {
        [Test]
        public void DoTest()
        {
            var array = new List<object>
            {
                5,
                2,
                new List<object>{7, -1},
                3,
                new List<object>
                {
                    6,
                    new List<object>{-13, 8},
                    4
                }
            };
            // 12 = (5 + 2 + 2 * (7 - 1) + 3 + 2 * (6 + 3 * (-13 + 8) + 4)
            Assert.That(ProductSum(array), Is.EqualTo(12));
        }
        // O(n) time | O(d) space - where n is the total number of elements in the array,
        // including sub-elements, and d is the greatest depth of "special" arrays in the array
        public static int ProductSum(List<object> array)
        {
            return RecSum(array, 1);
        }
        static int RecSum(List<object> array, int depth)
        {
            int sum = 0;
            foreach (var n in array)
            {
                if (n.GetType() == typeof(int))
                    sum += (int)n;
                else
                    sum += RecSum((List<object>)n, 1 + depth);
            }

            return depth * sum;
        }
    }
}
