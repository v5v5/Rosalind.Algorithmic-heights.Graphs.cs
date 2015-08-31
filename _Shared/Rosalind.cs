using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Shared
{
    public class Rosalind
    {
        static public int[] GetVerticesDegree(UndirectedGraph g)
        {
            int[] res = new int[g.CountVertices];

            for (int v = 0; v < g.CountVertices; v++)
            {
                res[v] = Algorithms.Degree(g, v);
            }

            return res;
        }

        static public int[] GetSumNeighborsDegree(UndirectedGraph g)
        {
            int[] res = new int[g.CountVertices];

            for (int v = 0; v < g.CountVertices; v++)
            {
                //res[v] = 0;
                foreach (int n in g.g[v])
                {
                    res[v] += Algorithms.Degree(g, n);
                }
            }
            return res;
        }

    }
}
