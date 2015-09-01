using System;
using System.Linq;

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
            //return m.stack.ToArray();

            //m.id.Length ~ m.stack.Count
            //m.id[2 * i + 1] ~ m.stack.ElementAt()

            for (int i = 0; i < m.id.Length / 2; i++)
            //for (int i = 0; i < m.stack.Count / 2; i++)
            {
                // if not solving
                if (m.id[2 * i] == m.id[2 * i + 1])
                //if (m.stack.ElementAt(2 * i) == m.stack.ElementAt(2 * i + 1))
                {
                    return new int[1] { 0 };
                }
            }

            int[] res = new int[m.id.Length / 2 + 1];
            //int[] res = new int[m.stack.Count / 2 + 1];

            res[0] = 1;

            // see Algorithms by Dasgupta, Papadimitriou, Vazirani. McGraw-Hill. 2006, page 102, task 3.28
            for (int i = m.id.Length; i > 0; i--)
            //for (int i = m.stack.Count; i > 0; i--)
            {
                for (int v = 0; v < m.id.Length; v++)
                //for (int v = 0; v < m.stack.Count; v++)
                {
                    if (m.id[v] != i)
                    //if (m.stack.ElementAt(v) != i)
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

        public static int ReachableFrom(DirectedGraph g)
        {
            for (int i = 0; i < g.g.Length; i++)
            {
                Algorithms.Dfs dfs = new Algorithms.Dfs(g, i);
                //if (dfs.GetResult())
                //{
                //    return i + 1;
                //}

                bool res = true;
                for (int j = 0; j < dfs.marked.Length; j++)
                {
                    if (dfs.marked[j] == false)
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public static int SemiConnected0(DirectedGraph g)
        {
            Algorithms.FloydWarshal fw = new Algorithms.FloydWarshal(g);

            int il = fw.dist.GetLength(0);
            int jl = fw.dist.GetLength(1);

            //for (int i = 0; i < il; i++)
            //{
            //    for (int j = 0; j < jl; j++)
            //    {
            //        Console.Write(fw.dist[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            bool res;
            for (int i = 0; i < il; i++)
            {
                res = true;
                for (int j = 0; j < jl; j++)
                {
                    if (fw.dist[i,j] == Int32.MaxValue / 4)
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                {
                    return 1;
                }
            }
            return -1;
        }

        public static int SemiConnected1(DirectedGraph g)
        {
            // http://himangi774.blogspot.ru/2013/12/check-if-graph-is-strongl-connected.html

            Algorithms.SCC scc = new Algorithms.SCC(g);

            //foreach (var v in scc.stack)
            //{
            //    Console.Write(v + " ");
            //}
            //Console.WriteLine();
            //while (scc.stack.Count != 0)
            //{
            //    Console.Write(scc.stack.Pop() + " ");
            //}
            //Console.WriteLine();

            var prev = scc.stack.Pop();
            while (scc.stack.Count != 0)
            {
                var curr = scc.stack.Pop();
                if (curr != prev - 1)
                {
                    return -1;
                }
                prev = curr;
            }

            return 1;
        }
    }
}
