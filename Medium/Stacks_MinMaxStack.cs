using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class Stacks_MinMaxStack
    {
        [Test]
        public static void DoTest()
        {
            var mms = new MinMaxStack();
            mms.Push(5);

            Assert.That(5, Is.EqualTo(mms.Peek()));
            Assert.That(5, Is.EqualTo(mms.GetMin()));
            Assert.That(5, Is.EqualTo(mms.GetMax()));

            mms.Push(99);

            Assert.That(99, Is.EqualTo(mms.Peek()));
            Assert.That(5, Is.EqualTo(mms.GetMin()));
            Assert.That(99, Is.EqualTo(mms.GetMax()));

            mms.Push(2);

            Assert.That(2, Is.EqualTo(mms.Peek()));
            Assert.That(2, Is.EqualTo(mms.GetMin()));
            Assert.That(99, Is.EqualTo(mms.GetMax()));

            int v = mms.Pop();

            Assert.That(2, Is.EqualTo(v));
            Assert.That(5, Is.EqualTo(mms.GetMin()));
            Assert.That(99, Is.EqualTo(mms.GetMax()));
        }

        public class MinMaxStack
        {
            /// <summary>
            /// Item1 : Value
            /// Item2 : Min
            /// Item3 : Max
            /// </summary>
            public List<Tuple<int,int,int>> Stack { get; set; }

            public MinMaxStack()
            {
                Stack = new List<Tuple<int, int, int>>();
            }

            public int Peek()
            {
                return Stack[Stack.Count - 1].Item1;
            }

            public int Pop()
            {
                int top = Peek();
                Stack.RemoveAt(Stack.Count - 1);
                return top;
            }

            public void Push(int number)
            {
                int min = Stack.Count == 0 || number < GetMin() ? number : GetMin();
                int max = Stack.Count == 0 || number > GetMax() ? number : GetMax();
                Stack.Add(new Tuple<int, int, int>(number, min, max));
            }

            public int GetMin()
            {
                return Stack[Stack.Count - 1].Item2;
            }

            public int GetMax()
            {
                return Stack[Stack.Count - 1].Item3;
            }
        }
    }
}
