using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// Traverse 2d array with in a zigzag pattern.

namespace Questions.xHard
{
    [TestFixture]
    class Arrays_ZigzagTraverse
    {
        [Test]
        public void DoTest()
        {
            var input = new List<List<int>>();
            input.Add(new List<int> { 1, 3, 4, 10 });
            input.Add(new List<int> { 2, 5, 9, 11 });
            input.Add(new List<int> { 6, 8, 12, 15 });
            input.Add(new List<int> { 7, 13, 14, 16 });

            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var actual = ZigzagTraverse(input);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DoTest2()
        {
            var input = new List<List<int>>();
            input.Add(new List<int> { 1, 2, 3 });
            input.Add(new List<int> { 4, 5, 6 });
            input.Add(new List<int> { 7, 8, 9 });

            var expected = new List<int> { 1, 4, 2, 3, 5, 7, 8, 6, 9 };
            var actual = ZigzagTraverse(input);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DoTest3()
        {
            var input = new List<List<int>>();
            input.Add(new List<int> { 1, 2, 3 });
            input.Add(new List<int> { 4, 5, 6 });

            var expected = new List<int> { 1, 4, 2, 3, 5, 6 };
            var actual = ZigzagTraverse(input);
            CollectionAssert.AreEqual(expected, actual);
        }

        public static List<int> ZigzagTraverse(List<List<int>> array)
        {
            int x = 0;
            int y = 0;
            bool isDirectionUp = false;
            var result = new List<int>();
            int length = array[0].Count - 1;
            int height = array.Count - 1;

            result.Add(array[y][x]);

            while (x != length || y != height)
            {
                if (isDirectionUp)
                {
                    if (y != 0 && x != length)
                    {
                        ++x;
                        --y;
                    }
                    else if (x == length)
                    {
                        ++y;
                        isDirectionUp = false;
                    }
                    else
                    {
                        ++x;
                        isDirectionUp = false;                        
                    }
                }
                else
                {
                    if (x != 0 && y != height)
                    {
                        --x;
                        ++y;
                    }
                    else if (y == height)
                    {
                        ++x;
                        isDirectionUp = true;
                    }
                    else
                    {
                        ++y;
                        isDirectionUp = true;
                    }
                }

                result.Add(array[y][x]);
            }

            return result;
        }
    }
}
