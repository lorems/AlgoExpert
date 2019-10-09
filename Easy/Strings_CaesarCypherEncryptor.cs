using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    [TestFixture]
    class Strings_CaesarCypherEncryptor
    {
        [TestCase("xyz", 2, ExpectedResult = "zab")]
        [TestCase("xyz", 28, ExpectedResult = "zab")]
        public static string CaesarCypherEncryptor(string str, int key)
        {
            string result = string.Empty;
            key %= 26;

            for (int i = 0; i < str.Length; i++)
            {
                var charInt = (int)str[i];
                for (int j = 0; j < key; j++)
                {
                    if (charInt == (int)'z')
                        charInt = (int)'a';
                    else
                        ++charInt;
                }
                result += (char)charInt;
            }

            return result;
        }

        [TestCase("xyz", 2, ExpectedResult = "zab")]
        [TestCase("xyz", 28, ExpectedResult = "zab")]
        // Time:  O(n) char array
        // Space: O(n) char array
        public static string CaesarCypherEncryptorV2(string str, int key)
        {
            string result = string.Empty;
            key %= 26;

            for (int i = 0; i < str.Length; i++)
            {
                int newChar = str[i] + key;
                //result += newChar <= 'z' ? (char)newChar : (char)(('a'-1) + newChar % 'z');
                result += newChar <= 'z' ? (char)newChar : (char)(newChar - 'z' + 'a' - 1);
            }

            return result;
        }
    }
}
