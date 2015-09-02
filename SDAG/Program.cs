using _Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAG
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "rosalind_sdag";
            DirectedWeightedGraph g = new DirectedWeightedGraph(file + ".txt");

            //for (int v = 0; v < g.g.Length; v++)
            //{
            //    Console.Write("{0} : ", v);
            //    foreach (var n in g.g[v])
            //    {
            //        Console.Write("{0} {1}, ", n.neighbor, n.weight);
            //    }
            //    Console.WriteLine();
            //}

            string[] res = Rosalind.ShortestPathsInDAG(g, 0);

            Utils.PrintArrayToFile(res, file + ".out.txt");
            Utils.Finish();

        }
    }
}
