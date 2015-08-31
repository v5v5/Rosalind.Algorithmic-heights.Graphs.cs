using _Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "rosalind_gs";
            DirectedGraphs gg = new DirectedGraphs(file + ".txt");

            //for (int i = 0; i < gg.g.Length; i++)
            //{
            //    DirectedGraph g = gg.g[i];
            //    if (i != 0)
            //    {
            //        Console.WriteLine("");
            //    }

            //    for (int j = 0; j < g.g.Length; j++)
            //    {
            //        foreach (int v in g.g[j])
            //        {
            //            Console.WriteLine(j + "->" + v);
            //        }
            //    }
            //}
            //Utils.Finish();

            int countGraphs = gg.g.Length;
            int[] res = new int[countGraphs];

            for (int i = 0; i < countGraphs; i++)
            {
                DirectedGraph g = gg.g[i];
                res[i] = Rosalind.ReachableFrom(g);
            }

            Utils.PrintArrayToFile(res, file + ".out.txt");
            Utils.Finish();

        }
    }
}
