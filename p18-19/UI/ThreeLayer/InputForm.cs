using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSHW2._18_19.ThreeLayer.UI
{
    public class InputForm : Form
    {
        private readonly TextBox _inputTextBox;
        private readonly Button _okButton;
        private readonly Button _cancelButton;
        public string Value => _inputTextBox.Text;

        public InputForm(string prompt)
        {
            this.Text = "Ввод данных";
            this.Size = new Size(400, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);

            var label = new Label
            {
                Text = prompt,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(20, 20),
                Size = new Size(340, 40),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(label);

            _inputTextBox = new TextBox
            {
                Location = new Point(20, 70),
                Size = new Size(340, 30),
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(_inputTextBox);

            _okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(180, 120),
                Size = new Size(80, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F),
                Cursor = Cursors.Hand
            };
            _okButton.FlatAppearance.BorderSize = 0;
            this.Controls.Add(_okButton);

            _cancelButton = new Button
            {
                Text = "Отмена",
                DialogResult = DialogResult.Cancel,
                Location = new Point(280, 120),
                Size = new Size(80, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.FromArgb(64, 64, 64),
                Font = new Font("Segoe UI", 9F),
                Cursor = Cursors.Hand
            };
            _cancelButton.FlatAppearance.BorderSize = 0;
            this.Controls.Add(_cancelButton);

            this.AcceptButton = _okButton;
            this.CancelButton = _cancelButton;
        }
    }
} 