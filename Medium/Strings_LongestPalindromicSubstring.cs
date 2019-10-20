using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    class Strings_LongestPalindromicSubstring
    {
        [TestCase("aba", ExpectedResult = "aba")]
        [TestCase("abaxyzzyxf", ExpectedResult = "xyzzyx")]
        // T: O(n^2) S: O(1)
        public static string LongestPalindromicSubstring(string str)
        {
            string result = "";            

            for (int i = 0; i < str.Length; i++)
            {
                int lengthOdd = IsOddPalindrom(i, str);
                int lengthEven = IsEvenPalindrom(i, str);

                int max = Math.Max(lengthOdd, lengthEven);

                if (max > result.Length)
                    result = str.Substring(i - max / 2, max);
            }

            return result;
        }

        public static int IsOddPalindrom(int idx, string str)
        {
            int left = idx - 1;
            int right = idx + 1;
            int length = 0;

            while (left >= 0 && right < str.Length
                && str[left] == str[right])
            {
                ++length;
                --left;
                ++right;
            }

            return length * 2 + 1;
        }

        public static int IsEvenPalindrom(int idx, string str)
        {
            int left = idx - 1;
            int right = idx;
            int length = 0;

            while (left >= 0 && right < str.Length
                && str[left] == str[right])
            {
                length += 2;
                --left;
                ++right;
            }

            return length;
        }

        [TestCase("aba", ExpectedResult = "aba")]
        [TestCase("abaxyzzyxf", ExpectedResult = "xyzzyx")]
        // T: O(n^2) S: O(1)
        public static string LongestPalindromicSubstringV2(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                int odd = GetPalindromLength(str, i - 1, i + 1);
                int even = GetPalindromLength(str, i - 1, i);

                int max = Math.Max(odd, even);

                if (max > result.Length)
                    result = str.Substring(i - max / 2, max);
            }

            return result;
        }

        public static int GetPalindromLength(string str, int left, int right)
        {
            // Odd palindrom start with a length of 1
            int length = right - left == 1 ? 0 : 1;

            while (left >= 0 && right < str.Length && str[left] == str[right])
            {
                length += 2;
                --left;
                ++right;
            }

            return length;
        }
    }
}
