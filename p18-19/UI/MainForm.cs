using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CSHW2._18_19.BusinessLogic;
using CSHW2._18_19.Models;

namespace CSHW2._18_19.UI
{
    public partial class MainForm : Form
    {
        private readonly FigureService _figureService;
        private readonly ListView _figuresListView;
        private readonly Button _addCircleButton;
        private readonly Button _addTriangleButton;
        private readonly Button _addRectangleButton;
        private readonly Button _sortButton;
        private readonly Button _saveButton;
        private readonly Button _loadButton;

        public MainForm()
        {
            InitializeComponent();
            _figureService = new FigureService("data+.dat");

            // Настройка формы
            this.Text = "Управление фигурами";
            this.Size = new Size(800, 600);

            // Создание ListView для отображения фигур
            _figuresListView = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(10, 10),
                Size = new Size(760, 400)
            };
            _figuresListView.Columns.Add("Тип фигуры", 150);
            _figuresListView.Columns.Add("Параметры", 200);
            _figuresListView.Columns.Add("Площадь", 100);
            this.Controls.Add(_figuresListView);

            // Создание кнопок
            _addCircleButton = CreateButton("Добавить круг", new Point(10, 420));
            _addTriangleButton = CreateButton("Добавить треугольник", new Point(150, 420));
            _addRectangleButton = CreateButton("Добавить прямоугольник", new Point(290, 420));
            _sortButton = CreateButton("Сортировать по площади", new Point(430, 420));
            _saveButton = CreateButton("Сохранить", new Point(570, 420));
            _loadButton = CreateButton("Загрузить", new Point(710, 420));

            // Добавление обработчиков событий
            _addCircleButton.Click += AddCircleButton_Click;
            _addTriangleButton.Click += AddTriangleButton_Click;
            _addRectangleButton.Click += AddRectangleButton_Click;
            _sortButton.Click += SortButton_Click;
            _saveButton.Click += SaveButton_Click;
            _loadButton.Click += LoadButton_Click;

            // Загрузка данных при запуске
            LoadFigures();
        }

        private Button CreateButton(string text, Point location)
        {
            var button = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(130, 30)
            };
            this.Controls.Add(button);
            return button;
        }

        private void LoadFigures()
        {
            _figuresListView.Items.Clear();
            var figures = _figureService.GetFigures();
            foreach (var figure in figures)
            {
                var item = new ListViewItem(figure.GetType().Name);
                item.SubItems.Add(figure.ToString());
                item.SubItems.Add(figure.GetArea().ToString("F2"));
                _figuresListView.Items.Add(item);
            }
        }

        private void AddCircleButton_Click(object sender, EventArgs e)
        {
            using (var form = new InputForm("Введите радиус круга"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (double.TryParse(form.Value, out double radius))
                    {
                        _figureService.AddFigure(new Circle(radius));
                        LoadFigures();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите корректное число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddTriangleButton_Click(object sender, EventArgs e)
        {
            using (var form = new InputForm("Введите стороны треугольника через пробел (a b c)"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var sides = form.Value.Split(' ');
                    if (sides.Length == 3 &&
                        double.TryParse(sides[0], out double a) &&
                        double.TryParse(sides[1], out double b) &&
                        double.TryParse(sides[2], out double c))
                    {
                        _figureService.AddFigure(new Triangle(a, b, c));
                        LoadFigures();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите три числа через пробел", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddRectangleButton_Click(object sender, EventArgs e)
        {
            using (var form = new InputForm("Введите стороны прямоугольника через пробел (a b)"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var sides = form.Value.Split(' ');
                    if (sides.Length == 2 &&
                        double.TryParse(sides[0], out double a) &&
                        double.TryParse(sides[1], out double b))
                    {
                        _figureService.AddFigure(new Rectangle(a, b));
                        LoadFigures();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите два числа через пробел", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            var figures = _figureService.SortFiguresByArea();
            _figureService.SaveFigures(figures);
            LoadFigures();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var figures = _figureService.GetFigures();
            _figureService.SaveFigures(figures);
            MessageBox.Show("Фигуры успешно сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFigures();
        }
    }
} 