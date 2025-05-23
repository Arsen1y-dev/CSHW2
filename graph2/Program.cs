using System;
using System.IO;
using System.Collections.Generic;

namespace graph2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Graph g = new Graph("/Users/arseniy/RiderProjects/CSHW2/graph2/input3.txt");
                using (StreamWriter writer = new StreamWriter("/Users/arseniy/RiderProjects/CSHW2/graph2/output.txt"))
                {
                    writer.WriteLine("\nПоиск эйлерова пути/цикла:");
                    g.FindEulerianPathOrCycle(writer);
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
            public int[,] array;
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

        // Проверка связности (только для вершин с ненулевой степенью)
        private bool IsConnected()
        {
            int n = graph.Size;
            bool[] visited = new bool[n];
            int start = -1;
            for (int i = 0; i < n; i++)
            {
                int deg = 0;
                for (int j = 0; j < n; j++)
                    deg += graph[i, j];
                if (deg > 0)
                {
                    start = i;
                    break;
                }
            }
            if (start == -1) return true; // Нет рёбер
            DFS(start, visited);
            for (int i = 0; i < n; i++)
            {
                int deg = 0;
                for (int j = 0; j < n; j++)
                    deg += graph[i, j];
                if (deg > 0 && !visited[i])
                    return false;
            }
            return true;
        }

        private void DFS(int v, bool[] visited)
        {
            visited[v] = true;
            for (int u = 0; u < graph.Size; u++)
            {
                if (graph[v, u] > 0 && !visited[u])
                    DFS(u, visited);
            }
        }

        public void FindEulerianPathOrCycle(StreamWriter writer = null)
        {
            int n = graph.Size;
            int[] degree = new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    degree[i] += graph[i, j];

            if (!IsConnected())
            {
                string msg = "Эйлеров путь не существует (граф не связный).";
                Console.WriteLine(msg);
                writer?.WriteLine(msg);
                return;
            }

            int oddCount = 0;
            int start = 0;
            for (int i = 0; i < n; i++)
                if (degree[i] % 2 != 0)
                {
                    oddCount++;
                    start = i; // если есть нечетные, стартуем с одной из них
                }

            if (oddCount != 0 && oddCount != 2)
            {
                string msg = "Эйлеров путь не существует (неправильное число вершин с нечетной степенью).";
                Console.WriteLine(msg);
                writer?.WriteLine(msg);
                return;
            }

            // Копируем матрицу для работы
            int[,] temp = new int[n, n];
            Array.Copy(graph.array, temp, graph.array.Length);
            Stack<int> stack = new Stack<int>();
            List<int> path = new List<int>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                int v = stack.Peek();
                int u;
                for (u = 0; u < n; u++)
                    if (temp[v, u] > 0) break;
                if (u < n)
                {
                    stack.Push(u);
                    temp[v, u]--;
                    temp[u, v]--; // для неориентированного графа
                }
                else
                {
                    path.Add(stack.Pop());
                }
            }
            path.Reverse();
            // Подсчёт реального количества рёбер
            int edgeCount = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    edgeCount += graph.array[i, j];
            edgeCount /= 2;
            if (path.Count <= 1 || path.Count != edgeCount + 1)
            {
                string msg = "Эйлеров путь не существует (не все рёбра использованы).";
                Console.WriteLine(msg);
                writer?.WriteLine(msg);
                return;
            }
            string header = oddCount == 0 ? "Эйлеров цикл:" : "Эйлеров путь:";
            Console.WriteLine(header);
            writer?.WriteLine(header);
            string output = string.Join(" -> ", path);
            Console.WriteLine(output);
            writer?.WriteLine(output);
        }
    }
}
