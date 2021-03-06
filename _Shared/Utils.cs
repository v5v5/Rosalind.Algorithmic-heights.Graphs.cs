﻿using System;
using System.IO;
using System.Reflection;

namespace _Shared
{
    public class Utils
    {
        public static void PrintArrayToFile(int[] a, string file)
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
                    writer.Write(a[i]);
                }
            }
        }

        public static void PrintArrayToFile(string[] a, string file)
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
                    writer.Write(a[i]);
                }
            }
        }

        public static void PrintArraysToFile(int[][] a, string file)
        {
            var path = GetFullPathFile(file);

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (i != 0)
                    {
                        writer.WriteLine();
                    }
                    for (int j = 0; j < a[i].Length; j++)
                    {
                        if (j != 0)
                        {
                            writer.Write(" ");
                        }
                        writer.Write(a[i][j]);
                    }
                }
            }
        }

        public static string GetFullPathFile(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var path = Path.GetDirectoryName(assembly.Location) + "\\..\\..\\..\\_Data\\" + file;
            return path;
        }

        public static void Finish()
        {
            Console.Write("Finish.");
            Console.ReadKey();
        }
    }


}