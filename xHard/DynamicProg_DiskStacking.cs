using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// You are given a non-empty array of arrays.Each subarray holds three
// integers and represents a disk. These integers denote each disk's width,
// depth, and height, respectively.Your goal is to stack up the disks and to
// maximize the total height of the stack. A disk must have a strictly smaller
// width, depth, and height than any other disk below it. Write a function that
// returns an array of the disks in the final stack, starting with the top disk
// and ending with the bottom disk.Note that you cannot rotate disks; in other
// words, the integers in each subarray must represent[width, depth, height]
// at all times.Assume that there will only be one stack with the greatest
// total height.

namespace Questions.xHard
{
    [TestFixture]
    class DynamicProg_DiskStacking
    {
        [Test]
        public static void DoTest()
        {
            //[ width, depth, height ]
            var input = new List<int[]>()
            {
                new int[]{ 2, 1, 2 },
                new int[]{ 3, 2, 3 },
                new int[]{ 2, 2, 8 },
                new int[]{ 2, 3, 4 },
                new int[]{ 1, 3, 1 },
                new int[]{ 4, 4, 5 } 
            };

            var expected = new List<int[]>()
            {
                new int[]{ 2, 1, 2 },
                new int[]{ 3, 2, 3 },
                new int[]{ 4, 4, 5 }
            };

            // Sorted by height
            // [1, 3, 1] 
            // [2, 1, 2] x
            // [3, 2, 3] x
            // [2, 3, 4]
            // [4, 4, 5] x
            // [2, 2, 8]

            CollectionAssert.AreEqual(expected, DiskStacking(input));
        }

        public static List<int[]> DiskStacking(List<int[]> disks)
        { 
            var indexes = new int[disks.Count];
            Array.Fill(indexes, -1);
            var sortedDisks = disks.OrderBy(x => x[2]).ToList();
            var maxTowerHeights = sortedDisks.Select(x => x[2]).ToList();
            int maxTowerIndex = sortedDisks.Count - 1;

            for (int i = 1; i < sortedDisks.Count; i++)
            {
                var currentDisk = sortedDisks[i];
                for (int j = 0; j < i; j++)
                {
                    var previousDisk = sortedDisks[j];
                    bool isPreviousDiskSmaller = true;

                    for (int a = 0; a < 3; a++) // 3 dimensions
                        isPreviousDiskSmaller = isPreviousDiskSmaller && (previousDisk[a] < currentDisk[a]);
                    
                    if (isPreviousDiskSmaller)
                    {
                        int currentTowerHeight = currentDisk[2];
                        int potentialTowerHeight = currentTowerHeight + maxTowerHeights[j];
                        if (potentialTowerHeight > maxTowerHeights[i])
                        {
                            indexes[i] = j;
                            maxTowerHeights[i] = potentialTowerHeight;
                            maxTowerIndex = potentialTowerHeight > maxTowerHeights[maxTowerIndex] ? i : maxTowerIndex; 
                        }
                    }
                }
            }

            var result = new LinkedList<int[]>();

            while (maxTowerIndex >= 0)
            {
                result.AddFirst(sortedDisks[maxTowerIndex]);
                maxTowerIndex = indexes[maxTowerIndex];
            }

            return result.ToList();
        }
    }
}

