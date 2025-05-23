using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using p18_19.Core.BusinessLogic;
using p18_19.Core.Models;

namespace p18_19.UI
{
    public partial class MainForm : Form
    {
        private readonly FigureService _figureService;
        private List<Figure> _figures;

        public MainForm()
        {
            InitializeComponent();
            _figureService = new FigureService("figures.dat");
            _figures = _figureService.GetFigures();
            RefreshFiguresList();
        }

        private void RefreshFiguresList()
        {
            listBoxFigures.Items.Clear();
            foreach (var figure in _figures)
            {
                listBoxFigures.Items.Add(figure);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var inputForm = new InputForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    var figure = inputForm.Figure;
                    _figureService.AddFigure(figure);
                    _figures = _figureService.GetFigures();
                    RefreshFiguresList();
                }
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            _figures = _figureService.SortFiguresByArea();
            RefreshFiguresList();
        }
    }
} 