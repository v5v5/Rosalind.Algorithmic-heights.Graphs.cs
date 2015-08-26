using System;
using System.IO;
using System.Reflection;

namespace _Shared
{
    internal class Utils
    {
        internal static void PrintArrayToFile(int[] a, string file)
        {
            var path = GetFullPathFile(file);

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (i != 0)
                    {
                        writer.Write(" ");
                    }
                    writer.Write(a[i].ToString());
                }
            }
        }

        internal static string GetFullPathFile(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var path = Path.GetDirectoryName(assembly.Location) + "\\..\\..\\..\\_Data\\" + file;
            return path;
        }

    }


}