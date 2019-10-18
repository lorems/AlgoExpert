using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

//       A
//      / \
//     B   C
//    / \  /\
//    D  E F G
//   / \
//  H   I
namespace Questions.Medium
{
    [TestFixture]
    class Graphs_GetYoungestCommonAncestor
    {
        [Test]
        public void DoTest()
        {
            var top = new AncestralTree('A');
            var B = new AncestralTree('B');
            var C = new AncestralTree('C');
            top.AddAsAncestor(new AncestralTree[] { B, C });

            var D = new AncestralTree('D');
            var E = new AncestralTree('E');
            B.AddAsAncestor(new AncestralTree[] { D, E });

            var H = new AncestralTree('H');
            var I = new AncestralTree('I');
            D.AddAsAncestor(new AncestralTree[] { H, I });

            Assert.That(GetYoungestCommonAncestor(top, E, I).name, Is.EqualTo('B'));
            Assert.That(GetYoungestCommonAncestor(top, B, C).name, Is.EqualTo('A'));
            Assert.That(GetYoungestCommonAncestor(top, H, I).name, Is.EqualTo('D'));
        }

        [Test]
        public void DoTest2()
        {
            var top = new AncestralTree('A');
            var B = new AncestralTree('B');
            var C = new AncestralTree('C');
            top.AddAsAncestor(new AncestralTree[] { B, C });

            var D = new AncestralTree('D');
            var E = new AncestralTree('E');
            B.AddAsAncestor(new AncestralTree[] { D, E });

            var H = new AncestralTree('H');
            var I = new AncestralTree('I');
            D.AddAsAncestor(new AncestralTree[] { H, I });

            Assert.That(GetYoungestCommonAncestor(top, H, D).name, Is.EqualTo('D'));
        }
        [Test]
        public void DoTest3()
        {
            var top = new AncestralTree('A');
            var B = new AncestralTree('B');
            var C = new AncestralTree('C');
            top.AddAsAncestor(new AncestralTree[] { B, C });

            var D = new AncestralTree('D');
            var E = new AncestralTree('E');
            B.AddAsAncestor(new AncestralTree[] { D, E });

            var H = new AncestralTree('H');
            var I = new AncestralTree('I');
            D.AddAsAncestor(new AncestralTree[] { H, I });

            Assert.That(GetYoungestCommonAncestor(top, top, B).name, Is.EqualTo('A'));
        }

        public static AncestralTree GetYoungestCommonAncestor(
            AncestralTree topAncestor,
            AncestralTree descendantOne,
            AncestralTree descendantTwo
        )
        {
            var lineageOne = GetLineage(descendantOne, new List<AncestralTree>());
            var lineageTwo = GetLineage(descendantTwo, new List<AncestralTree>());
            var lastCommon = topAncestor;
            int i = 0;

            while (i < Math.Min(lineageOne.Count, lineageTwo.Count) && lineageOne[i] == lineageTwo[i])
            {
                lastCommon = lineageOne[i];
                ++i;
            }

            return lastCommon;
        }

        public static List<AncestralTree> GetLineage(AncestralTree person, List<AncestralTree> lineage)
        {
            if (person.ancestor == null)
            {
                lineage.Add(person);
                return lineage;
            }

            var theLineage = GetLineage(person.ancestor, lineage);
            lineage.Add(person);
            return theLineage;
        }

        public class AncestralTree
        {
            public char name;
            public AncestralTree ancestor;

            public AncestralTree(char name)
            {
                this.name = name;
                this.ancestor = null;
            }

            // This method is for testing only.
            public void AddAsAncestor(AncestralTree[] descendants)
            {
                foreach (AncestralTree descendant in descendants)
                {
                    descendant.ancestor = this;
                }
            }
        }
    }

    [TestFixture]
    class Graphs_GetYoungestCommonAncestorV2
    {
        [Test]
        public void DoTest()
        {
            var top = new AncestralTree('A');
            var B = new AncestralTree('B');
            var C = new AncestralTree('C');
            top.AddAsAncestor(new AncestralTree[] { B, C });

            var D = new AncestralTree('D');
            var E = new AncestralTree('E');
            B.AddAsAncestor(new AncestralTree[] { D, E });

            var H = new AncestralTree('H');
            var I = new AncestralTree('I');
            D.AddAsAncestor(new AncestralTree[] { H, I });

            Assert.That(GetYoungestCommonAncestor(top, E, I).name, Is.EqualTo('B'));
            Assert.That(GetYoungestCommonAncestor(top, B, C).name, Is.EqualTo('A'));
            Assert.That(GetYoungestCommonAncestor(top, H, I).name, Is.EqualTo('D'));
        }

        [Test]
        public void DoTest2()
        {
            var top = new AncestralTree('A');
            var B = new AncestralTree('B');
            var C = new AncestralTree('C');
            top.AddAsAncestor(new AncestralTree[] { B, C });

            var D = new AncestralTree('D');
            var E = new AncestralTree('E');
            B.AddAsAncestor(new AncestralTree[] { D, E });

            var H = new AncestralTree('H');
            var I = new AncestralTree('I');
            D.AddAsAncestor(new AncestralTree[] { H, I });

            Assert.That(GetYoungestCommonAncestor(top, H, D).name, Is.EqualTo('D'));
        }
        [Test]
        public void DoTest3()
        {
            var top = new AncestralTree('A');
            var B = new AncestralTree('B');
            var C = new AncestralTree('C');
            top.AddAsAncestor(new AncestralTree[] { B, C });

            var D = new AncestralTree('D');
            var E = new AncestralTree('E');
            B.AddAsAncestor(new AncestralTree[] { D, E });

            var H = new AncestralTree('H');
            var I = new AncestralTree('I');
            D.AddAsAncestor(new AncestralTree[] { H, I });

            Assert.That(GetYoungestCommonAncestor(top, top, B).name, Is.EqualTo('A'));
        }

        [Test]
        public void DoTest4()
        {
            var top = new AncestralTree('A');
            var B = new AncestralTree('B');
            var C = new AncestralTree('C');
            top.AddAsAncestor(new AncestralTree[] { B, C });

            var D = new AncestralTree('D');
            var E = new AncestralTree('E');
            B.AddAsAncestor(new AncestralTree[] { D, E });

            var F = new AncestralTree('F');
            var G = new AncestralTree('G');
            C.AddAsAncestor(new AncestralTree[] { F, G });

            var H = new AncestralTree('H');
            var I = new AncestralTree('I');
            D.AddAsAncestor(new AncestralTree[] { H, I });



            Assert.That(GetYoungestCommonAncestor(top, H, G).name, Is.EqualTo('A'));
        }

        public static AncestralTree GetYoungestCommonAncestor(
            AncestralTree topAncestor,
            AncestralTree descendantOne,
            AncestralTree descendantTwo
        )
        {
            int deptOne = GetDept(descendantOne);
            int deptTwo = GetDept(descendantTwo);
            var yougest = deptOne > deptTwo ? descendantOne : descendantTwo;
            var oldest = deptOne > deptTwo ? descendantTwo : descendantOne;
            int distanceFromYoungest = Math.Max(deptOne, deptTwo) - Math.Min(deptOne, deptTwo);
            var sameLevelAncestor = GetNthAncestor(yougest, distanceFromYoungest);

            while (oldest.name != sameLevelAncestor.name)
            {
                oldest = oldest.ancestor;
                sameLevelAncestor = sameLevelAncestor.ancestor;
            }
              
            return oldest;
        }

        public static int GetDept(AncestralTree person)
        {
            int dept = 0;

            while (person.ancestor != null)
            {
                person = person.ancestor;
                ++dept;
            }

            return dept;
        }

        public static AncestralTree GetNthAncestor(AncestralTree person, int distance)
        {
            while (distance != 0)
            {
                person = person.ancestor;
                --distance;
            }

            return person;
        }

        public class AncestralTree
        {
            public char name;
            public AncestralTree ancestor;

            public AncestralTree(char name)
            {
                this.name = name;
                this.ancestor = null;
            }

            // This method is for testing only.
            public void AddAsAncestor(AncestralTree[] descendants)
            {
                foreach (AncestralTree descendant in descendants)
                {
                    descendant.ancestor = this;
                }
            }
        }
    }
}
