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
            var countVerices = g.g.Length;
            DirectedGraph ng = new DirectedGraph(countVerices);

            for (int v = 0; v < countVerices; v++)
            {
                foreach (int n in g.g[v])
                {
                    ng.AddEdge(n, v);
                }
            }

            return ng;
        }

        

        public class Dfs
        {
            private bool[] marked;

            public Dfs(DirectedGraph g, int v)
            {
                marked = new bool[g.g.Length];

                dfs(g, v);
            }
 
            private void dfs(DirectedGraph g, int v)
            {
                if (marked[v])
                {
                    return;
                }

                marked[v] = true;

                foreach (int w in g.g[v])
                {
                    dfs(g, w);
                }
            }

            public bool GetResult()
            {
                for (int i = 0; i < marked.Length; i++)
                {
                    if (marked[i] == false)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
