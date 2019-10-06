using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    [TestFixture]
    class Recursion_NthFibonacci
    {
        public Dictionary<int,int> Mem { get; set; }

        [SetUp]
        public void Clean()
        {
            Mem = new Dictionary<int, int>();
        }

        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 2)]
        [TestCase(5, ExpectedResult = 3)]
        [TestCase(6, ExpectedResult = 5)]
        // Time  O (2^n)
        // Space O (n)
        public static int GetNthFib(int n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;

            return GetNthFib(n - 1) + GetNthFib(n - 2);
        }

        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 2)]
        [TestCase(5, ExpectedResult = 3)]
        [TestCase(6, ExpectedResult = 5)]
        // Time  O (n)
        // Space O (n)
        public int GetNthFibV2(int n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;
            if (Mem.ContainsKey(n)) return Mem[n];
            
            Mem[n] = GetNthFibV2(n - 1) + GetNthFibV2(n - 2);
            return Mem[n];
        }

        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 2)]
        [TestCase(5, ExpectedResult = 3)]
        [TestCase(6, ExpectedResult = 5)]
        // Time  O (n)
        // Space O (n)
        public int GetNthFibV3(int n)
        {
            int Fib(int nb, Dictionary<int, int> memo)
            {
                if (memo.ContainsKey(nb))
                    return memo[nb];
                memo[nb] = Fib(nb - 1, memo) + Fib(nb - 2, memo);
                return memo[nb];
            }
            var m = new Dictionary<int, int>();
            m[1] = 0;
            m[2] = 1;

            return Fib(n, m);
        }
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 2)]
        [TestCase(5, ExpectedResult = 3)]
        [TestCase(6, ExpectedResult = 5)]
        // Time  O (n)
        // Space O (1)
        public int GetNthFibV4(int n)
        {
            var tup = (0, 1);

            for (int i = 2; i < n; i++)
                tup = (tup.Item2, tup.Item1 + tup.Item2);

            return n > 1 ? tup.Item2 : tup.Item1;
        }
    }    
}
