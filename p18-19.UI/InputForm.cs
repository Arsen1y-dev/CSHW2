using System;
using System.Drawing;
using System.Windows.Forms;
using p18_19.Core.Models;

namespace p18_19.UI
{
    public partial class InputForm : Form
    {
        public Figure Figure { get; private set; }

        public InputForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonCircle.Checked)
                {
                    double radius = double.Parse(textBoxRadius.Text);
                    Figure = new Circle(radius);
                }
                else if (radioButtonRectangle.Checked)
                {
                    double width = double.Parse(textBoxWidth.Text);
                    double height = double.Parse(textBoxHeight.Text);
                    Figure = new Rectangle(width, height);
                }
                else if (radioButtonTriangle.Checked)
                {
                    double sideA = double.Parse(textBoxSideA.Text);
                    double sideB = double.Parse(textBoxSideB.Text);
                    double sideC = double.Parse(textBoxSideC.Text);
                    Figure = new Triangle(sideA, sideB, sideC);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 