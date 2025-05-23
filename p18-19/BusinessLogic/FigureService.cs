using System;
using System.Collections.Generic;
using CSHW2._18_19.Models;
using CSHW2._18_19.DataAccess;

namespace CSHW2._18_19.BusinessLogic
{
    public class FigureService
    {
        private readonly FigureRepository _repository;

        public FigureService(string fileName)
        {
            _repository = new FigureRepository(fileName);
        }

        public List<Figure> GetFigures()
        {
            return _repository.LoadFigures();
        }

        public void AddFigure(Figure figure)
        {
            var figures = _repository.LoadFigures();
            figures.Add(figure);
            _repository.SaveFigures(figures);
        }

        public List<Figure> SortFiguresByArea()
        {
            var figures = _repository.LoadFigures();
            figures.Sort();
            return figures;
        }

        public void SaveFigures(List<Figure> figures)
        {
            _repository.SaveFigures(figures);
        }
    }
}