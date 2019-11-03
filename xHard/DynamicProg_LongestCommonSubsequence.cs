using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.xHard
{
    class DynamicProg_LongestCommonSubsequence
    {
        [Test]
        public void DoTest()
        {
            string input1 = "ZXVVYZW";
            string input2 = "XKYKZPW";

            var expected = new List<char>{ 'X', 'Y', 'Z', 'W' };

            CollectionAssert.AreEqual(expected, LongestCommonSubsequence(input2, input1));
        }

        [Test]
        public void DoTest2()
        {
            string input1 = "abc";
            string input2 = "ab";

            var expected = new List<char> { 'a', 'b' };

            CollectionAssert.AreEqual(expected, LongestCommonSubsequence(input1, input2));
        }

        [Test]
        public void DoTest3()
        {
            string input1 = "ab";
            string input2 = "abc";

            var expected = new List<char> { 'a', 'b' };

            CollectionAssert.AreEqual(expected, LongestCommonSubsequence(input1, input2));
        }
        // T: O(nm * min(n,m)) S: O(nm * min(n,m))
        public static List<char> LongestCommonSubsequence(string strCol, string strRow)
        {
            strCol = "@" + strCol;
            strRow = "@" + strRow;
            var matrix = new string[strCol.Length, strRow.Length];

            for (int y = 0; y < strRow.Length; y++)
                matrix[0, y] = "";

            for (int x = 0; x < strCol.Length; x++)
                matrix[x, 0] = "";

            for (int y = 1; y < strRow.Length; y++)
            {
                for (int x = 1; x < strCol.Length; x++)
                {
                    if (strCol[x] == strRow[y])
                        matrix[x,y] = matrix[x-1,y-1] + strRow[y];
                    else
                        matrix[x, y] = matrix[x - 1, y].Length > matrix[x, y - 1].Length ? matrix[x - 1, y] : matrix[x, y - 1];
                }
            }
            return matrix[strCol.Length - 1, strRow.Length - 1].ToList();
        }
    }
}
