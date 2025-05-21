using System;
using System.Collections.Generic;
using System.IO;

namespace _21
{
    public class TreeNode
    {
        public int Inf { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        
        public Counter Cntr { get; set; }

        public TreeNode(int value)
        {
            Inf = value;
            Left = null;
            Right = null;
            Counter = 1;
        }
    }

    public class BinarySearchTree
    {
        public TreeNode Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int value)
        {
            Root = InsertNode(Root, value);
        }

        private TreeNode InsertNode(TreeNode root, int value)
        {
            if (root == null)
            {
                return new TreeNode(value);
            }

            if (value < root.Inf)
            {
                root.Left = InsertNode(root.Left, value);
            }
            else
            {
                root.Right = InsertNode(root.Right, value);
            }
            return root;
        }

        public (int MaxValue, int Count) FindMaximumValueAndCount()
        {
            if (Root == null)
            {
                return (int.MinValue, 0);
            }

            int max = int.MinValue;
            int count = 0;

            FindMaxInRightSubtree(Root, ref max, ref count);

            return (max, count);
        }

        private void FindMaxInRightSubtree(TreeNode node, ref int max, ref int count)
        {
            while (node != null)
            {
                if (node.Inf > max)
                {
                    max = node.Inf;
                    count = 1;
                }
                else if (node.Inf == max)
                {
                    count++;
                }

                node = node.Right;
            }
        }

        private void AddOneNode(TreeNode root, int value)
        {
            
        }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            List<int> inputNumbers = new List<int>();
            string inputFilePath = "/Users/arseniy/RiderProjects/CSHW2/21/input.txt";
            string outputFilePath = "/Users/arseniy/RiderProjects/CSHW2/21/output.txt";
            string outputFilePath2 = "/Users/arseniy/RiderProjects/CSHW2/21/output2.txt";

            try
            {
                string fileContent = File.ReadAllText(inputFilePath);
                string[] numberStrings = fileContent.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string numberString in numberStrings)
                {
                    if (int.TryParse(numberString, out int number))
                    {
                        inputNumbers.Add(number);
                    }
                }

                if (inputNumbers.Count == 0)
                {
                    WriteOutputToFile(outputFilePath, "В файле input.txt не найдено целых чисел или файл пуст.");
                    return;
                }

                foreach (int number in inputNumbers)
                {
                    bst.Insert(number);
                }

                var (maxValue, count) = bst.FindMaximumValueAndCount();

                if (count > 0)
                {
                    string outputMessage = "Наибольшее значение в дереве: " + maxValue;
                    if (count > 1)
                    {
                        outputMessage += $" (встречается {count} раз)";
                    }
                    WriteOutputToFile(outputFilePath, outputMessage);
                }
                else
                {
                    WriteOutputToFile(outputFilePath, "Дерево пустое, наибольших значений нет.");
                }

                if (inputNumbers.Count > 0)
                {
                    int nodeToFind = 14;
                    int level = bst.FindNodeLevel(nodeToFind);

                    string levelOutputMessage = level >= 0
                        ? $"Узел со значением {nodeToFind} находится на уровне {level}."
                        : $"Узел со значением {nodeToFind} не найден в дереве.";

                    WriteOutputToFile(outputFilePath2, levelOutputMessage);
                }
            }
            catch (FileNotFoundException)
            {
                WriteOutputToFile(outputFilePath, "Файл input.txt не найден. Пожалуйста, убедитесь, что файл существует по пути: " + inputFilePath);
            }
            catch (Exception ex)
            {
                WriteOutputToFile(outputFilePath, $"Произошла ошибка при чтении файла: {ex.Message}");
            }
        }

        static void WriteOutputToFile(string filePath, string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Критическая ошибка при записи в файл {filePath}: {e.Message}");
                Console.WriteLine($"Исходное сообщение: {text}");
            }
        }
    }
}