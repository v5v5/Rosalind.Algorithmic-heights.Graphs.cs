using System.Collections.Generic;

namespace _Shared
{
    class MetaGraph
    {
        private DirectedGraph g;

        public readonly int[] id;
        public readonly int count;

        private bool[] marked;
        public readonly Stack<int> stack = new Stack<int>();

        public MetaGraph(DirectedGraph g)
        {
            // do dfs on graph
            this.g = g;

            int l = this.g.g.Length;
            marked = new bool[l];
            id = new int[l];

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
            foreach(int v in stack)
            {
                //int v = stack.Pop();
                if (marked[v])
                {
                    continue;
                }
                DfsReverse(v);
                count++;
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
            id[v] = count;

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
