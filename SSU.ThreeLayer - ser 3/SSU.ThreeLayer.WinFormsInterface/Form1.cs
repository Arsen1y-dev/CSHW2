using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.Common;
using SSU.ThreeLayer.Entities;

namespace SSU.ThreeLayer.WinFormsInterface
{
    public partial class Form1 : Form
    {
        IClientLogic _cl;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cl = DependencyResolver.ClientLogic;
            FillDataGridView();
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            if (!Equals(textBoxName.Text, ""))
            {
                _cl.AddClient(textBoxName.Text);
                FillDataGridView();
            }
            else
            {
                MessageBox.Show("Enter a name");
            }
        }

        private void FillDataGridView()
        {
            dataGridViewClients.Rows.Clear();
            foreach (Client client in _cl.GetAllClients())
            {
                dataGridViewClients.Rows.Add(false, client.id, client.name);
            }
        }

        private void buttonDeleteCllients_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewClients.Rows)
            {
                if (object.Equals(row.Cells["ColumnChecked"].Value, true))
                {
                    _cl.DeleteClient((int)row.Cells["ColumnId"].Value);
                }
            }

            FillDataGridView();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewClients.Rows.Clear();
            foreach (Client client in _cl.GetAllClients())
            {
                if (client.name.Contains(textBoxSearch.Text))
                {
                    dataGridViewClients.Rows.Add(false, client.id, client.name);
                }
            }
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void comboBoxBuyingsId_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxBuyingsId.Items.Clear();

            foreach (Client client in _cl.GetAllClients())
            {
                comboBoxBuyingsId.Items.Add(client.id);
            }
        }

        private void FillDataGridViewBuyings()
        {
            dataGridViewClients.Rows.Clear();
            foreach (Client client in _cl.GetAllClients())
            {
                if (client.buying.Count != 0)
                {
                    foreach (Client.Buying item in client.buying)
                    {
                        dataGridViewBuyings.Rows.Add(false, client.id, client.name, item.data, item.sum);
                    }
                }
                else
                {
                    dataGridViewBuyings.Rows.Add(false, client.id, client.name, "", "");
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            FillDataGridViewBuyings();
        }
    }
}
