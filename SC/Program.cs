using _Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "rosalind_sc";
            DirectedGraphs gg = new DirectedGraphs(file + ".txt");
            int countGraphs = gg.g.Length;
            int[] res = new int[countGraphs];

            for (int i = 0; i < countGraphs; i++)
            {
                DirectedGraph g = gg.g[i];
                res[i] = Rosalind.SemiConnected1(g);
            }

            Utils.PrintArrayToFile(res, file + ".out.txt");
            Utils.Finish();

        }
    }
}
