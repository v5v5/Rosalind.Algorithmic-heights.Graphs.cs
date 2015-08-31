using _Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDEG
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "rosalind_ddeg";
            UndirectedGraph g = new UndirectedGraph(file + ".txt");

            int[] res = Rosalind.GetSumNeighborsDegree(g);

            Utils.PrintArrayToFile(res, file + ".out.txt");

            Console.Write("Finish.");
            Console.ReadKey();

        }
    }
}
