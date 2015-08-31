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

        public static int[] _2Satisfiability(DirectedGraph g)
        {
            MetaGraph m = new MetaGraph(g);
//            return m.id;

            for (int i = 0; i < m.id.Length / 2; i++)
            {
                // if not solving
                if (m.id[2 * i] == m.id[2 * i + 1])
                {
                    return new int[1] { 0 };
                }
            }

            int[] res = new int[m.id.Length / 2 + 1];

            res[0] = 1;

            for (int i = m.id.Length; i > 0; i--)
            {
                for (int v = 0; v < m.id.Length; v++)
                {
                    if (m.id[v] != i)
                    {
                        continue;
                    }
                    if (res[v / 2 + 1] != 0)
                    {
                        continue;
                    }

                    int r;
                    if (v % 2 == 0)
                    {
                        r = (v + 2) / (+2);
                    }
                    else
                    {
                        r = (v + 1) / (-2);
                    }
                    res[v / 2 + 1] = r;
                }
            }

            return res;
        }
    }
}
