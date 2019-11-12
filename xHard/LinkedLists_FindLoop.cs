using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.xHard
{
    [TestFixture]
    class LinkedLists_FindLoop
    {
        [Test]
        public static void DoTest()
        {
            // Input:
            //
            // 1 -> 2 -> 3 -> 4
            //      ^         v
            //      7 <- 6 <- 5

            // Output: 2

            var n1 = new LinkedList(1);
            var n2 = new LinkedList(2);
            var n3 = new LinkedList(3);
            var n4 = new LinkedList(4);
            var n5 = new LinkedList(5);
            var n6 = new LinkedList(6);
            var n7 = new LinkedList(7);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n7;
            n7.next = n2;

            Assert.That(FindLoop(n1).value, Is.EqualTo(2));
        }
        // T: O(n) S: O(1)
        public static LinkedList FindLoop(LinkedList head)
        {
            var p1 = head.next.next;
            var p2 = p1.next.next;

            while (p1.value != p2.value)
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }

            p1 = head;

            while (p1.value != p2.value)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p1;
        }

        public class LinkedList
        {
            public int value;
            public LinkedList next = null;

            public LinkedList(int value)
            {
                this.value = value;
            }
        }
    }
}
