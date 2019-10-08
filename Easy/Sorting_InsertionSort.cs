using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    [TestFixture]
    class Sorting_InsertionSort
    {
        [TestCase(new int[] { 8, 5, 2, 9, 5, 6, 3 }, ExpectedResult = new int[] { 2, 3, 5, 5, 6, 8, 9 })]
        [TestCase(new int[] { 2, 1, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        public static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int elemToSort = array[i];
                int indexToCompare = i - 1;
                while (indexToCompare >= 0 && elemToSort < array[indexToCompare])
                {
                    array[indexToCompare+1] = array[indexToCompare];
                    --indexToCompare;
                }
                array[indexToCompare + 1] = elemToSort;
            }
            return array;
        }
    }
}
