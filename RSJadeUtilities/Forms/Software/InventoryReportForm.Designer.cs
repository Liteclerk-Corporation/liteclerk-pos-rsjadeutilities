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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryReportForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonInventoryReportPageListFirst = new System.Windows.Forms.Button();
            this.buttonInventoryReportPageListPrevious = new System.Windows.Forms.Button();
            this.buttonInventoryReportPageListNext = new System.Windows.Forms.Button();
            this.buttonInventoryReportPageListLast = new System.Windows.Forms.Button();
            this.textBoxInventoryReportPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewInventoryReport = new System.Windows.Forms.DataGridView();
            this.buttonCSV = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerDateStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerDateEnd = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventoryReport)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1289, 740);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.dateTimePickerDateEnd);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dateTimePickerDateStart);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.comboBoxSupplier);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.dataGridViewInventoryReport);
            this.panel4.Controls.Add(this.buttonCSV);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1289, 611);
            this.panel4.TabIndex = 6;
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
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(12, 32);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(222, 31);
            this.comboBoxSupplier.TabIndex = 23;
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
            this.panel5.Location = new System.Drawing.Point(0, 558);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1289, 53);
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
            // dataGridViewInventoryReport
            // 
            this.dataGridViewInventoryReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInventoryReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInventoryReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventoryReport.Location = new System.Drawing.Point(12, 73);
            this.dataGridViewInventoryReport.Name = "dataGridViewInventoryReport";
            this.dataGridViewInventoryReport.RowTemplate.Height = 24;
            this.dataGridViewInventoryReport.Size = new System.Drawing.Size(1265, 479);
            this.dataGridViewInventoryReport.TabIndex = 8;
            // 
            // buttonCSV
            // 
            this.buttonCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCSV.Location = new System.Drawing.Point(1162, 8);
            this.buttonCSV.Name = "buttonCSV";
            this.buttonCSV.Size = new System.Drawing.Size(115, 57);
            this.buttonCSV.TabIndex = 7;
            this.buttonCSV.Text = "CSV";
            this.buttonCSV.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 667);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1289, 73);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1289, 56);
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
            // dateTimePickerDateStart
            // 
            this.dateTimePickerDateStart.Location = new System.Drawing.Point(240, 32);
            this.dateTimePickerDateStart.Name = "dateTimePickerDateStart";
            this.dateTimePickerDateStart.Size = new System.Drawing.Size(200, 30);
            this.dateTimePickerDateStart.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Date Start:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Date End:";
            // 
            // dateTimePickerDateEnd
            // 
            this.dateTimePickerDateEnd.Location = new System.Drawing.Point(446, 32);
            this.dateTimePickerDateEnd.Name = "dateTimePickerDateEnd";
            this.dateTimePickerDateEnd.Size = new System.Drawing.Size(200, 30);
            this.dateTimePickerDateEnd.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RSJadeUtilities.Properties.Resources.easypos_cropped;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // InventoryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1289, 740);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InventoryReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventoryReportForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventoryReport)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewInventoryReport;
        private System.Windows.Forms.Button buttonCSV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}