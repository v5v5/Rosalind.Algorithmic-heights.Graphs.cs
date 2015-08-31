using _Shared;
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

            int[] res = Rosalind.GetVerticesDegree(g);

            Utils.PrintArrayToFile(res, file + ".out.txt");
            Utils.Finish();
        }
    }
}
