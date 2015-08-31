using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Shared
{
    public class DirectedGraphs
    {
        public readonly DirectedGraph[] g;

        public DirectedGraphs(string file)
        {
            string path = Utils.GetFullPathFile(file);

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    int i = -1;
                    string[] param;
                    int CountEdges = 0;
                    int CountVertices;

                    line = reader.ReadLine();

                    int CountGraphs = int.Parse(line);
                    g = new DirectedGraph[CountGraphs];

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "")
                        {
                            continue;
                        }

                        if (CountEdges == 0)
                        {
                            param = line.Split(' ');
                            CountVertices = int.Parse(param[0]);
                            CountEdges = int.Parse(param[1]);
                            i++;
                            g[i] = new DirectedGraph(CountVertices);
                            continue;
                        }

                        param = line.Split(' ');

                        int from = Int32.Parse(param[0]) - 1;
                        int to = Int32.Parse(param[1]) - 1;

                        g[i].AddEdge(from, to);
                        CountEdges--;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
