using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSHW2._18_19.UI
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
            this.Size = new Size(300, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            var label = new Label
            {
                Text = prompt,
                Location = new Point(10, 10),
                Size = new Size(270, 20)
            };
            this.Controls.Add(label);

            _inputTextBox = new TextBox
            {
                Location = new Point(10, 40),
                Size = new Size(270, 20)
            };
            this.Controls.Add(_inputTextBox);

            _okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(110, 70),
                Size = new Size(75, 23)
            };
            this.Controls.Add(_okButton);

            _cancelButton = new Button
            {
                Text = "Отмена",
                DialogResult = DialogResult.Cancel,
                Location = new Point(195, 70),
                Size = new Size(75, 23)
            };
            this.Controls.Add(_cancelButton);

            this.AcceptButton = _okButton;
            this.CancelButton = _cancelButton;
        }
    }
} 