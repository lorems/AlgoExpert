using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    [TestFixture]
    class LinkedLists_RemoveKthNodeFromEnd
    {
        [Test]
        public static void DoTest()
        {
            var head = new LinkedList(0);
            head.Add(1).Add(2).Add(3).Add(4).Add(5).Add(6).Add(7).Add(8).Add(9);
            RemoveKthNodeFromEnd(head, 4);

            int expected = head.Next.Next.Next.Next.Next.Next.Value;

            Assert.That(expected, Is.EqualTo(7));

            //RemoveKthNodeFromEnd(head, 99);
            //Assert.That(head.Next.Value, Is.EqualTo(1));

            RemoveKthNodeFromEnd(head, 9);

            Assert.That(head.Value, Is.EqualTo(1));
            Assert.That(head.Next.Value, Is.EqualTo(2));
        }

        public static void RemoveKthNodeFromEnd(LinkedList head, int k)
        {
            var left = head;
            var right = head;
            int idx = 1;

            while (idx <= k)
            {
                right = right.Next;
                ++idx;
            }

            if (right == null)
            {
                head.Value = head.Next.Value;
                head.Next = head.Next.Next;
                return;
            }                

            while (right.Next != null)
            {
                right = right.Next;
                left = left.Next;
            }

            left.Next = left.Next.Next;
        }

        public class LinkedList
        {
            public int Value;
            public LinkedList Next = null;

            public LinkedList(int value)
            {
                this.Value = value;
            }

            public LinkedList Add(int val)
            {
                var node = new LinkedList(val);
                Next = node;

                return node;
            }
        }
    }
}
