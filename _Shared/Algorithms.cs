using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Shared
{
    class Algorithms
    {

        static public int[] GetVerticesDegree(UndirectedGraph g)
        {
            int[] res = new int[g.CountVertices];

            for (int v = 0; v < g.CountVertices; v++)
            {
                res[v] = g.Degree(v);
            }

            return res;
        }

        internal static int[] GetSumNeighborsDegree(UndirectedGraph g)
        {
            int[] res = new int[g.CountVertices];

            for (int v = 0; v < g.CountVertices; v++)
            {
                //res[v] = 0;
                foreach (int n in g.g[v])
                {
                    res[v] += g.g[n].Count;
                }
            }
            return res;
        }
    }
}
