using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// You are given an array of integers. Each non-zero integer represents the
// height of a pillar of width 1. Imagine water being poured over all of the
// pillars and return the surface area of the water trapped between the pillars
// viewed from the front. Note that spilled water should be ignored. Refer to
// the first minute of the video explanation below for a visual example.

//      |                  |
//      |        |         |                 |
//      |        |         |        |  |     |
// { 0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3 }
//   0, 1, 2, 3, 4, 5, 6,  7, 8, 9,10,11,12,13
namespace Questions.xHard
{
    [TestFixture]
    class DynamicProg_WaterArea
    {
        [TestCase(new int[] { 0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3 }, ExpectedResult = 48)]
        // T: O(n) S: O(n)
        public static int WaterAreaV1(int[] heights)
        {
            if (heights.Length == 0)
                return 0;

            int sum = 0;
            var leftPillars = new int[heights.Length];
            var rightPillars = new int[heights.Length];
            leftPillars[0] = heights[0];
            rightPillars[heights.Length - 1] = heights[heights.Length - 1];

            for (int i = 1; i < heights.Length; i++)
                leftPillars[i] = Math.Max(leftPillars[i - 1], heights[i - 1]);

            for (int i = heights.Length - 2; i >=0; i--)
                rightPillars[i] = Math.Max(rightPillars[i + 1], heights[i + 1]);

            for (int i = 0; i < heights.Length; i++)
            {
                int potentialSum = Math.Min(leftPillars[i], rightPillars[i]) - heights[i];
                sum += potentialSum < 0 ? 0 : potentialSum;
            }

            return sum;
        }

        [TestCase(new int[] { 0, 8, 0, 0, 5, 0, 0, 10, 0, 0, 1, 1, 0, 3 }, ExpectedResult = 48)]
        // Version with single array
        // T: O(n) S: O(n)
        public static int WaterAreaV2(int[] heights)
        {
            if (heights.Length == 0)
                return 0;

            int sum = 0;
            var maxWater = new int[heights.Length];
            maxWater[0] = heights[0];

            for (int i = 1; i < heights.Length; i++)
                maxWater[i] = Math.Max(maxWater[i - 1], heights[i - 1]);

            int rightPillar = 0;

            for (int i = heights.Length - 1; i >= 0; i--)
            {
                maxWater[i] = Math.Min(maxWater[i], rightPillar);
                int potentialmax = maxWater[i] - heights[i];
                sum += potentialmax < 0 ? 0 : potentialmax;
                rightPillar = Math.Max(rightPillar, heights[i]);
            }

            return sum;
        }
    }
}
