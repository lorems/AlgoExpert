using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    class Graphs_HasSingleCycle
    {
        [TestCase(new int[] { 1, 1, 1, 1, -1, -2 }, ExpectedResult = false)]
        [TestCase(new int[] { 2, 3, 1, -4, -4, 2 }, ExpectedResult = true)]
        [TestCase(new int[] { 2, 3, 1, -4, 1, 2 }, ExpectedResult = false)]
        public static bool HasSingleCycle(int[] array)
        {
            int index = 0;
            var set = new HashSet<int>();

            for (int i = 0; i < array.Length; i++)
            {
                index = (index + array[index]) % array.Length;
                index = index >= 0 
                            ? index 
                            : array.Length + index;
                set.Add(index);
            }

            return set.Count == array.Length;
        }
        [TestCase(new int[] { 2, 3, 1, -4, -4, 2 }, ExpectedResult = true)]
        [TestCase(new int[] { 2, 3, 1, -4, 1, 2 }, ExpectedResult = false)]
        public static bool HasSingleCycleV2(int[] array)
        {
            int numVisited = 0;
            int index = 0;

            while (numVisited < array.Length)
            {
                if (numVisited > 0 && index == 0)
                    return false;

                numVisited++;
                index = (index + array[index]) % array.Length;
                index = index >= 0
                        ? index
                        : array.Length + index;
            }

            return index == 0;
        }

        [TestCase(new int[] { 2, 3, 1, -4, -4, 2 }, ExpectedResult = true)]
        [TestCase(new int[] { 2, 3, 1, -4, 1, 2 }, ExpectedResult = false)]
        public static bool HasSingleCycleV3(int[] array)
        {
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0 && index == 0)
                    return false;

                int jump = array[index];
                index = (index + jump) % array.Length;
                index = index >= 0
                        ? index
                        : array.Length + index;
            }

            return index == 0;
        }
    }
}
