using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using p18_19.Core.Models;

namespace p18_19.Core.DataAccess
{
    public class FigureRepository
    {
        private readonly string _fileName;

        public FigureRepository(string fileName)
        {
            _fileName = fileName;
        }

        public List<Figure> LoadFigures()
        {
            List<Figure> figures = new List<Figure>();
            if (File.Exists(_fileName) && new FileInfo(_fileName).Length > 0)
            {
                using (FileStream fs = new FileStream(_fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    figures = (List<Figure>)formatter.Deserialize(fs);
                }
            }
            return figures;
        }

        public void SaveFigures(List<Figure> figures)
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, figures);
            }
        }
    }
} 