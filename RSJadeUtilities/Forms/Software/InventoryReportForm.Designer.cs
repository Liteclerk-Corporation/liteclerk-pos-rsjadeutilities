namespace RSJadeUtilities.Forms.Software
{
    partial class InventoryReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryReportForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonGet = new System.Windows.Forms.Button();
            this.dataGridViewInventoryReport = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCSV = new System.Windows.Forms.Button();
            this.dateTimePickerDateStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonInventoryReportPageListFirst = new System.Windows.Forms.Button();
            this.buttonInventoryReportPageListPrevious = new System.Windows.Forms.Button();
            this.buttonInventoryReportPageListNext = new System.Windows.Forms.Button();
            this.buttonInventoryReportPageListLast = new System.Windows.Forms.Button();
            this.textBoxInventoryReportPageNumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceInventoryReport = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialogGenerateCSV = new System.Windows.Forms.FolderBrowserDialog();
            this.InventoryReportListSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryReportListItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryReportListBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryReportListItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryReportListBeginningQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryReportListInQuantity = new System.Windows.Forms.DataGridViewLinkColumn();
            this.InventoryReportListReturnQuantity = new System.Windows.Forms.DataGridViewLinkColumn();
            this.InventoryReportListSoldQuantity = new System.Windows.Forms.DataGridViewLinkColumn();
            this.InventoryReportListOutQuantity = new System.Windows.Forms.DataGridViewLinkColumn();
            this.InventoryReportListEndingQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryReportListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryReportListCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryReportListAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventoryReport)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInventoryReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1455, 799);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonGet);
            this.panel4.Controls.Add(this.dataGridViewInventoryReport);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.dateTimePickerDateEnd);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.buttonCSV);
            this.panel4.Controls.Add(this.dateTimePickerDateStart);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.comboBoxSupplier);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1455, 641);
            this.panel4.TabIndex = 6;
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(714, 31);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(132, 33);
            this.buttonGet.TabIndex = 30;
            this.buttonGet.Text = "Get";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // dataGridViewInventoryReport
            // 
            this.dataGridViewInventoryReport.AllowUserToAddRows = false;
            this.dataGridViewInventoryReport.AllowUserToDeleteRows = false;
            this.dataGridViewInventoryReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInventoryReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInventoryReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventoryReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryReportListSupplier,
            this.InventoryReportListItemId,
            this.InventoryReportListBarcode,
            this.InventoryReportListItemDescription,
            this.InventoryReportListBeginningQuantity,
            this.InventoryReportListInQuantity,
            this.InventoryReportListReturnQuantity,
            this.InventoryReportListSoldQuantity,
            this.InventoryReportListOutQuantity,
            this.InventoryReportListEndingQuantity,
            this.InventoryReportListUnit,
            this.InventoryReportListCost,
            this.InventoryReportListAmount});
            this.dataGridViewInventoryReport.Location = new System.Drawing.Point(12, 69);
            this.dataGridViewInventoryReport.Name = "dataGridViewInventoryReport";
            this.dataGridViewInventoryReport.ReadOnly = true;
            this.dataGridViewInventoryReport.RowTemplate.Height = 24;
            this.dataGridViewInventoryReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInventoryReport.Size = new System.Drawing.Size(1431, 513);
            this.dataGridViewInventoryReport.TabIndex = 29;
            this.dataGridViewInventoryReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventoryReport_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Date End:";
            // 
            // dateTimePickerDateEnd
            // 
            this.dateTimePickerDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateEnd.Location = new System.Drawing.Point(575, 32);
            this.dateTimePickerDateEnd.Name = "dateTimePickerDateEnd";
            this.dateTimePickerDateEnd.Size = new System.Drawing.Size(133, 30);
            this.dateTimePickerDateEnd.TabIndex = 27;
            this.dateTimePickerDateEnd.ValueChanged += new System.EventHandler(this.dateTimePickerDateEnd_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Date Start:";
            // 
            // buttonCSV
            // 
            this.buttonCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCSV.Location = new System.Drawing.Point(1328, 30);
            this.buttonCSV.Name = "buttonCSV";
            this.buttonCSV.Size = new System.Drawing.Size(115, 33);
            this.buttonCSV.TabIndex = 7;
            this.buttonCSV.Text = "CSV";
            this.buttonCSV.UseVisualStyleBackColor = true;
            this.buttonCSV.Click += new System.EventHandler(this.buttonCSV_Click);
            // 
            // dateTimePickerDateStart
            // 
            this.dateTimePickerDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateStart.Location = new System.Drawing.Point(436, 32);
            this.dateTimePickerDateStart.Name = "dateTimePickerDateStart";
            this.dateTimePickerDateStart.Size = new System.Drawing.Size(133, 30);
            this.dateTimePickerDateStart.TabIndex = 25;
            this.dateTimePickerDateStart.ValueChanged += new System.EventHandler(this.dateTimePickerDateStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "Supplier:";
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(12, 32);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(418, 31);
            this.comboBoxSupplier.TabIndex = 23;
            this.comboBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupplier_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.buttonInventoryReportPageListFirst);
            this.panel5.Controls.Add(this.buttonInventoryReportPageListPrevious);
            this.panel5.Controls.Add(this.buttonInventoryReportPageListNext);
            this.panel5.Controls.Add(this.buttonInventoryReportPageListLast);
            this.panel5.Controls.Add(this.textBoxInventoryReportPageNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 588);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1455, 53);
            this.panel5.TabIndex = 22;
            // 
            // buttonInventoryReportPageListFirst
            // 
            this.buttonInventoryReportPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryReportPageListFirst.Enabled = false;
            this.buttonInventoryReportPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReportPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReportPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonInventoryReportPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonInventoryReportPageListFirst.Name = "buttonInventoryReportPageListFirst";
            this.buttonInventoryReportPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryReportPageListFirst.TabIndex = 13;
            this.buttonInventoryReportPageListFirst.Text = "First";
            this.buttonInventoryReportPageListFirst.UseVisualStyleBackColor = false;
            this.buttonInventoryReportPageListFirst.Click += new System.EventHandler(this.buttonInventoryReportPageListFirst_Click);
            // 
            // buttonInventoryReportPageListPrevious
            // 
            this.buttonInventoryReportPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryReportPageListPrevious.Enabled = false;
            this.buttonInventoryReportPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReportPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReportPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonInventoryReportPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonInventoryReportPageListPrevious.Name = "buttonInventoryReportPageListPrevious";
            this.buttonInventoryReportPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryReportPageListPrevious.TabIndex = 14;
            this.buttonInventoryReportPageListPrevious.Text = "Previous";
            this.buttonInventoryReportPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonInventoryReportPageListPrevious.Click += new System.EventHandler(this.buttonInventoryReportPageListPrevious_Click);
            // 
            // buttonInventoryReportPageListNext
            // 
            this.buttonInventoryReportPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryReportPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReportPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReportPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonInventoryReportPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonInventoryReportPageListNext.Name = "buttonInventoryReportPageListNext";
            this.buttonInventoryReportPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryReportPageListNext.TabIndex = 15;
            this.buttonInventoryReportPageListNext.Text = "Next";
            this.buttonInventoryReportPageListNext.UseVisualStyleBackColor = false;
            this.buttonInventoryReportPageListNext.Click += new System.EventHandler(this.buttonInventoryReportPageListNext_Click);
            // 
            // buttonInventoryReportPageListLast
            // 
            this.buttonInventoryReportPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryReportPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonInventoryReportPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryReportPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonInventoryReportPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonInventoryReportPageListLast.Name = "buttonInventoryReportPageListLast";
            this.buttonInventoryReportPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryReportPageListLast.TabIndex = 16;
            this.buttonInventoryReportPageListLast.Text = "Last";
            this.buttonInventoryReportPageListLast.UseVisualStyleBackColor = false;
            this.buttonInventoryReportPageListLast.Click += new System.EventHandler(this.buttonInventoryReportPageListLast_Click);
            // 
            // textBoxInventoryReportPageNumber
            // 
            this.textBoxInventoryReportPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxInventoryReportPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxInventoryReportPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInventoryReportPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxInventoryReportPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxInventoryReportPageNumber.Name = "textBoxInventoryReportPageNumber";
            this.textBoxInventoryReportPageNumber.ReadOnly = true;
            this.textBoxInventoryReportPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxInventoryReportPageNumber.TabIndex = 17;
            this.textBoxInventoryReportPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 697);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1455, 102);
            this.panel3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(116, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Developer: Easyfis Corporation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(116, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Version: 1.20191126.NOR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(115, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "RS Jade Utilities";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RSJadeUtilities.Properties.Resources.easypos_cropped;
            this.pictureBox1.Location = new System.Drawing.Point(12, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1455, 56);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inventory Report";
            // 
            // InventoryReportListSupplier
            // 
            this.InventoryReportListSupplier.DataPropertyName = "InventoryReportListSupplier";
            this.InventoryReportListSupplier.HeaderText = "Supplier";
            this.InventoryReportListSupplier.Name = "InventoryReportListSupplier";
            this.InventoryReportListSupplier.ReadOnly = true;
            this.InventoryReportListSupplier.Width = 150;
            // 
            // InventoryReportListItemId
            // 
            this.InventoryReportListItemId.DataPropertyName = "InventoryReportListItemId";
            this.InventoryReportListItemId.HeaderText = "ItemId";
            this.InventoryReportListItemId.Name = "InventoryReportListItemId";
            this.InventoryReportListItemId.ReadOnly = true;
            this.InventoryReportListItemId.Visible = false;
            // 
            // InventoryReportListBarcode
            // 
            this.InventoryReportListBarcode.DataPropertyName = "InventoryReportListBarcode";
            this.InventoryReportListBarcode.HeaderText = "Barcode";
            this.InventoryReportListBarcode.Name = "InventoryReportListBarcode";
            this.InventoryReportListBarcode.ReadOnly = true;
            // 
            // InventoryReportListItemDescription
            // 
            this.InventoryReportListItemDescription.DataPropertyName = "InventoryReportListItemDescription";
            this.InventoryReportListItemDescription.HeaderText = "Item Description";
            this.InventoryReportListItemDescription.Name = "InventoryReportListItemDescription";
            this.InventoryReportListItemDescription.ReadOnly = true;
            this.InventoryReportListItemDescription.Width = 300;
            // 
            // InventoryReportListBeginningQuantity
            // 
            this.InventoryReportListBeginningQuantity.DataPropertyName = "InventoryReportListBeginningQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InventoryReportListBeginningQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.InventoryReportListBeginningQuantity.HeaderText = "Beg";
            this.InventoryReportListBeginningQuantity.Name = "InventoryReportListBeginningQuantity";
            this.InventoryReportListBeginningQuantity.ReadOnly = true;
            // 
            // InventoryReportListInQuantity
            // 
            this.InventoryReportListInQuantity.DataPropertyName = "InventoryReportListInQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InventoryReportListInQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.InventoryReportListInQuantity.HeaderText = "In";
            this.InventoryReportListInQuantity.Name = "InventoryReportListInQuantity";
            this.InventoryReportListInQuantity.ReadOnly = true;
            this.InventoryReportListInQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryReportListInQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InventoryReportListReturnQuantity
            // 
            this.InventoryReportListReturnQuantity.DataPropertyName = "InventoryReportListReturnQuantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InventoryReportListReturnQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.InventoryReportListReturnQuantity.HeaderText = "Return";
            this.InventoryReportListReturnQuantity.Name = "InventoryReportListReturnQuantity";
            this.InventoryReportListReturnQuantity.ReadOnly = true;
            this.InventoryReportListReturnQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryReportListReturnQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InventoryReportListSoldQuantity
            // 
            this.InventoryReportListSoldQuantity.DataPropertyName = "InventoryReportListSoldQuantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InventoryReportListSoldQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.InventoryReportListSoldQuantity.HeaderText = "Sold";
            this.InventoryReportListSoldQuantity.Name = "InventoryReportListSoldQuantity";
            this.InventoryReportListSoldQuantity.ReadOnly = true;
            this.InventoryReportListSoldQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryReportListSoldQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InventoryReportListOutQuantity
            // 
            this.InventoryReportListOutQuantity.DataPropertyName = "InventoryReportListOutQuantity";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InventoryReportListOutQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.InventoryReportListOutQuantity.HeaderText = "Out";
            this.InventoryReportListOutQuantity.Name = "InventoryReportListOutQuantity";
            this.InventoryReportListOutQuantity.ReadOnly = true;
            this.InventoryReportListOutQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryReportListOutQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InventoryReportListEndingQuantity
            // 
            this.InventoryReportListEndingQuantity.DataPropertyName = "InventoryReportListEndingQuantity";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InventoryReportListEndingQuantity.DefaultCellStyle = dataGridViewCellStyle6;
            this.InventoryReportListEndingQuantity.HeaderText = "End";
            this.InventoryReportListEndingQuantity.Name = "InventoryReportListEndingQuantity";
            this.InventoryReportListEndingQuantity.ReadOnly = true;
            // 
            // InventoryReportListUnit
            // 
            this.InventoryReportListUnit.DataPropertyName = "InventoryReportListUnit";
            this.InventoryReportListUnit.HeaderText = "Unit";
            this.InventoryReportListUnit.Name = "InventoryReportListUnit";
            this.InventoryReportListUnit.ReadOnly = true;
            // 
            // InventoryReportListCost
            // 
            this.InventoryReportListCost.DataPropertyName = "InventoryReportListCost";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InventoryReportListCost.DefaultCellStyle = dataGridViewCellStyle7;
            this.InventoryReportListCost.HeaderText = "Cost";
            this.InventoryReportListCost.Name = "InventoryReportListCost";
            this.InventoryReportListCost.ReadOnly = true;
            // 
            // InventoryReportListAmount
            // 
            this.InventoryReportListAmount.DataPropertyName = "InventoryReportListAmount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InventoryReportListAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.InventoryReportListAmount.HeaderText = "Amount";
            this.InventoryReportListAmount.Name = "InventoryReportListAmount";
            this.InventoryReportListAmount.ReadOnly = true;
            // 
            // InventoryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1455, 799);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventoryReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryReportForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventoryReport)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInventoryReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonInventoryReportPageListFirst;
        private System.Windows.Forms.Button buttonInventoryReportPageListPrevious;
        private System.Windows.Forms.Button buttonInventoryReportPageListNext;
        private System.Windows.Forms.Button buttonInventoryReportPageListLast;
        private System.Windows.Forms.TextBox textBoxInventoryReportPageNumber;
        private System.Windows.Forms.Button buttonCSV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewInventoryReport;
        private System.Windows.Forms.BindingSource bindingSourceInventoryReport;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGenerateCSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListBeginningQuantity;
        private System.Windows.Forms.DataGridViewLinkColumn InventoryReportListInQuantity;
        private System.Windows.Forms.DataGridViewLinkColumn InventoryReportListReturnQuantity;
        private System.Windows.Forms.DataGridViewLinkColumn InventoryReportListSoldQuantity;
        private System.Windows.Forms.DataGridViewLinkColumn InventoryReportListOutQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListEndingQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReportListAmount;
    }
}