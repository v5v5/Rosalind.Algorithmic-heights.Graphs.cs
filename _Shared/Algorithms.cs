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
            public readonly bool[] marked;

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

        internal class FloydWarshal
        {
            public readonly int[,] dist;

            public FloydWarshal(DirectedGraph g)
            {
                int countVertices = g.g.Length;
                dist = new int[countVertices, countVertices];
                for (int i = 0; i < countVertices; i++)
                {
                    for (int j = 0; j < countVertices; j++)
                    {
                        dist[i, j] = Int32.MaxValue / 4;
                    }
                }

                for (int i = 0; i < countVertices; i++)
                {
                    dist[i, i] = 0;
                }

                for (int i = 0; i < countVertices; i++)
                {
                    foreach (int v in g.g[i])
                    {
                        dist[i, v] = 1;
                    }
                }

                for (int k = 0; k < countVertices; k++)
                {
                    for (int i = 0; i < countVertices; i++)
                    {
                        for (int j = 0; j < countVertices; j++)
                        {
                            dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                            //if (dist[i,j] > dist[i,k] + dist[k,j])
                            //{
                            //    dist[i,j] = dist[i,k] + dist[k,j];
                            //}
                        }
                    }
                }
            }
        }

        // StrongConnectedComponent
        public class SCC
        {
            private DirectedGraph g;
            private bool[] marked;
            public readonly Stack<int> stack = new Stack<int>();

            public SCC(DirectedGraph g)
            {
                // do dfs on graph
                this.g = g;

                int l = this.g.g.Length;
                marked = new bool[l];

                for (int v = 0; v < g.g.Length; v++)
                {
                    if (marked[v])
                    {
                        continue;
                    }
                    Dfs(v);
                }

                // do dfs on reverse (transposed) graph
                this.g = Algorithms.CreateReverseGraph(this.g);

                for (int i = 0; i < marked.Length; i++)
                {
                    marked[i] = false;
                }

                //while(stack.Count != 0)
                foreach (int v in stack)
                {
                    //int v = stack.Pop();
                    if (marked[v])
                    {
                        continue;
                    }
                    DfsReverse(v);
                }

                this.g = g;
            }

            private void Dfs(int v)
            {
                marked[v] = true;

                foreach (int w in g.g[v])
                {
                    if (marked[w])
                    {
                        continue;
                    }
                    Dfs(w);
                }

                stack.Push(v);
            }

            private void DfsReverse(int v)
            {
                marked[v] = true;

                foreach (int w in g.g[v])
                {
                    if (marked[w])
                    {
                        continue;
                    }
                    DfsReverse(w);
                }
            }

        }
    }
}
