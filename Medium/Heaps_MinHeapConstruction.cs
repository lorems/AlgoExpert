using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Medium
{
    public class Heaps_MinHeapConstruction
    {
        [TestFixture]
        public class TestClass
        {
            [Test]
            static public void InsertTest()
            {
                var starterHeap = new List<int> { 8, 12, 23, 17, 31, 30, 44, 102, 18 };
                var expectedHeap = new List<int> { 8, 9, 23, 17, 12, 30, 44, 102, 18, 31 };
                var heap = new MinHeap();
                heap.heap = starterHeap;
                heap.Insert(9);

                CollectionAssert.AreEqual(expectedHeap, heap.heap);
            }
            [Test]
            static public void RemoveTest()
            {
                var starterHeap = new List<int> { 8, 9, 23, 17, 12, 30, 44, 102, 18, 31 };
                var expectedHeap = new List<int> {9, 12, 23, 17, 31, 30, 44, 102, 18 };
                var heap = new MinHeap();
                heap.heap = starterHeap;
                int top = heap.Remove();

                Assert.That(heap.Peek(), Is.EqualTo(9));
                Assert.That(top, Is.EqualTo(8));
                CollectionAssert.AreEqual(expectedHeap, heap.heap);
            }

            [Test]
            static public void BuildTest()
            {
                var starterHeap = new List<int> { 48, 12, 24, 7, 8, -5, 24, 391, 24, 56, 2, 6, 8, 41 };
                var expectedHeap = new List<int> { -5, 2, 6, 7, 8, 8, 24, 391, 24, 56, 12, 24, 48, 41 };
                var heap = new MinHeap(starterHeap);

                CollectionAssert.AreEqual(expectedHeap, heap.heap);
            }
        }

        public class MinHeap
        {
            public List<int> heap = new List<int>();

            public MinHeap()
            {

            }

            public MinHeap(List<int> array)
            {
                heap = buildHeap(array);
            }

            public List<int> buildHeap(List<int> array)
            {
                //foreach (var v in array)
                //    Insert(v);

                int lastParentIdx = ((array.Count - 1) - 1) / 2; // floor
                for (int i = lastParentIdx; i >= 0; i--)
                {
                    siftDown(i, array.Count - 1, array);
                }

                return array;
            }

            public void siftDown(int currentIdx, int endIdx, List<int> heap)
            {
                int childIdx1 = 2 * currentIdx + 1;
                int childIdx2 = childIdx1 + 1;

                if (childIdx1 > endIdx)
                    return;

                int smallestChildIdx = 0;

                if (childIdx2 > endIdx)
                    smallestChildIdx = childIdx1;
                else
                    smallestChildIdx = heap[childIdx2] < heap[childIdx1] ? childIdx2 : childIdx1;

                if (heap[currentIdx] > heap[smallestChildIdx])
                {
                    Swap(currentIdx, smallestChildIdx, heap);
                    siftDown(smallestChildIdx, endIdx, heap);
                }
            }

            public void siftUp(int currentIdx, List<int> heap)
            {
                if (currentIdx == 0)
                    return;

                int parentIdx = (currentIdx - 1) / 2; // Result is floor

                if (heap[parentIdx] > heap[currentIdx])
                {
                    Swap(currentIdx, parentIdx, heap);
                    siftUp(parentIdx, heap);
                }
            }

            public int Peek()
            {
                return heap[0];
            }

            public int Remove()
            {
                int lastIndex = heap.Count - 1;
                int first = heap[0];
                heap[0] = heap[lastIndex];
                heap.RemoveAt(lastIndex);
                siftDown(0, heap.Count - 1, heap);

                return first;
            }

            public void Insert(int value)
            {
                heap.Add(value);
                siftUp(heap.Count - 1, heap);
            }

            public void Swap(int idx1, int idx2, List<int> heap)
            {
                int temp = heap[idx1];
                heap[idx1] = heap[idx2];
                heap[idx2] = temp;
            }
        }
    }
}
