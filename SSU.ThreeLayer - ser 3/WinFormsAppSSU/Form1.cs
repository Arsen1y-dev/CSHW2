using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.Common;
using SSU.ThreeLayer.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppSSU
{
    public partial class Form1 : Form
    {
        IClientLogic cl;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cl = DependencyResolver.ClientLogic;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
             if(!Equals(textBoxName.Text, ""))
            {
                cl.AddClient(textBoxName.Text);
            }

            FillDataGridView1();
        }

        private void FillDataGridView1()
        {
            dataGridView1.Rows.Clear();

            foreach (Client client in cl.GetAllClients())
            {
                dataGridView1.Rows.Add(false, client.id, client.name);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                if(Equals(item.Cells["ColumnChecked"].Value, true))
                {
                    cl.DeleteClient((int)item.Cells["ColumnId"].Value);
                }
            }

            FillDataGridView1();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            foreach (Client client in cl.GetAllClients())
            {
                if (client.name.Contains(textBox1.Text))
                {
                    dataGridView1.Rows.Add(false, client.id, client.name);
                }
            }
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            FillDataGridView1();
        }
    }
}
