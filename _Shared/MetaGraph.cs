using System.Collections.Generic;

namespace _Shared
{
    class MetaGraph
    {
        private DirectedGraph g;

        public readonly int[] id;
        public readonly int count;

        private readonly bool[] marked;
        private Stack<int> stack = new Stack<int>();

        public MetaGraph(DirectedGraph g)
        {
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

            this.g = Algorithms.CreateReverseGraph(this.g);

            for (int i = 0; i < marked.Length; i++)
            {
                marked[i] = false;
            }

            while(stack.Count != 0)
            {
                int v = stack.Pop();
                if (marked[v])
                {
                    continue;
                }
                DfsReverse(v);
                count++;
            }

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
