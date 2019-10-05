using System;
using System.Collections.Generic;
using static Questions.Easy.Graphs_DepthFirstSearch;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var n = new Node("R");
            n.Init();

            var lst = n.DepthFirstSearch(new List<string>());

            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
        }
    }
}
