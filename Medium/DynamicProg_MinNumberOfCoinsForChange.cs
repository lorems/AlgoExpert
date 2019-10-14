using NUnit.Framework;
using System;
using System.Text;

namespace Questions.Medium
{
    class DynamicProg_MinNumberOfCoinsForChange
    {
        [TestCase(6, new int[] { 1, 2, 4 }, ExpectedResult = 2)] // 4x2 + 2x1
        [TestCase(7, new int[] { 1, 5, 10 }, ExpectedResult = 3)] // 1+1 + 1x1 + 1x5
        [TestCase(0, new int[] { 7, 8 }, ExpectedResult = 0)]
        [TestCase(7, new int[] { }, ExpectedResult = -1)]
        [TestCase(3, new int[] { 2, 1 }, ExpectedResult = 2)]
        [TestCase(135, new int[] { 39, 45, 130, 40, 4, 1, 60, 75 }, ExpectedResult = 2)]
        [TestCase(135, new int[] { 1, 60, 75 }, ExpectedResult = 2)]
        public static int MinNumberOfCoinsForChange(int n, int[] denoms)
        {
            var minCoins = new int[n + 1];
            Array.Fill(minCoins, int.MaxValue);
            minCoins[0] = 0;

            foreach (var denom in denoms)
            {
                for (int amount = 1; amount < minCoins.Length; amount++)
                {
                    if (amount < denom)
                        continue;

                    int rest = amount - denom;

                    if (minCoins[rest] == int.MaxValue)
                        continue;

                    minCoins[amount] = Math.Min(minCoins[amount], minCoins[rest] + 1);
                }
            }

            return minCoins[n] == int.MaxValue ? -1 : minCoins[n];
        }
        [TestCase(6, new int[] { 1, 2, 4 }, ExpectedResult = 2)] // 4x2 + 2x1
        [TestCase(7, new int[] { 1, 5, 10 }, ExpectedResult = 3)] // 1+1 + 1x1 + 1x5
        [TestCase(0, new int[] { 7, 8 }, ExpectedResult = 0)]
        [TestCase(7, new int[] { }, ExpectedResult = -1)]
        [TestCase(3, new int[] { 2, 1 }, ExpectedResult = 2)]
        [TestCase(135, new int[] { 39, 45, 130, 40, 4, 1, 60, 75 }, ExpectedResult = 2)]
        [TestCase(135, new int[] { 1, 60, 75 }, ExpectedResult = 2)]
        public static int MinNumberOfCoinsForChangeV2(int n, int[] denoms)
        {
            var minCoins = new int[n + 1];
            Array.Fill(minCoins, int.MaxValue);
            minCoins[0] = 0;

            foreach (var denom in denoms)
            {
                for (int amount = 1; amount < minCoins.Length; amount++)
                {
                    if (amount >= denom)
                    {
                        int rest = amount - denom;

                        if (minCoins[rest] != int.MaxValue)
                            minCoins[amount] = Math.Min(minCoins[amount], minCoins[rest] + 1);
                    }
                }
            }

            return minCoins[n] == int.MaxValue ? -1 : minCoins[n];
        }
    }
}
