using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Shared
{
    public class DirectedWeightedGraph
    {
        public readonly List<Neighbor>[] g;

        public DirectedWeightedGraph(string file)
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

                    g = new List<Neighbor>[CountVertices];
                    Init();

                    while ((line = reader.ReadLine()) != null)
                    {
                        param = line.Split(' ');

                        int from = Int32.Parse(param[0]) - 1;
                        int to = Int32.Parse(param[1]) - 1;
                        int weight = Int32.Parse(param[2]);

                        AddEdge(from, to, weight);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        private void Init()
        {
            //g = new List<int>[CountVertices];
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = new List<Neighbor>();
            }
        }

        public void AddEdge(int from, int to, int weight)
        {
            Neighbor n;
            n.neighbor = to;
            n.weight = weight;

            g[from].Add(n);
        }

    }

    public struct Neighbor
    {
        public int neighbor;
        public int weight;
    }
}
