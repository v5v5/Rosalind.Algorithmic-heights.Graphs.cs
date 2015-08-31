using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Shared
{
    class Algorithms
    {

        static public int Degree(UndirectedGraph g, int v)
        {
            return g.g[v].Count;
        }

        internal static DirectedGraph CreateReverseGraph(DirectedGraph g)
        {
            DirectedGraph ng = new DirectedGraph(g.CountVertices);

            for (int v = 0; v < g.CountVertices; v++)
            {
                foreach (int n in g.g[v])
                {
                    ng.AddEdge(n, v);
                }
            }

            return ng;
        }
    }
}
