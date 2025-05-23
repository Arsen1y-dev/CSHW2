using System;
using System.IO;
using System.Collections.Generic;

namespace _22
{
    public class Graph
    {
        private class Node 
        {
            private int[,] array; //матрица смежности
            public int this[int i, int j] //индексатор для обращения к матрице смежности
            {
                get { return array[i, j]; }
                set { array[i, j] = value; }
            }
            public int Size //свойство для получения размерности матрицы смежности
            {
                get { return array.GetLength(0); }
            }
            public Node(int[,] a) //конструктор вложенного класса, инициализирует матрицу смежности и вспомогательный массив
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
            Console.WriteLine($"Заходящие вершины для вершины {v}:");

            bool hasIncoming = false;
            for (int u = 0; u < graph.Size; u++)
            {
                if (graph[u, v] != 0)
                {
                    Console.Write($"{u} ");
                    hasIncoming = true;
                }
            }
            if (!hasIncoming)
            {
                Console.WriteLine("Нет заходящих вершин.");
                
            }
            else
            {
                Console.WriteLine();
            }
        }

        class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Graph g = new Graph("/Users/arseniy/RiderProjects/CSHW2/22/input22_1.txt");
                using (StreamWriter writer = new StreamWriter("/Users/arseniy/RiderProjects/CSHW2/22/output.txt"))
                {
                    writer.WriteLine("\nЗаходящие соседние вершины:");
                    g.IncomingVertices(2, writer); // 0
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
    }
}


 