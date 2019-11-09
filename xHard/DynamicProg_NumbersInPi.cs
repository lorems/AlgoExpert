using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

// Given a string representation of the first n digits of Pi and a list of your
// favorite numbers(all positive integers in string format), write a function
// that returns the smallest number of spaces that need to be added to the n
// digits of Pi such that all resulting numbers are found in the list of
// favorite numbers.

namespace Questions.xHard
{
    [TestFixture]
    class DynamicProg_NumbersInPi
    {
         // 13 => "3|1|4|1|592|65|35|8|9793|2384626|4|3|3|83279"
        [TestCase("3141592653589793238462643383279",
            new string[] { "3", "1", "4", "592", "65", "55", "35", "8", "9793", "2384626", "83279" },
            ExpectedResult = 13)]
        [TestCase("314",
            new string[] { "33" },
            ExpectedResult = -1)]
        [TestCase("314",
            new string[] { "314" },
            ExpectedResult = 0)]
        [TestCase("314",
            new string[] { "3", "14" },
            ExpectedResult = 1)]
        // 2 => "31|4159|2"
        [TestCase("3141592",
            new string[] { "3141", "5", "31", "2", "4159", "9", "42" },
            ExpectedResult = 2)]
        // 2 => "314159265|35897932384626433832|79"
        [TestCase("3141592653589793238462643383279",
            new string[] { "314159265358979323846", "26433", "8", "3279", "314159265", "35897932384626433832", "79" },
            ExpectedResult = 2)]
        // T: O(n^3 + m) S: O(n + m) - where n is pi and m is number of favorite number
        public static int NumbersInPi(string pi, string[] numbers)
        {
            var cache = new Dictionary<string, int>();
            var targets = numbers.ToHashSet();
            int spaces = FindShortest(cache, targets, pi);

            return spaces == -99  ? -1 : spaces;
        }

        public static int FindShortest(Dictionary<string, int> cache, HashSet<string> targets, string str)
        {
            if (str.Length == 0)
                return -1;

            int superMinSpace = int.MaxValue;

            for (int i = 1; i <= str.Length; i++)
            {
                string leftPart = str.Substring(0, i);

                if (targets.Contains(leftPart))
                {
                    string rightPart = str.Substring(i);

                    int minSpaces = (cache.ContainsKey(rightPart)
                        ? cache[rightPart]
                        : FindShortest(cache, targets, rightPart));
                    
                    if (minSpaces == -99)
                        continue;
                    
                    superMinSpace = Math.Min(minSpaces + 1, superMinSpace);
                }
                else if (i == str.Length && superMinSpace == int.MaxValue)
                {
                    return -99; // no solutions
                }
            }
            cache[str] = superMinSpace;

            return cache[str];
        }
    }
}
