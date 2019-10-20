using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

// Suffix Trie Construction

// Write a class for a suffix-trie-like data structure.

// string: babc

//        O
//     /  |  \
//     b  a  c
//   / |  |  |
//   c a  b  *
//   | |  |
//   * b  c
//     |  |
//     c  *
//     |
//     *

namespace Questions.Medium
{
    [TestFixture]
    class Tries_SuffixTrie
    {
        [Test]
        public static void DoTest()
        {
            var tree = new SuffixTrie("babc");
            Assert.That(tree.Contains("bc"), Is.EqualTo(true));
        }

        [Test]
        public static void DoTest2()
        {
            var tree = new SuffixTrie("bab");
            Assert.That(tree.Contains("bb"), Is.EqualTo(false));
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        }

        public class SuffixTrie
        {
            public TrieNode root = new TrieNode();
            char endSymbol = '*';

            public SuffixTrie(string str)
            {
                PopulateSuffixTrieFrom(str);
            }

            // T: O(n^2) S: O(n^2)
            public void PopulateSuffixTrieFrom(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    var lastNode = root;

                    for (int j = i; j < str.Length; j++)
                    {
                        if (!lastNode.Children.ContainsKey(str[j]))
                            lastNode.Children.Add(str[j], new TrieNode());

                        lastNode = lastNode.Children[str[j]];
                    }

                    lastNode.Children.Add(endSymbol, new TrieNode());
                }
            }

            // T: O(m) S: O(1) => m is the length of input string
            public bool Contains(string str)
            {
                var lastNode = root;

                foreach (var c in str)
                {
                    if (lastNode.Children.ContainsKey(c))
                        lastNode = root.Children[c];
                    else
                        return false;
                }

                return lastNode.Children.ContainsKey(endSymbol);
            }
        }
    }
}
