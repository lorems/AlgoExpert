using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    [TestFixture]
    class Sorting_BubbleSort
    {
        // |----------------------------|
        // |0 1 2 3 | 0 1 2 3 | 0 1 2 3 | 
        // |--------|---------|---------|
        // |4 3 2 1 | 3 2 1 4 | 2 1 3 4 |
        // |3 4 2 1 | 2 3 1 4 | 1 2 3 4 |
        // |3 2 4 1 | 2 1 3 4 |         |
        // |3 2 1 4 |         |         |
        // |----------------------------|
        [TestCase(new int[] { 8, 5, 2, 9, 5, 6, 3 }, ExpectedResult = new int[] { 2, 3, 5, 5, 6, 8, 9 })]
        [TestCase(new int[] { 2, 1, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        swap(j, j + 1, array);
                    }
                }
            }
            return array;
        }

        public static void swap(int a, int b, int[] array)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
        [TestCase(new int[] { 8, 5, 2, 9, 5, 6, 3 }, ExpectedResult = new int[] { 2, 3, 5, 5, 6, 8, 9 })]
        [TestCase(new int[] { 2, 1, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        public static int[] BubbleSortV2(int[] array)
        {
            bool isSorted = false;
            int i = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        swap(j, j + 1, array);
                        isSorted = false;
                    }
                }
                ++i;
            }

            return array;
        }
    }
}
