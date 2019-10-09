using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    [TestFixture]
    class Strings_PalindromeCheck
    {
        [TestCase("abcdcba", ExpectedResult = true)]
        [TestCase("aa", ExpectedResult = true)]
        [TestCase("aaa", ExpectedResult = true)]
        [TestCase("ab", ExpectedResult = false)]
        [TestCase("rrt", ExpectedResult = false)]
        [TestCase("a", ExpectedResult = true)]
        // Time O(n)
        // Space O(1)
        public static bool IsPalindrome(string str)
        {
            int left = 0;
            int right = str.Length -1;

            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                ++left;
                --right;
            }

            return true;
        }
        // Time O(n^2) string | O(n) StringBuilder
        [TestCase("abcdcba", ExpectedResult = true)]
        [TestCase("aa", ExpectedResult = true)]
        [TestCase("aaa", ExpectedResult = true)]
        [TestCase("ab", ExpectedResult = false)]
        [TestCase("rrt", ExpectedResult = false)]
        [TestCase("a", ExpectedResult = true)]
        public static bool IsPalindromeReverse(string str)
        {
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
            {
                str2 = str[i] + str2;
            }
            return str == str2;
        }
        [TestCase("abcdcba", ExpectedResult = true)]
        [TestCase("aa", ExpectedResult = true)]
        [TestCase("aaa", ExpectedResult = true)]
        [TestCase("ab", ExpectedResult = false)]
        [TestCase("rrt", ExpectedResult = false)]
        [TestCase("a", ExpectedResult = true)]
        // Time O(n)
        // Space O(n)
        public static bool IsPalindromeRecursif(string str)
        {
            bool IsPal(int right, int left, string strPal)
            {
                if (right > left) return true;

                return strPal[right] == strPal[left] && IsPal(++right, --left, strPal);

                //if (strPal[right] != strPal[left])
                //    return false;

                //return IsPal(++right, --left, strPal);
            }
            return IsPal(0, str.Length - 1, str);
        }
        [TestCase("abcdcba", ExpectedResult = true)]
        [TestCase("aa", ExpectedResult = true)]
        [TestCase("aaa", ExpectedResult = true)]
        [TestCase("ab", ExpectedResult = false)]
        [TestCase("rrt", ExpectedResult = false)]
        [TestCase("a", ExpectedResult = true)]
        public static bool IsPalindromeRecursifV2(string str)
        {
            bool IsPal(int left, string strPal)
            {
                int right = strPal.Length - 1 - left;
                return right < left ? true : strPal[left] == strPal[right] && IsPal(++left, strPal);
            }
            return IsPal(0, str);
        }
    }
}
