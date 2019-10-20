using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class Stacks_BalancedBrackets
    {
        [TestCase("([])(){}(())()()", ExpectedResult = true)]
        [TestCase("", ExpectedResult = true)]
        [TestCase("))", ExpectedResult = false)]
        public static bool BalancedBrackets(string str)
        {
            var brackets = new Dictionary<char, char>();
            brackets.Add(')', '(');
            brackets.Add(']', '[');
            brackets.Add('}', '{');

            var stack = new Stack<char>();

            foreach (var c in str)
            {
                if (brackets.ContainsKey(c))
                {
                    if (stack.Count > 0 && stack.Peek() == brackets[c])
                        stack.Pop();
                    else
                        return false;
                }
                else
                {
                    stack.Push(c);
                }                
            }
            return stack.Count == 0;
        }
    }
}
