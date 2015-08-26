using System;
using System.Collections.Generic;
using System.IO;

namespace _Shared
{
    internal class UndirectedGraph
    {
        List<int>[] g;
        internal readonly int CountVertices;

        public UndirectedGraph(string file)
        {
            string path = Utils.GetFullPathFile(file);

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;

                    line = reader.ReadLine();

                    string[] param = line.Split(' ');

                    CountVertices = int.Parse(param[0]);
                    //int CountEdges = int.Parse(param[1]);

                    Init();

                    while ((line = reader.ReadLine()) != null)
                    {
                        param = line.Split(' ');

                        int v0 = Int32.Parse(param[0]) - 1;
                        int v1 = Int32.Parse(param[1]) - 1;

                        AddEdge(v0, v1);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }


        public UndirectedGraph()
        {
            CountVertices = 7;

            Init();

            AddEdge(0, 1);
            AddEdge(1, 2);
            AddEdge(2, 0);
            AddEdge(3, 2);
            AddEdge(3, 4);
            AddEdge(3, 5);
            AddEdge(3, 6);
        }

        private void Init()
        {
            g = new List<int>[CountVertices];

            for (int i = 0; i < g.Length; i++)
            {
                g[i] = new List<int>();
            }
        }

        private void AddEdge(int v1, int v2)
        {
            g[v1].Add(v2);
            g[v2].Add(v1);
        }

        internal int Degree(int v)
        {
            return g[v].Count;
        }
    }
}