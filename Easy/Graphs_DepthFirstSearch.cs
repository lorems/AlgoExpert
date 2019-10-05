using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Easy
{
    public class Graphs_DepthFirstSearch
    {
        [TestFixture]
        public class Node
        {
            string name;
            List<Node> children = new List<Node>();

            public Node(string name)
            {
                this.name = name;
            }

            public Node()
            {

            }

            [OneTimeSetUp]
            public void Init()
            {
                name = "F";
                AddChild("C");
                AddChild("Z");
                children[0].AddChild("L");
            }

            [Test]
            public void DoTest()
            {
                var result = DepthFirstSearchV2( new List<string>() );

                Assert.That(result[0], Is.EqualTo("F"));
                Assert.That(result[1], Is.EqualTo("C"));
                Assert.That(result[2], Is.EqualTo("L"));
                Assert.That(result[3], Is.EqualTo("Z"));
            }

            public List<string> DepthFirstSearchV2(List<string> array)
            {
                array.Add(this.name);

                foreach (var c in children)
                {
                    c.DepthFirstSearchV2(array);
                }
                return array;
            }

            public List<string> DepthFirstSearchV1(List<string> array)
            {
                return Search(this, new HashSet<Node>(), array);
            }

            List<string> Search(Node node, HashSet<Node> visited, List<string> array)
            {
                if (node is null || visited.Contains(node))
                    return array;

                array.Add(node.name);
                visited.Add(node);

                foreach (var c in node.children)
                {
                    Search(c, visited, array);
                }

                return array;
            }


            public Node AddChild(string name)
            {
                Node child = new Node(name);
                children.Add(child);
                return this;
            }
        }
    }
}
