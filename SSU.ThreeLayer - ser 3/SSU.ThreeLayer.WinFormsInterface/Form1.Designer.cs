namespace SSU.ThreeLayer.WinFormsInterface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPageClients = new TabPage();
            buttonClearSearch = new Button();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            textBoxName = new TextBox();
            buttonDeleteCllients = new Button();
            buttonAddClient = new Button();
            groupBoxFilters = new GroupBox();
            dataGridViewClients = new DataGridView();
            ColumnChecked = new DataGridViewCheckBoxColumn();
            ColumnId = new DataGridViewTextBoxColumn();
            ColumnName = new DataGridViewTextBoxColumn();
            tabPageBuyings = new TabPage();
            numericUpDown1 = new NumericUpDown();
            dateTimePicker1 = new DateTimePicker();
            comboBoxBuyingsId = new ComboBox();
            button2 = new Button();
            groupBox1 = new GroupBox();
            dataGridViewBuyings = new DataGridView();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            ColumnDate = new DataGridViewTextBoxColumn();
            ColumnSum = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).BeginInit();
            tabPageBuyings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBuyings).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageClients);
            tabControl1.Controls.Add(tabPageBuyings);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(767, 426);
            tabControl1.TabIndex = 0;
            // 
            // tabPageClients
            // 
            tabPageClients.Controls.Add(buttonClearSearch);
            tabPageClients.Controls.Add(textBoxSearch);
            tabPageClients.Controls.Add(buttonSearch);
            tabPageClients.Controls.Add(textBoxName);
            tabPageClients.Controls.Add(buttonDeleteCllients);
            tabPageClients.Controls.Add(buttonAddClient);
            tabPageClients.Controls.Add(groupBoxFilters);
            tabPageClients.Controls.Add(dataGridViewClients);
            tabPageClients.Location = new Point(4, 24);
            tabPageClients.Name = "tabPageClients";
            tabPageClients.Padding = new Padding(3);
            tabPageClients.Size = new Size(759, 398);
            tabPageClients.TabIndex = 0;
            tabPageClients.Text = "Clients";
            tabPageClients.UseVisualStyleBackColor = true;
            // 
            // buttonClearSearch
            // 
            buttonClearSearch.Location = new Point(451, 6);
            buttonClearSearch.Name = "buttonClearSearch";
            buttonClearSearch.Size = new Size(75, 23);
            buttonClearSearch.TabIndex = 7;
            buttonClearSearch.Text = "Clear";
            buttonClearSearch.UseVisualStyleBackColor = true;
            buttonClearSearch.Click += buttonClearSearch_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(370, 35);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Name";
            textBoxSearch.Size = new Size(156, 23);
            textBoxSearch.TabIndex = 6;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(370, 6);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(6, 35);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Name";
            textBoxName.Size = new Size(156, 23);
            textBoxName.TabIndex = 4;
            // 
            // buttonDeleteCllients
            // 
            buttonDeleteCllients.Location = new Point(87, 6);
            buttonDeleteCllients.Name = "buttonDeleteCllients";
            buttonDeleteCllients.Size = new Size(75, 23);
            buttonDeleteCllients.TabIndex = 3;
            buttonDeleteCllients.Text = "Delete";
            buttonDeleteCllients.UseVisualStyleBackColor = true;
            buttonDeleteCllients.Click += buttonDeleteCllients_Click;
            // 
            // buttonAddClient
            // 
            buttonAddClient.Location = new Point(6, 6);
            buttonAddClient.Name = "buttonAddClient";
            buttonAddClient.Size = new Size(75, 23);
            buttonAddClient.TabIndex = 2;
            buttonAddClient.Text = "Add";
            buttonAddClient.UseVisualStyleBackColor = true;
            buttonAddClient.Click += buttonAddClient_Click;
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Location = new Point(532, 92);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Size = new Size(221, 300);
            groupBoxFilters.TabIndex = 1;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filters";
            // 
            // dataGridViewClients
            // 
            dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClients.Columns.AddRange(new DataGridViewColumn[] { ColumnChecked, ColumnId, ColumnName });
            dataGridViewClients.Location = new Point(6, 92);
            dataGridViewClients.Name = "dataGridViewClients";
            dataGridViewClients.Size = new Size(520, 300);
            dataGridViewClients.TabIndex = 0;
            // 
            // ColumnChecked
            // 
            ColumnChecked.HeaderText = "";
            ColumnChecked.Name = "ColumnChecked";
            ColumnChecked.Resizable = DataGridViewTriState.True;
            ColumnChecked.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnId
            // 
            ColumnId.HeaderText = "Id";
            ColumnId.Name = "ColumnId";
            ColumnId.ReadOnly = true;
            // 
            // ColumnName
            // 
            ColumnName.HeaderText = "Name";
            ColumnName.Name = "ColumnName";
            ColumnName.ReadOnly = true;
            // 
            // tabPageBuyings
            // 
            tabPageBuyings.Controls.Add(numericUpDown1);
            tabPageBuyings.Controls.Add(dateTimePicker1);
            tabPageBuyings.Controls.Add(comboBoxBuyingsId);
            tabPageBuyings.Controls.Add(button2);
            tabPageBuyings.Controls.Add(groupBox1);
            tabPageBuyings.Controls.Add(dataGridViewBuyings);
            tabPageBuyings.Location = new Point(4, 24);
            tabPageBuyings.Name = "tabPageBuyings";
            tabPageBuyings.Padding = new Padding(3);
            tabPageBuyings.Size = new Size(759, 398);
            tabPageBuyings.TabIndex = 1;
            tabPageBuyings.Text = "Buyings";
            tabPageBuyings.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(293, 35);
            numericUpDown1.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(87, 35);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // comboBoxBuyingsId
            // 
            comboBoxBuyingsId.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBuyingsId.FormattingEnabled = true;
            comboBoxBuyingsId.Items.AddRange(new object[] { "213", "321", "312" });
            comboBoxBuyingsId.Location = new Point(6, 35);
            comboBoxBuyingsId.Name = "comboBoxBuyingsId";
            comboBoxBuyingsId.Size = new Size(75, 23);
            comboBoxBuyingsId.TabIndex = 8;
            comboBoxBuyingsId.MouseClick += comboBoxBuyingsId_MouseClick;
            // 
            // button2
            // 
            button2.Location = new Point(6, 6);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(532, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(221, 300);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filters";
            // 
            // dataGridViewBuyings
            // 
            dataGridViewBuyings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBuyings.Columns.AddRange(new DataGridViewColumn[] { dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, ColumnDate, ColumnSum });
            dataGridViewBuyings.Location = new Point(6, 92);
            dataGridViewBuyings.Name = "dataGridViewBuyings";
            dataGridViewBuyings.Size = new Size(520, 300);
            dataGridViewBuyings.TabIndex = 5;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.HeaderText = "";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewCheckBoxColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Name";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // ColumnDate
            // 
            ColumnDate.HeaderText = "Date";
            ColumnDate.Name = "ColumnDate";
            ColumnDate.ReadOnly = true;
            // 
            // ColumnSum
            // 
            ColumnSum.HeaderText = "Sum";
            ColumnSum.Name = "ColumnSum";
            ColumnSum.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "ShopApp";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPageClients.ResumeLayout(false);
            tabPageClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).EndInit();
            tabPageBuyings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBuyings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageClients;
        private Button buttonDeleteCllients;
        private Button buttonAddClient;
        private GroupBox groupBoxFilters;
        private DataGridView dataGridViewClients;
        private TabPage tabPageBuyings;
        private TextBox textBoxName;
        private DataGridViewCheckBoxColumn ColumnChecked;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnName;
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private Button buttonClearSearch;
        private Button button2;
        private GroupBox groupBox1;
        private DataGridView dataGridViewBuyings;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnSum;
        private ComboBox comboBoxBuyingsId;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown1;
    }
}
