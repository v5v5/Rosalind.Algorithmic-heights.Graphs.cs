using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Shared
{
    public class DirectedGraph
    {
        public readonly List<int>[] g;

        public DirectedGraph(string file)
        {
            string path = Utils.GetFullPathFile(file);

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;

                    line = reader.ReadLine();

                    string[] param = line.Split(' ');

                    int CountVertices = int.Parse(param[0]);
                    //int CountEdges = int.Parse(param[1]);

                    g = new List<int>[CountVertices];
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


        public DirectedGraph()
        {
            g = new List<int>[7];
            Init();

            AddEdge(0, 1);
            AddEdge(1, 2);
            AddEdge(2, 0);
            AddEdge(3, 2);
            AddEdge(3, 4);
            AddEdge(3, 5);
            AddEdge(3, 6);
        }

        public DirectedGraph(int countVertices)
        {
            g = new List<int>[countVertices];
            Init();
        }

        private void Init()
        {
            //g = new List<int>[CountVertices];
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = new List<int>();
            }
        }

        public void AddEdge(int from, int to)
        {
            g[from].Add(to);
        }

    }
}
