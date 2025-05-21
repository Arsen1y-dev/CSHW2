using System;
using System.IO;
using System.Text;

namespace _20
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class TypedLinkedList
    {
        private Node _head;
        private Node _tail;
        private Node _temp; 

        public TypedLinkedList()
        {
            InitializeList();
        }

        private void InitializeList()
        {
            _head = null;
            _tail = null;
            _temp = null;
        }

        public void AddToTail(int data)
        {
            Node newNode = new Node(data);
            if (_tail == null) 
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
        }

        public int? RemoveFromHead()
        {
            if (_head == null) 
            {
                return null; 
            }

            int data = _head.Data;
            _head = _head.Next;

            if (_head == null)
            {
                _tail = null;
            }

            return data;
        }

        public string ViewList()
        {
            var sb = new StringBuilder();
            _temp = _head; 
            while (_temp != null)
            {
                sb.Append(_temp.Data).Append(' ');
                _temp = _temp.Next;
            }
            return sb.ToString().TrimEnd(); 
        }

        public void RemoveDuplicates()
        {
            if (_head == null || _head.Next == null) 
            {
                return;
            }

            Node current = _head;
            while (current != null)
            {
                Node runner = current; 
                while (runner.Next != null)
                {
                    if (runner.Next.Data == current.Data)
                    {
                        runner.Next = runner.Next.Next;
                        if (runner.Next == null) 
                        {
                            _tail = runner; 
                        }
                    }
                    else
                    {
                        runner = runner.Next; 
                    }
                }
                current = current.Next; 
            }
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            var list = new TypedLinkedList();
            var originalSequence = new StringBuilder();

            try
            {
                string[] lines = File.ReadAllLines("/Users/arseniy/RiderProjects/CSHW2/20/input.txt");
                foreach (string line in lines)
                {
                    string[] numbersStr = line.Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string numStr in numbersStr)
                    {
                        if (int.TryParse(numStr, out int number))
                        {
                            list.AddToTail(number);
                            originalSequence.Append(number).Append(" ");
                        }
                        else
                        {
                            Console.WriteLine($"Некорректное число в файле: {numStr}. Пропускаем.");
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл input.txt не найден.");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
                return;
            }

            Console.WriteLine("Исходная последовательность: " + originalSequence.ToString().TrimEnd());

            list.RemoveDuplicates();

            var uniqueSequence = list.ViewList();
            Console.WriteLine("Итоговая последовательность (без дубликатов): " + uniqueSequence);

            try
            {
                using (StreamWriter writer = new StreamWriter("/Users/arseniy/RiderProjects/CSHW2/20/output.txt"))
                {
                    writer.WriteLine(originalSequence.ToString().TrimEnd());
                    writer.WriteLine(uniqueSequence);
                }
                Console.WriteLine("Результат записан в файл output.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при записи в файл output.txt: {e.Message}");
            }
        }
    }
}