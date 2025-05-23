using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CSHW2._18_19.BusinessLogic;
using CSHW2._18_19.Models;

namespace CSHW2._18_19.ThreeLayer.UI
{
    public partial class MainForm : Form
    {
        private readonly FigureService _figureService;
        private readonly DataGridView _figuresGridView;
        private readonly Panel _controlPanel;
        private readonly Button _addCircleButton;
        private readonly Button _addTriangleButton;
        private readonly Button _addRectangleButton;
        private readonly Button _sortButton;
        private readonly Button _saveButton;
        private readonly Button _loadButton;
        private readonly Label _titleLabel;

        public MainForm()
        {
            InitializeComponent();
            _figureService = new FigureService("data+.dat");

            // Настройка формы
            this.Text = "Управление геометрическими фигурами";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            // Создание заголовка
            _titleLabel = new Label
            {
                Text = "Геометрические фигуры",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(20, 20),
                Size = new Size(400, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(_titleLabel);

            // Создание панели управления
            _controlPanel = new Panel
            {
                Location = new Point(20, 70),
                Size = new Size(940, 60),
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(_controlPanel);

            // Создание кнопок
            _addCircleButton = CreateButton("Добавить круг", new Point(20, 15));
            _addTriangleButton = CreateButton("Добавить треугольник", new Point(170, 15));
            _addRectangleButton = CreateButton("Добавить прямоугольник", new Point(320, 15));
            _sortButton = CreateButton("Сортировать по площади", new Point(470, 15));
            _saveButton = CreateButton("Сохранить", new Point(620, 15));
            _loadButton = CreateButton("Загрузить", new Point(770, 15));

            _controlPanel.Controls.AddRange(new Control[] { 
                _addCircleButton, _addTriangleButton, _addRectangleButton,
                _sortButton, _saveButton, _loadButton 
            });

            // Создание таблицы
            _figuresGridView = new DataGridView
            {
                Location = new Point(20, 150),
                Size = new Size(940, 480),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                GridColor = Color.FromArgb(224, 224, 224)
            };

            _figuresGridView.Columns.Add("Type", "Тип фигуры");
            _figuresGridView.Columns.Add("Parameters", "Параметры");
            _figuresGridView.Columns.Add("Area", "Площадь");

            _figuresGridView.Columns["Type"].Width = 200;
            _figuresGridView.Columns["Parameters"].Width = 400;
            _figuresGridView.Columns["Area"].Width = 200;

            this.Controls.Add(_figuresGridView);

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
                Size = new Size(140, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private void LoadFigures()
        {
            _figuresGridView.Rows.Clear();
            var figures = _figureService.GetFigures();
            foreach (var figure in figures)
            {
                _figuresGridView.Rows.Add(
                    figure.GetType().Name,
                    figure.ToString(),
                    figure.GetArea().ToString("F2")
                );
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
                        MessageBox.Show("Пожалуйста, введите корректное число", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Пожалуйста, введите три числа через пробел", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Пожалуйста, введите два числа через пробел", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Фигуры успешно сохранены", "Успех", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFigures();
        }
    }
} 