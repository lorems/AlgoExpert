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
                int myGift = gifs[position];
                int rightGift = position < scores.Length - 1 ? gifs[position + 1] : 0;

                gifs[position] = Math.Max(leftGift, rightGift) + 1;
            }
            
            return gifs.Sum();
        }
        [TestCase(new int[] { 8, 4, 2, 1, 3, 6, 7, 9, 5 }, ExpectedResult = 25)] // [4, 3, 2, 1, 2, 3, 4, 5, 1]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 1 }, ExpectedResult = 3)]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = 6)]
        [TestCase(new int[] { 800, 400, 20, 10, 30, 60, 70, 90, 17,
                              21, 22, 13, 12, 11, 8, 4, 2, 1, 3, 6,
                              7, 9, 0, 68, 55, 67, 57, 60, 51, 661,
                              50, 65, 53 }, ExpectedResult = 93)] // include duplicate score
        // T: O(n(log(n))
        public static int MinRewardsV1_NonUnique(int[] scores)
        {
            var indexDic = new Dictionary<int, List<int>>();
            var gifs = new int[scores.Length];
            var sortedScores = scores.Clone() as int[];
            Array.Sort(sortedScores);

            for (int i = 0; i < scores.Length; i++)
            {
                if (!indexDic.ContainsKey(scores[i]))
                    indexDic[scores[i]] = new List<int>();

                indexDic[scores[i]].Add(i);
            }

            foreach (var sc in sortedScores)
            {
                var positions = indexDic[sc];
                foreach (var position in positions)
                {
                    int leftGift = position > 0 ? gifs[position - 1] : 0;
                    int myGift = gifs[position];
                    int rightGift = position < scores.Length - 1 ? gifs[position + 1] : 0;

                    gifs[position] = Math.Max(leftGift, rightGift) + 1;
                }                
            }

            return gifs.Sum();
        }
    }
}
