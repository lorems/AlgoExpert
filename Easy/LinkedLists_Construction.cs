using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    public class LinkedLists_Construction
    {
        [TestFixture]
        public class DoublyLinkedList
        {
            public Node Head;
            public Node Tail;

            [SetUp]
            public void Clean()
            {
                this.Head = null;
                this.Tail = null;
            }

            [Test]
            public void TheTest1()
            {
                //init
                var n1 = new Node(1);
                setHead(n1);

                var n2 = new Node(2);
                InsertAfter(n1, n2);

                var n3 = new Node(3);
                InsertAfter(n2, n3);

                var n4 = new Node(4);
                InsertAfter(n3, n4);

                var n5 = new Node(5);
                InsertAfter(n4, n5);

                // init check
                var lst = new List<int> { 1, 2, 3, 4, 5 };
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

                // set 4 to head
                lst = new List<int> { 4, 1, 2, 3, 5 };
                setHead(this.Tail.Prev);
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

                // set 6 to tail
                SetTail(new Node(6));
                lst = new List<int> { 4, 1, 2, 3, 5, 6 };
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

                // insert 3 before 6
                InsertBefore(this.Tail, this.Tail.Prev.Prev);
                lst = new List<int> { 4, 1, 2, 5, 3, 6 };
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

                // insert new 3 after 6
                InsertAfter(this.Tail, new Node(3));
                lst = new List<int> { 4, 1, 2, 5, 3, 6, 3 };
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

                // insert new 3 at position 1
                InsertAtPosition(1, new Node(3));
                lst = new List<int> { 3, 4, 1, 2, 5, 3, 6, 3 };
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

                // remove nodes with value 3
                RemoveNodesWithValue(3);
                lst = new List<int> { 4, 1, 2, 5, 6 };
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

                // remove node 2
                Remove(this.Head.Next.Next);
                lst = new List<int> { 4, 1, 5, 6 };
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

                // search for node 5
                ContainsNodeWithValue(5);
                lst = new List<int> { 4, 1, 5, 6 };
                CollectionAssert.AreEquivalent(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEquivalent(lst, ToReverseList());

            }

            [Test]
            public void TheTest2()
            {
                var first = new Node(1);
                var second = new Node(2);

                InsertAtPosition(99, first);
                InsertAtPosition(1, second);

                Assert.That(second, Is.EqualTo(this.Head));
                Assert.That(first, Is.EqualTo(this.Tail));
            }

            [Test]
            public void TheTest3()
            {
                InsertAtPosition(1, new Node(1));
                InsertAtPosition(2, new Node(2));

                var lst = new List<int> { 1, 2 };
                CollectionAssert.AreEqual(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEqual(lst, ToReverseList());
            }

            [Test]
            public void TheTest4()
            {
                var first = new Node(1);
                var second = new Node(2);
                var third = new Node(3);

                InsertAtPosition(1, first);
                InsertAtPosition(2, second);
                InsertAtPosition(2, third);

                var lst = new List<int> { 1, 3, 2 };
                CollectionAssert.AreEqual(lst, ToList());
                lst.Reverse();
                CollectionAssert.AreEqual(lst, ToReverseList());
            }

            public List<int> ToList()
            {
                var list = new List<int>();
                var node = this.Head;

                list.Add(node.Value);
                while (node.Next != null)
                {
                    list.Add(node.Next.Value);
                    node = node.Next;
                }
                return list;
            }

            public List<int> ToReverseList()
            {
                var list = new List<int>();
                var node = this.Tail;

                list.Add(node.Value);
                while (node.Prev != null)
                {
                    list.Add(node.Prev.Value);
                    node = node.Prev;
                }
                return list;
            }

            public void LinkTwo(Node leftNode, Node rightNode)
            {
                if (leftNode != null)
                    leftNode.Next = rightNode;
                if (rightNode != null)
                    rightNode.Prev = leftNode;
            }

            public void setHead(Node node)
            {
                Remove(node);
                if (this.Head == null)
                {
                    this.Head = node;
                    this.Tail = node;
                }                    
                else
                {
                    InsertBefore(this.Head, node);
                    this.Head = node;
                    this.Head.Prev = null;
                }
            }

            public void SetTail(Node node)
            {
                Remove(node);
                if (this.Tail == null)
                {
                    this.Tail = node;
                    this.Head = node;
                }
                else
                {
                    InsertAfter(this.Tail, node);
                    this.Tail = node;
                    this.Tail.Next = null;
                }
            }

            public void InsertBefore(Node node, Node nodeToInsert)
            {
                Remove(nodeToInsert);
                var temp = node.Prev;
                LinkTwo(nodeToInsert, node);
                LinkTwo(temp, nodeToInsert);

                if (nodeToInsert.Prev == null)
                    this.Head = nodeToInsert;
            }

            public void InsertAfter(Node node, Node nodeToInsert)
            {
                Remove(nodeToInsert);
                var temp = node.Next;
                LinkTwo(node, nodeToInsert);
                LinkTwo(nodeToInsert, temp);

                if (nodeToInsert.Next == null)
                    this.Tail = nodeToInsert;
            }

            public void InsertAtPosition(int position, Node nodeToInsert)
            {
                --position;
                Remove(nodeToInsert);

                if (this.Head == null || position == 0)
                {
                    setHead(nodeToInsert);
                    return;
                }

                int i = 1;
                Node curr = this.Head;

                while (curr.Next != null && i < position)
                {
                    curr = curr.Next;
                    i++;
                }

                InsertAfter(curr, nodeToInsert);
            }

            public void RemoveNodesWithValue(int value)
            {
                var curr = this.Head;

                while (curr != null)
                {
                    if (curr.Value == value)
                    {
                        Remove(curr);
                        RemoveNodesWithValue(value);
                    }

                    curr = curr.Next;
                }
            }

            public void Remove(Node node)
            {
                if (this.Head == node)
                    this.Head = this.Head.Next;
                if (this.Tail == node)
                    this.Tail = this.Tail.Prev;

                LinkTwo(node.Prev, node.Next);

                node.Next = null;
                node.Prev = null;
            }

            public bool ContainsNodeWithValue(int value)
            {
                var curr = this.Head;

                while (curr != null)
                {
                    if (curr.Value == value)
                        return true;

                    curr = curr.Next;
                }
                return false;
            }
        }

        // Do not edit the class below.
        public class Node
        {
            public int Value;
            public Node Prev;
            public Node Next;

            public Node(int value)
            {
                this.Value = value;
            }
        }
    }
}
