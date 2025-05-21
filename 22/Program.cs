using System;
using System.IO;
using System.Collections.Generic;

namespace _22
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Graph g = new Graph("/Users/arseniy/RiderProjects/CSHW2/22/input22_1.txt");
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    writer.WriteLine("\nЗаходящие соседние вершины:");
                    g.IncomingVertices(0, writer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    public class Graph
    {
        private class Node
        {
            private int[,] array;
            public int this[int i, int j]
            {
                get { return array[i, j]; }
                set { array[i, j] = value; }
            }
            public int Size
            {
                get { return array.GetLength(0); }
            }
            public Node(int[,] a)
            {
                array = a;
            }
        }

        private Node graph;

        public Graph(string name)
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine().Trim());
                int[,] a = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string[] values = file.ReadLine().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length != n)
                        throw new FormatException("Неверное количество элементов в строке матрицы.");
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(values[j]);
                    }
                }
                graph = new Node(a);
            }
        }
        
        public void IncomingVertices(int v, StreamWriter writer = null)
        {
            string header = $"Заходящие вершины для вершины {v}:";
            Console.WriteLine(header);
            writer?.WriteLine(header);

            bool hasIncoming = false;
            for (int u = 0; u < graph.Size; u++)
            {
                if (graph[u, v] != 0)
                {
                    string output = $"{u} ";
                    Console.Write(output);
                    writer?.Write(output);
                    hasIncoming = true;
                }
            }
            if (!hasIncoming)
            {
                Console.WriteLine("Нет заходящих вершин.");
                writer?.WriteLine("Нет заходящих вершин.");
            }
            else
            {
                Console.WriteLine();
                writer?.WriteLine();
            }
        }
    }
}