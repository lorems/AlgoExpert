using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// Operation
// 1) Insert character
// 2) Delete character
// 3) Substitute character

namespace Questions.Medium
{
    [TestFixture]
    class DynamicProg_LevenshteinDistance
    {
        [TestCase("abc", "yabd", ExpectedResult = 2)] // insert "y", substitute "c" for "d"
        [TestCase("biting", "mitten", ExpectedResult = 4)]
        // T: O(nm)
        // S: O(nm)
        public static int LevenshteinDistance(string str1, string str2)
        {
            var matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int x = 0; x < matrix.GetLength(0); x++)
                matrix[x, 0] = x;
            for (int y = 0; y < matrix.GetLength(1); y++)
                matrix[0, y] = y;

            for (int y = 1; y < matrix.GetLength(1); y++)
            {
                for (int x = 1; x < matrix.GetLength(0); x++)
                {
                    matrix[x, y] = (str1[x - 1] == str2[y - 1])
                        ? matrix[x - 1, y - 1]
                        : 1 + Math.Min(matrix[x - 1, y],
                                Math.Min(
                                    matrix[x - 1, y - 1],
                                    matrix[x, y - 1]));
                }
            }

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }
        static void Print(int[,] matrix)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    Console.Write(matrix[x, y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
