using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CSHW2._18_19.Models;

namespace CSHW2._18_19.Presentation
{
    class Program
    {
        static void Print(List<Figure> figures)
        {
            if (figures.Count == 0)
            {
                Console.WriteLine("Список фигур пуст.");
            }
            else
            {
                Console.WriteLine("Список фигур:");
                foreach (Figure figure in figures)
                {
                    Console.WriteLine(figure.ToString());
                }
            }
        }

        static void Main(string[] args)
        {
            string serializationFileName = "dataX.dat";
            List<Figure> figures = new List<Figure>();
            BinaryFormatter formatter = new BinaryFormatter();
            bool fileExists = File.Exists(serializationFileName) && new FileInfo(serializationFileName).Length > 0;
            
            if (fileExists)
            {
                using (FileStream f = new FileStream(serializationFileName, FileMode.Open))
                {
                    figures = (List<Figure>)formatter.Deserialize(f);
                    Console.WriteLine("Загружены фигуры из файла:");
                    Print(figures);
                }
            }
            else
            {
                Console.WriteLine("Файл input.dat отсутствует или пуст.");
                
            }
            figures.Add(new Circle(7));
            figures.Add(new Triangle(3, 4, 5));
            figures.Add(new Rectangle(4, 3));
             
            Print(figures);
            
            Console.WriteLine("\nСортировка фигур по площади:");
            figures.Sort();
            Print(figures);

            using (FileStream f = new FileStream(serializationFileName, FileMode.Create))
            {
                formatter.Serialize(f, figures);
                Console.WriteLine($"Список фигур сериализован и сохранен в файл {serializationFileName}.");
            }
            
            Console.WriteLine("Программа завершена.");
        }
    }
}
