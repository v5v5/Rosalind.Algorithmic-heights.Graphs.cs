using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEG
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "rosalind_deg";
            UndirectedGraph g = new UndirectedGraph(file + ".txt");

            int[] res = new int[g.CountVertices];

            for (int v = 0; v < g.CountVertices; v++)
            {
                res[v] = g.Degree(v);
                //Console.Write("{0} ", res[v]);
            }

            Utils.PrintArrayToFile(res, file + ".out.txt");

            Console.Write("Finish.");
            Console.ReadKey();
        }
    }
}
