using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Medium
{
    class DynamicProg_NumberOfWaysToMakeChange
    {
        // ( 6$, [1$, 5$] ) => 2 ( 1x1 + 1x5 and 6x1 )
        [TestCase(6, new int[] { 1, 5 }, ExpectedResult = 2)]
        // ( 0$, [1$, 5$, 10$, 25$] ) => 4 ( 1x10, 2x5, (1x5 + 5x1), 10x1 )
        [TestCase(10, new int[] { 1, 5, 10, 25}, ExpectedResult = 4)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 7)]
        // T: O(n * denom)
        // S: O(n)
        public static int NumberOfWaysToMakeChange(int n, int[] denoms)
        {
            var ways = new int[n+1];
            ways[0] = 1;

            foreach (var denom in denoms)
            {
                for (int amount = 1; amount < ways.Length; amount++)
                {
                    if (denom <= amount)
                    {
                        ways[amount] += ways[amount - denom];
                    }
                }
                Print(ways);
            }

            return ways[n];
        }

        public static void Print(int[] ways)
        {
            for (int i = 0; i < ways.Length; i++)
                Console.Write(i.ToString().PadLeft(2, ' ') + ", ");

            Console.WriteLine();

            for (int i = 0; i < ways.Length; i++)
                Console.Write(ways[i].ToString().PadLeft(2, ' ') + ", ");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

// (10$, [1$, 5$, 10$, 25$]) => 4 (1x10, 2x5, (1x5 + 5x1), 10x1)

// 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10    $0
// 1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0

// 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10    $1      if (1 <= amount)    ways[amount] += ways[amount - denom];
// 1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1                                ways[amount] += ways[amount - 1];

// 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10    $5      if (5 <= amount)    ways[amount] += ways[amount - denom];
// 1,  1,  1,  1,  1,  2,  2,  2,  2,  2,  3                                ways[amount] += ways[amount - 5];

// 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10    $10     if (10 <= amount)   ways[amount] += ways[amount - denom];
// 1,  1,  1,  1,  1,  2,  2,  2,  2,  2,  4                                ways[amount] += ways[amount - 10];

// 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10    $25     if (25 <= amount)   ways[amount] += ways[amount - denom];
// 1,  1,  1,  1,  1,  2,  2,  2,  2,  2,(4)                                ways[amount] += ways[amount - 25];



//----------------------------
//   (5, [1,2,3,4,5]) => 7
//----------------------------
// 0,  1,  2,  3,  4,  5,   $1      | (1x5) |            |            |            |            |            |       |
// 1,  1,  1,  1,  1,  1,           |       |            |            |            |            |            |       |
//                                  |       |            |            |            |            |            |       |
// 0,  1,  2,  3,  4,  5,   $2      | (1x5) | (1x1, 2x1) | (1x3, 2x1) |            |            |            |       |
// 1,  1,  2,  2,  3,  3,           |       |            |            |            |            |            |       |
//                                  |       |            |            |            |            |            |       |
// 0,  1,  2,  3,  4,  5,   $3      | (1x5) | (1x1, 2x1) | (1x3, 2x1) | (1x2, 3x1) | (2x1, 3x1) |            |       |
// 1,  1,  2,  3,  4,  5,           |       |            |            |            |            |            |       |
//                                  |       |            |            |            |            |            |       |
// 0,  1,  2,  3,  4,  5,   $4      | (1x5) | (1x1, 2x1) | (1x3, 2x1) | (1x2, 3x1) | (2x1, 3x1) | (1x1, 4x1) |       |
// 1,  1,  2,  3,  5,  6,           |       |            |            |            |            |            |       |
//                                  |       |            |            |            |            |            |       |
// 0,  1,  2,  3,  4,  5,   $5      | (1x5) | (1x1, 2x1) | (1x3, 2x1) | (1x2, 3x1) | (2x1, 3x1) | (1x1, 4x1) | (5x1) |
// 1,  1,  2,  3,  5,  7,           |       |            |            |            |            |            |       |
