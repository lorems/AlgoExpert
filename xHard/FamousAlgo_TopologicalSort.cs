using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// You are given a list of arbitrary jobs that need to be completed; these jobs
// are represented by integers. You are also given a list of dependencies. A
// dependency is represented as a pair of jobs where the first job is
// prerequisite of the second one. In other words, the second job depends on
// the first one; it can only be completed once the first job is completed.
// Write a function that takes in a list of jobs and a list of dependencies and
// returns a list containing a valid order in which the given jobs can be
// completed. If no such order exists, the function should return an empty
// list.

namespace Questions.xHard
{
    class FamousAlgo_TopologicalSort
    {
        [Test]
        public static void DoTest()
        {
            var inputJobs = new List<int> { 1, 2, 3, 4 };

            var inputDepedencies = new List<int[]>
            {
                new int[]{ 1, 2 },
                new int[]{ 1, 3 },
                new int[]{ 3, 2 },
                new int[]{ 4, 2 },
                new int[]{ 4, 3 },
                new int[]{ 1, 4 }
            };

            var expected = new List<int> { 1, 4, 3, 2 };

            CollectionAssert.AreEqual(expected, TopologicalSortV1(inputJobs, inputDepedencies));
            CollectionAssert.AreEqual(expected, TopologicalSortV2(inputJobs, inputDepedencies));
            CollectionAssert.AreEqual(expected, TopologicalSortV3(inputJobs, inputDepedencies));
        }
        [Test]
        public static void DoTest2()
        {
            var inputJobs = new List<int> { 1, 2, 3, 4 };

            var inputDepedencies = new List<int[]>
            {
                new int[]{ 1, 2 },
                new int[]{ 1, 3 },
                new int[]{ 3, 2 },
                new int[]{ 4, 2 },
                new int[]{ 4, 3 },
                new int[]{ 2, 1 }
            };

            var expected = new List<int> {  };

            CollectionAssert.AreEqual(expected, TopologicalSortV1(inputJobs, inputDepedencies));
            CollectionAssert.AreEqual(expected, TopologicalSortV2(inputJobs, inputDepedencies));
            CollectionAssert.AreEqual(expected, TopologicalSortV3(inputJobs, inputDepedencies));
        }
        public class Node
        {
            public int Value { get; set; }
            public bool Visited { get; set; }
            public bool Pending { get; set; }
            public List<Node> Depedencies { get; set; }

            public Node(int value)
            {
                Value = value;
                Depedencies = new List<Node>();
            }
        }

        // S: O(v+e) S: O(v+e) where j is job(vertices) and d is depedencies (edges) | aka: depth first search
        public static List<int> TopologicalSortV1(List<int> jobs, List<int[]> deps)
        {
            var orderdJobs = new List<int>();
            var jobDic = jobs.ToDictionary(v => v, v => new Node(v));
            deps.ForEach(d => jobDic[d[1]].Depedencies.Add(jobDic[d[0]]));

            foreach (var j in jobDic.Values)
            {
                bool isConflict = Traverse(j, orderdJobs);

                if (isConflict)
                    return new List<int> { };
            }
            return orderdJobs;
        }

        public static bool Traverse(Node node, List<int> orderdJobs)
        {
            if (node.Pending) return true;
            if (node.Visited) return false;

            node.Visited = true;
            node.Pending = true;

            foreach (var n in node.Depedencies)
            {
                if (Traverse(n, orderdJobs))
                    return true;
            }

            orderdJobs.Add(node.Value);
            node.Pending = false;

            return false;
        }

        public static List<int> TopologicalSortV2(List<int> jobs, List<int[]> deps)
        {
            var orderdJobs = new List<int>();
            var jobDic = jobs.ToDictionary(v => v, v => new NodeV2(v));
            deps.ForEach(d => jobDic[d[0]].Childs.Add(jobDic[d[1]]));
            deps.ForEach(d => jobDic[d[1]].Parents.Add(jobDic[d[0]]));
            var noParents = jobDic.Values.ToList().Where(n => n.Parents.Count == 0).ToList();

            while (noParents.Count > 0)
            {
                var node = noParents.Last();
                noParents.RemoveAt(noParents.Count - 1);
                orderdJobs.Add(node.Value);

                foreach (var child in node.Childs)
                {
                    child.Parents.Remove(node);
                    if (child.Parents.Count == 0)
                        noParents.Add(child);
                }
            }

            return orderdJobs.Count == jobs.Count ? orderdJobs : new List<int> { };
        }
        public class NodeV2
        {
            public int Value { get; set; }
            public HashSet<NodeV2> Parents { get; set; }
            public List<NodeV2> Childs { get; set; }

            public NodeV2(int value)
            {
                Value = value;
                Parents = new HashSet<NodeV2>();
                Childs = new List<NodeV2>();
            }
        }

        public static List<int> TopologicalSortV3(List<int> jobs, List<int[]> deps)
        {
            var orderdJobs = new List<int>();
            var jobDic = jobs.ToDictionary(v => v, v => new NodeV3(v));
            deps.ForEach(d => jobDic[d[0]].AddChild(jobDic[d[1]]));
            var noParents = jobDic.Values.ToList().Where(n => n.NbParents == 0).ToList();

            while (noParents.Count > 0)
            {
                var node = noParents.Last();
                noParents.RemoveAt(noParents.Count - 1);
                orderdJobs.Add(node.Value);

                foreach (var child in node.Childs)
                {
                    --child.NbParents;
                    if (child.NbParents == 0)
                        noParents.Add(child);
                }
            }

            return orderdJobs.Count == jobs.Count ? orderdJobs : new List<int> { };
        }
        public class NodeV3
        {
            public int Value { get; set; }
            public int NbParents { get; set; }
            public List<NodeV3> Childs { get; set; }

            public NodeV3(int value)
            {
                Value = value;
                Childs = new List<NodeV3>();
            }

            public void AddChild(NodeV3 child)
            {
                Childs.Add(child);
                ++child.NbParents;
            }
        }
    }
}
