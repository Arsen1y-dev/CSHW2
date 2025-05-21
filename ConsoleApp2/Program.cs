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

        public TreeNode(int value)
        {
            Inf = value;
            Left = null;
            Right = null;
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

        public int FindNodeLevel(int value)
        {
            return GetNodeLevel(Root, value, 0);
        }

        private int GetNodeLevel(TreeNode node, int value, int level)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.Inf == value)
            {
                return level;
            }
            else if (value < node.Inf)
            {
                return GetNodeLevel(node.Left, value, level + 1);
            }
            else
            {
                return GetNodeLevel(node.Right, value, level + 1);
            }
        }

        public bool CanBecomePerfectBSTWithOneAddition(out int valueToAdd)
        {
            List<int> values = new List<int>();
            InOrderTraversal(Root, values);

            values.Sort();

            int currentCount = values.Count;

            // Найдём следующее число вида (2^h - 1)
            int h = 1;
            while ((1 << h) - 1 <= currentCount) h++;
            int targetCount = (1 << h) - 1;

            int neededAdditions = targetCount - currentCount;

            if (neededAdditions == 1)
            {
                for (int i = 0; i <= currentCount; i++)
                {
                    List<int> testList = new List<int>(values);
                    int newValue;

                    if (i == 0)
                        newValue = values[0] - 1;
                    else if (i == currentCount)
                        newValue = values[^1] + 1;
                    else
                        newValue = (values[i - 1] + values[i]) / 2;

                    if (values.Contains(newValue)) continue;

                    testList.Insert(i, newValue);

                    TreeNode newRoot = BuildPerfectBST(testList, 0, testList.Count - 1);
                    if (IsPerfect(newRoot))
                    {
                        valueToAdd = newValue;
                        return true;
                    }
                }
            }

            valueToAdd = -1;
            return false;
        }

        private void InOrderTraversal(TreeNode node, List<int> values)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, values);
            values.Add(node.Inf);
            InOrderTraversal(node.Right, values);
        }

        private TreeNode BuildPerfectBST(List<int> sortedValues, int left, int right)
        {
            if (left > right) return null;
            int mid = (left + right) / 2;
            TreeNode node = new TreeNode(sortedValues[mid]);
            node.Left = BuildPerfectBST(sortedValues, left, mid - 1);
            node.Right = BuildPerfectBST(sortedValues, mid + 1, right);
            return node;
        }

        private bool IsPerfect(TreeNode root)
        {
            int depth = GetDepth(root);
            return IsPerfectRec(root, depth, 0);
        }

        private int GetDepth(TreeNode node)
        {
            int d = 0;
            while (node != null)
            {
                d++;
                node = node.Left;
            }
            return d;
        }

        private bool IsPerfectRec(TreeNode node, int depth, int level)
        {
            if (node == null) return true;
            if (node.Left == null && node.Right == null)
                return depth == level + 1;
            if (node.Left == null || node.Right == null)
                return false;
            return IsPerfectRec(node.Left, depth, level + 1) &&
                   IsPerfectRec(node.Right, depth, level + 1);
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
            string outputFilePath3 = "/Users/arseniy/RiderProjects/CSHW2/21/output3.txt";

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

                int valueToAdd;
                bool canBePerfect = bst.CanBecomePerfectBSTWithOneAddition(out valueToAdd);

                string output3Message = canBePerfect
                    ? $"Можно добавить значение {valueToAdd}, чтобы дерево стало идеальным BST."
                    : "Нельзя сделать дерево идеальным, добавив ровно один узел.";

                WriteOutputToFile(outputFilePath3, output3Message);
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