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

    }
}
