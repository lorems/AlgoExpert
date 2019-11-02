using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Imagine that you're a teacher who's just graded the final exam in a class.
// You have a list of student scores on the final exam in a particular order
// (not necessarily sorted), and you want to reward your students.You decide
// to do so fairly by giving them arbitrary rewards following two rules: first,
// all students must receive at least one reward; second, any given student
// must receive strictly more rewards than an adjacent student(a student
// immediately to the left or to the right) with a lower score and must receive
// strictly fewer rewards than an adjacent student with a higher score.Assume
// that all students have different scores; in other words, the scores are all
// unique.Write a function that takes in a list of scores and returns the
// minimum number of rewards that you must give out to students, all the while
// satisfying the two rules.

//  2 5 1 9
//  0 2 1 2
//  1 2 1 2
//  1 2 1 2
//  1 2 1 2

namespace Questions.xHard
{
    [TestFixture]
    class Arrays_MinRewards
    {
        [TestCase(new int[] { 8, 4, 2, 1, 3, 6, 7, 9, 5 }, ExpectedResult = 25)] // [4, 3, 2, 1, 2, 3, 4, 5, 1]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 3)] 
        [TestCase(new int[] { 2, 1 }, ExpectedResult = 3)]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = 6)]
        [TestCase(new int[] { 800, 400, 20, 10, 30, 61, 70, 90, 17,
                              21, 22, 13, 12, 11, 8, 4, 2, 1, 3, 6,
                              7, 9, 0, 68, 55, 67, 57, 60, 51, 661,
                              50, 65, 53 }, ExpectedResult = 93)]
        // T: O(n(log(n))
        public static int MinRewardsV1(int[] scores)
        {
            var indexDic = new Dictionary<int, int>();
            var gifs = new int[scores.Length];
            var sortedScores = scores.Clone() as int[];
            Array.Sort(sortedScores);

            for (int i = 0; i < scores.Length; i++)
                indexDic[scores[i]] = i;

            foreach (var s in sortedScores)
            {
                int position = indexDic[s];
                int leftGift = position > 0 ? gifs[position - 1] : 0;
                int rightGift = position < scores.Length - 1 ? gifs[position + 1] : 0;

                gifs[position] = Math.Max(leftGift, rightGift) + 1;
            }
            
            return gifs.Sum();
        }

        [TestCase(new int[] { 8, 4, 2, 1, 3, 6, 7, 9, 5 }, ExpectedResult = 25)] // [4, 3, 2, 1, 2, 3, 4, 5, 1]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 1 }, ExpectedResult = 3)]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = 6)]
        [TestCase(new int[] { 3, 2, 1, 44, 55, 33, 22 }, ExpectedResult = 14)]
        // T: O(n) S: O(n)
        // T: O(n^2) S: O(n)
        public static int MinRewardsV2(int[] scores)
        {
            var gifts = new int[scores.Length];
            Array.Fill(gifts, 1);

            for (int i = 1; i < scores.Length; i++)
            {
                int leftScore = scores[i - 1];
                int currScore = scores[i];

                if (leftScore > currScore)
                {
                    for (int j = i - 1; j >= 0 && scores[j] > scores[j + 1]; j--)
                        gifts[j] = Math.Max(gifts[j], gifts[j + 1] + 1);
                }
                else if (leftScore < currScore)
                    gifts[i] = gifts[i - 1] + 1;
            }

            return gifts.Sum();
        }

        [TestCase(new int[] { 8, 4, 2, 1, 3, 6, 7, 9, 5 }, ExpectedResult = 25)] // [4, 3, 2, 1, 2, 3, 4, 5, 1]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 1 }, ExpectedResult = 3)]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = 6)]
        [TestCase(new int[] { 3, 2, 1,44,55,33,22 }, ExpectedResult = 14)]
        // T: O(n) S: O(n)
        public static int MinRewardsV3(int[] scores)
        {
            var gifts = new int[scores.Length];
            var localMinsIndexes = new List<int>();

            for (int i = 0; i < scores.Length; i++)
            {
                int leftScore = i == 0 ? int.MaxValue : scores[i - 1];
                int score = scores[i];
                int rightScore = i == scores.Length - 1 ? int.MaxValue : scores[i + 1]; 

                 if (score < leftScore && score < rightScore)
                    localMinsIndexes.Add(i);
            }

            foreach (var mins in localMinsIndexes)
            {
                gifts[mins] = 1;

                for (int i = mins - 1; i >= 0 && scores[i] > scores[i + 1]; i--) // stop loop after localMax
                    gifts[i] = Math.Max(gifts[i], gifts[i + 1] + 1);

                for (int i = mins + 1; i < scores.Length && scores[i] > scores[i - 1]; i++) // stop loop after localMax
                    gifts[i] = Math.Max(gifts[i], gifts[i - 1] + 1);
            }

            return gifts.Sum();
        }

        [TestCase(new int[] { 8, 4, 2, 1, 3, 6, 7, 9, 5 }, ExpectedResult = 25)] // [4, 3, 2, 1, 2, 3, 4, 5, 1]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 1 }, ExpectedResult = 3)]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = 6)]
        [TestCase(new int[] { 3, 2, 1, 44, 55, 33, 22 }, ExpectedResult = 14)]
        // T: O(n) S: O(n)
        public static int MinRewardsV4(int[] scores)
        {
            var gifts = new int[scores.Length];
            Array.Fill(gifts, 1);

            for (int i = 1; i < scores.Length; i++)
                gifts[i] = (scores[i] > scores[i - 1]) ? Math.Max(gifts[i], gifts[i - 1] + 1) : gifts[i];

            for (int i = scores.Length - 2; i >= 0; i--)
                gifts[i] = (scores[i] > scores[i + 1]) ? Math.Max(gifts[i], gifts[i + 1] + 1) : gifts[i];

            return gifts.Sum();
        }
    }
}
