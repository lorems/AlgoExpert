using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

// River = 1
// Land = 0
// Calculate adjacent rivers

namespace Questions.Medium
{
    [TestFixture]
    class Graphs_RiverSizes
    {
        [Test]
        public void DoTest()
        {
            var matrix = new int[,] {
                { 1, 0, 0, 1, 0 },
                { 1, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 0 }
            };
            var expectedResult = new List<int> { 1, 2, 2, 2, 5 };
            var actual = RiverSizes(matrix);

            CollectionAssert.AreEquivalent(expectedResult, actual);
        }
        [Test]
        public void DoTest2()
        {
            var matrix = new int[,] {
                { 1, 0 },
                { 1, 0 },
                { 0, 0 },
                { 1, 0 },
                { 1, 1 }
            };
            var expectedResult = new List<int> { 2, 3 };
            var actual = RiverSizes(matrix);

            CollectionAssert.AreEquivalent(expectedResult, actual);
        }
        [Test]
        public void DoTest3()
        {
            var matrix = new int[,] { { 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0 } };
            var expectedResult = new List<int> { 1, 2, 3 };
            var actual = RiverSizes(matrix);

            CollectionAssert.AreEquivalent(expectedResult, actual);
        }
        [Test]
        public void DoTest4()
        {
            var matrix = new int[,] {
                {1, 1, 0},
                {1, 0, 1},
                {1, 1, 1},
                {1, 1, 0},
                {1, 0, 1},
                {0, 1, 0},
                {1, 0, 0},
                {1, 0, 0},
                {0, 0, 0},
                {1, 0, 0},
                {1, 0, 1},
                {1, 1, 1},
            };
            var expectedResult = new List<int> { 1, 1, 2, 6, 10 };
            var actual = RiverSizes(matrix);

            CollectionAssert.AreEquivalent(expectedResult, actual);
        }
        
        public static List<int> RiverSizes(int[,] matrix)
        {
            var visited = new HashSet<Point>();
            var result = new List<int>();
            int matrixLength = matrix.GetLength(1);
            int matrixHeight = matrix.GetLength(0);
            Predicate<Point> IsRiver = delegate (Point p) { return matrix[p.Y, p.X] == 1; };

            for (int y = 0; y < matrixHeight; y++)
            {
                for (int x = 0; x < matrixLength; x++)
                {
                    var p = new Point(x, y);
                    
                    if (!visited.Contains(p))
                    {
                        if (IsRiver(p))
                            result.Add(GetRiverSize(p, matrix, visited));
                    }
                    else
                    {
                        visited.Add(p);
                    }
                }
            }

            return result;
        }

        public static int GetRiverSize(Point _p, int[,] matrix, HashSet<Point> visited)
        {
            var queue = new Queue<Point>();
            queue.Enqueue(_p);
            int size = 0;
            int matrixLength = matrix.GetLength(1);
            int matrixHeight = matrix.GetLength(0);
            Predicate<Point> IsRiver = delegate (Point p) { return matrix[p.Y, p.X] == 1; };

            while (queue.Any())
            {
                var p = queue.Dequeue();

                if (visited.Contains(p))
                    continue;

                ++size;
                var top = new Point(p.X, p.Y - 1);
                var right = new Point(p.X + 1, p.Y);
                var bottom = new Point(p.X, p.Y + 1);
                var left = new Point(p.X - 1, p.Y);
                
                if (top.Y >= 0 && !visited.Contains(top) && IsRiver(top))
                    queue.Enqueue(top);
                if (right.X < matrixLength && !visited.Contains(right) && IsRiver(right))
                    queue.Enqueue(right);
                if (bottom.Y < matrixHeight && !visited.Contains(bottom) && IsRiver(bottom))
                    queue.Enqueue(bottom);
                if (left.X >= 0 && !visited.Contains(left) && IsRiver(left))
                    queue.Enqueue(left);

                visited.Add(p);
            }

            return size;
        }
    }
}
