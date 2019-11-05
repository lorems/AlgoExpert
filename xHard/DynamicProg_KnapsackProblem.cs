using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// You are given an array of arrays.Each subarray in this array holds two
// integer values and represents an item; the first integer is the item's
// value, and the second integer is the item's weight. You are also given an
// integer representing the maximum capacity of a knapsack that you have.Your
// goal is to fit items in your knapsack, all the while maximizing their
// combined value. Note that the sum of the weights of the items that you pick
// cannot exceed the knapsack's capacity. Write a function that returns the
// maximized combined value of the items that you should pick, as well as an
// array of the indices of each item picked.Assume that there will only be one
// combination of items that maximizes the total value in the knapsack.




namespace Questions.xHard
{
    [TestFixture]
    class DynamicProg_KnapsackProblem
    {
        [Test]
        public void DoTest()
        {
            // inputKnapsackContent [[$$$, itemWeight] , [$$$, itemWeight]]
            var inputKnapsackContent = new int[4, 2] { { 1, 2 }, { 4, 3 }, { 5, 6 }, { 6, 7 } };
            int inputKnapsackMaxWeight = 10;

            int expectedTotalValue = 10;
            var expectedItemIndex = new List<int> { 1, 3 };
            var expected = new List<List<int>> { new List<int> { expectedTotalValue }, expectedItemIndex };

            Assert.That(KnapsackProblem(inputKnapsackContent, inputKnapsackMaxWeight), Is.EqualTo(expected));
        }

        [Test]
        public void DoTest2()
        {
            // inputKnapsackContent [[$$$, itemWeight] , [$$$, itemWeight]]
            var inputKnapsackContent = new int[,] { { 2, 1 }, { 70, 70 }, { 30, 30 }, { 69, 69 }, { 88, 99 } };
            int inputKnapsackMaxWeight = 100;

            int expectedTotalValue = 101;
            var expectedItemIndex = new List<int> { 0, 2, 3 };
            var expected = new List<List<int>> { new List<int> { expectedTotalValue }, expectedItemIndex };

            Assert.That(KnapsackProblem(inputKnapsackContent, inputKnapsackMaxWeight), Is.EqualTo(expected));
        }

        public static List<List<int>> KnapsackProblem(int[,] _items, int capacity)
        {
            var items = new int[_items.GetLength(0) + 1, _items.GetLength(1)];
            items[0, 0] = 0;
            items[0, 1] = 0;
            Array.Copy(_items, 0, items, 2, _items.Length);
            var matrix = new int[capacity + 1, items.GetLength(0)];

            for (int y = 1; y < matrix.GetLength(1); y++)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    var currentKnapsackWeights = x;
                    int itemValue = items[y, 0];
                    int itemWeight = items[y, 1];
                    int weightDiff = currentKnapsackWeights - itemWeight;

                    if (itemWeight > currentKnapsackWeights)
                        matrix[x, y] = matrix[x, y - 1];
                    else
                        matrix[x, y] = Math.Max(matrix[x, y - 1], itemValue + matrix[weightDiff, y - 1]);
                }
            }
            
            var result = new List<List<int>>();
            int totalValue = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            result.Add(new List<int> { totalValue });
            result.Add(GetItemIndexes(matrix, items));

            return result;
        }

        public static List<int> GetItemIndexes(int[,] matrix, int[,] items)
        {
            var indexes = new LinkedList<int>();
            int x = matrix.GetLength(0) - 1;
            int y = matrix.GetLength(1) - 1;

            while(x > 0 && y > 0)
            {
                var currentValue = matrix[x, y];
                var topValue = matrix[x, y - 1];

                if (currentValue != topValue)
                {
                    indexes.AddFirst(y - 1);
                    int itemWeight = items[y, 1];
                    int targetWeight = x - itemWeight;
                    x = targetWeight;
                }

                --y;
            }

            return indexes.ToList();
        }
    }
}

//         0 1 2 3 4 5 6 7 8 9 10
//         
// [ , ]   0 0 0 0 0 0 0 0 0 0 0
// [1,2]   0 0 1 1 1 1 1 1 1 1 1
// [4,3]   0 0 1 4 4 5 5 5 5 5 5
// [5,6]   0 0 1 4 4 5 5 5 6 9 9
// [6,7]   0 0 1 4 4 5 5 6 6 9 10