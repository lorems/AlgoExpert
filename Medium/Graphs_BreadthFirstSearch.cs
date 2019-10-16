using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Medium
{
    class Graphs_BreadthFirstSearch
    {
        [TestFixture]
        public class Tests
        {
            [Test]
            public void DoTest()
            {
                var tree = new Node("1").AddChild("2").AddChild("3");
                CollectionAssert.AreEqual(tree.BreadthFirstSearch(new List<string>()), new List<string>() { "1", "2", "3" });
                var level2 = new Node("4").AddChild("5").AddChild("6");
                tree.AddChild(level2);
                CollectionAssert.AreEqual(tree.BreadthFirstSearch(new List<string>()), new List<string>() { "1", "2", "3", "4", "5", "6" });

            }
        }

        // Do not edit the class below except
        // for the BreadthFirstSearch method.
        // Feel free to add new properties
        // and methods to the class.
        public class Node
        {
            string name;
            public List<Node> children = new List<Node>();

            public Node(string name)
            {
                this.name = name;
            }

            public List<string> BreadthFirstSearch(List<string> array)
            {
                var pseudoQueue = new List<Node>();
                pseudoQueue.Add(this);
                int i = 0;

                while (pseudoQueue.Count > i)
                {
                    var node = pseudoQueue[i];
                    array.Add(node.name);
                    pseudoQueue.AddRange(node.children);
                    ++i;
                }

                return array;
            }

            public Node AddChild(string name)
            {
                Node child = new Node(name);
                children.Add(child);
                return this;
            }
            public Node AddChild(Node child)
            {
                children.Add(child);
                return this;
            }
        }
    }
}
