using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

// You are given a two-dimensional array(matrix) of potentially unequal height
// and width containing letters; this matrix represents a boggle board. You are
// also given a list of words. Write a function that returns an array of all
// the words contained in the boggle board. A word is constructed in the boggle
// board by connecting adjacent (horizontally, vertically, or diagonally)
// letters, without using any single letter at a given position more than once;
// while words can of course have repeated letters, those repeated letters must
// come from different positions in the boggle board in order for the word to
// be contained in the board. Note that two or more words are allowed to
// overlap and use the same letters in the boggle board.

namespace Questions.xHard
{
    [TestFixture]
    class Graphs_BoggleBoard
    {
        [Test]
        public static void DoTest()
        {
            var inputBoard = new char[,] {
                {'t', 'h', 'i', 's', 'i', 's', 'a'},
                {'s', 'i', 'm', 'p', 'l', 'e', 'x'},
                {'b', 'x', 'x', 'x', 'x', 'e', 'b'},
                {'x', 'o', 'g', 'g', 'l', 'x', 'o'},
                {'x', 'x', 'x', 'D', 'T', 'r', 'a'},
                {'R', 'E', 'P', 'E', 'A', 'd', 'x'},
                {'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                {'N', 'O', 'T', 'R', 'E', '-', 'P'},
                {'x', 'x', 'D', 'E', 'T', 'A', 'E'},
            };

            var inputWords = new string[] {"this", "is", "not", "a", "simple", "boggle", "board", "test", "REPEATED", "NOTRE-PEATED"};
            var expected = new List<string> { "this", "is", "a", "simple", "boggle", "board", "NOTRE-PEATED"};
            var actual = BoggleBoard(inputBoard, inputWords);

            CollectionAssert.AreEquivalent(expected, actual);
        }
        [Test]
        public static void DoTest2()
        {
            var inputBoard = new char[,] {
                {'a', 'b'},
                {'c', 'd'},
            };

            var inputWords = new string[] { "abcd", "abdc", "acbd", "acdb", "adbc", "adcb", "abca" };
            var expected = new List<string> { "abcd", "abdc", "acbd", "acdb", "adbc", "adcb" };
            var actual = BoggleBoard(inputBoard, inputWords);

            CollectionAssert.AreEquivalent(expected, actual);
        }
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; }
            public string Word { get; set; }
            public TrieNode() => Children = new Dictionary<char, TrieNode>();
            public TrieNode Add(char c)
            {
                if (!Children.ContainsKey(c))
                    Children[c] = new TrieNode();

                return Children[c];
            }
            public bool HasNext(char c) => Children.ContainsKey(c);
            public TrieNode Next(char c) => Children[c];
            public bool IsLast() => Children.ContainsKey(Trie.EndSymbol);
            public string GetWord() => Children[Trie.EndSymbol].Word;
        }

        public class Trie
        {
            public TrieNode Root { get; set; }
            public static readonly char EndSymbol = '*';
            public Trie() => Root = new TrieNode();

            public static Trie Build(string[] words)
            {
                var trie = new Trie();
                var root = trie.Root;

                foreach (var word in words)
                {
                    var currentNode = root;
                    word.ToList().ForEach(c => currentNode = currentNode.Add(c));
                    currentNode = currentNode.Add(EndSymbol);
                    currentNode.Word = word; // (root) -> ('t') -> ('h') -> ('e') -> (('*') , ("the"))
                }
                return trie;
            }
        }
        // T: O(ws +nm*8^s) where w is num of words, s is the longest word, n is the width of the board, m is the height of the board.
        // S: O(nm + ws)
        public static List<string> BoggleBoard(char[,] board, string[] words)
        {
            var wordsFound = new HashSet<string>();
            var trieWords = Trie.Build(words);
            int boardHeight = board.GetLength(0);
            int boardLength = board.GetLength(1);
            var visitedBoard = new bool[boardHeight, boardLength];

            for (int y = 0; y < boardHeight; y++)
            {
                for (int x = 0; x < boardLength; x++)
                {
                    BfsSearch(new Point(x, y), board, visitedBoard, trieWords.Root, wordsFound);
                }
            }

            return wordsFound.ToList();
        }
        public static void BfsSearch(Point p, char[,] board, bool[,] visitedBoard, TrieNode previousLetter, HashSet<string> wordsFound)
        {
            var queue = new Queue<Point>();
            char letter = board[p.Y, p.X];

            if (previousLetter.HasNext(letter))
            {
                TrieNode nextLetter = previousLetter.Next(letter);
                visitedBoard[p.Y, p.X] = true;

                if (nextLetter.IsLast())
                    wordsFound.Add(nextLetter.GetWord());

                GetNeighbors(board, visitedBoard, p)
                    .ForEach(x => queue.Enqueue(x));

                while (queue.Any())
                {
                    Point neighbor = queue.Dequeue();

                    if (!visitedBoard[neighbor.Y, neighbor.X])
                        BfsSearch(neighbor, board, visitedBoard, nextLetter, wordsFound);
                }

                visitedBoard[p.Y, p.X] = false;
            }            
        }

        public static List<Point> GetNeighbors(char[,] board, bool[,] visitedBoard, Point p)
        {
            int boardHeight = board.GetLength(0);
            int boardLength = board.GetLength(1);
            var points = new List<Point>();
            int x = p.X;
            int y = p.Y;

            if (y != 0)                                         // N
                points.Add(new Point(x, y - 1));
            if (y != 0 && x != boardLength - 1)                 // N-E
                points.Add(new Point(x + 1, y - 1));
            if (x != boardLength - 1)                           // E
                points.Add(new Point(x + 1, y));
            if (x != boardLength - 1 && y != boardHeight - 1)   // S-E
                points.Add(new Point(x + 1, y + 1));
            if (y != boardHeight - 1)                           // S
                points.Add(new Point(x, y + 1));
            if (x != 0 && y != boardHeight - 1)                 // S-W
                points.Add(new Point(x - 1, y + 1));
            if (x != 0)                                         // W
                points.Add(new Point(x - 1, y));
            if (x != 0 && y != 0)                               // N-W
                points.Add(new Point(x - 1, y - 1));

            return points;
        }
    }
}
