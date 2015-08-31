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
    }
}
