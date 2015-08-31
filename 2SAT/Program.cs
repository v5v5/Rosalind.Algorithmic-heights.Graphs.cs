using _Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SAT
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "rosalind_2sat";
            _2Satisfiability _2sat = new _2Satisfiability(file + ".txt");
            int[][] res = new int[_2sat.g.Length][];

            for (int i = 0; i < _2sat.g.Length; i++)
            {
                res[i] = Rosalind._2Satisfiability(_2sat.g[i]);
            }

            //for(int i = 0; i < res.Length; i++)
            //{
            //    for (int from = 0; from < _2sat.g[i].g.Length; from++ )
            //    {
            //        foreach(int to in _2sat.g[i].g[from])
            //        {
            //            Console.WriteLine(from + " -> " + to);
            //        }
            //    }
            //    Console.WriteLine();
            //}

            Utils.PrintArraysToFile(res, file + ".out.txt");
            Utils.Finish();
        }
    }

    internal class _2Satisfiability
    {
        public readonly DirectedGraph[] g;

        public _2Satisfiability(string file)
        {
            string path = Utils.GetFullPathFile(file);

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    int i = -1;
                    string[] param;
                    int CountClauses = 0;
                    int CountVertices;

                    line = reader.ReadLine();
                    int CountConjunctions = int.Parse(line);

                    g = new DirectedGraph[CountConjunctions];

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "")
                        {
                            continue;
                        }

                        if (CountClauses == 0)
                        {
                            param = line.Split(' ');
                            CountVertices = 2 * int.Parse(param[0]);
                            CountClauses = int.Parse(param[1]);
                            i++;
                            g[i] = new DirectedGraph(CountVertices);
                            continue;
                        }

                        param = line.Split(' ');

                        int v0 = Int32.Parse(param[0]);
                        int v1 = Int32.Parse(param[1]);

                        g[i].AddEdge(Index(-v0), Index(v1));
                        g[i].AddEdge(Index(-v1), Index(v0));
                        CountClauses--;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private int Index(int v)
        {
            if (v > 0)
            {
                return 2 * v - 2;
            }
            else
            {
                return -2 * v - 1;
            }
        }
    }
}

