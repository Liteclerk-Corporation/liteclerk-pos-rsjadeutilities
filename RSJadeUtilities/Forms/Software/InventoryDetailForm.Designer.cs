namespace RSJadeUtilities.Forms.Software
{
    partial class InventoryDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryDetailForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBoxTotalQuantity = new System.Windows.Forms.TextBox();
            this.buttonInventoryDetailsPageListFirst = new System.Windows.Forms.Button();
            this.buttonInventoryDetailsPageListPrevious = new System.Windows.Forms.Button();
            this.buttonInventoryDetailsPageListNext = new System.Windows.Forms.Button();
            this.buttonInventoryDetailsPageListLast = new System.Windows.Forms.Button();
            this.textBoxInventoryDetailsPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewInventoryDetails = new System.Windows.Forms.DataGridView();
            this.ColumnReferenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReferenceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.bindingSourceInventoryDetails = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventoryDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInventoryDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.labelTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 56);
            this.panel2.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(217, 35);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Inventory Details";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewInventoryDetails);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.textBoxItemName);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 563);
            this.panel1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.textBoxTotalQuantity);
            this.panel5.Controls.Add(this.buttonInventoryDetailsPageListFirst);
            this.panel5.Controls.Add(this.buttonInventoryDetailsPageListPrevious);
            this.panel5.Controls.Add(this.buttonInventoryDetailsPageListNext);
            this.panel5.Controls.Add(this.buttonInventoryDetailsPageListLast);
            this.panel5.Controls.Add(this.textBoxInventoryDetailsPageNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 510);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(968, 53);
            this.panel5.TabIndex = 31;
            // 
            // textBoxTotalQuantity
            // 
            this.textBoxTotalQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTotalQuantity.BackColor = System.Drawing.Color.White;
            this.textBoxTotalQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTotalQuantity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxTotalQuantity.Location = new System.Drawing.Point(753, 14);
            this.textBoxTotalQuantity.Name = "textBoxTotalQuantity";
            this.textBoxTotalQuantity.ReadOnly = true;
            this.textBoxTotalQuantity.Size = new System.Drawing.Size(203, 27);
            this.textBoxTotalQuantity.TabIndex = 18;
            this.textBoxTotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonInventoryDetailsPageListFirst
            // 
            this.buttonInventoryDetailsPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryDetailsPageListFirst.Enabled = false;
            this.buttonInventoryDetailsPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonInventoryDetailsPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryDetailsPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonInventoryDetailsPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonInventoryDetailsPageListFirst.Name = "buttonInventoryDetailsPageListFirst";
            this.buttonInventoryDetailsPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryDetailsPageListFirst.TabIndex = 13;
            this.buttonInventoryDetailsPageListFirst.Text = "First";
            this.buttonInventoryDetailsPageListFirst.UseVisualStyleBackColor = false;
            this.buttonInventoryDetailsPageListFirst.Click += new System.EventHandler(this.buttonInventoryDetailsPageListFirst_Click);
            // 
            // buttonInventoryDetailsPageListPrevious
            // 
            this.buttonInventoryDetailsPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryDetailsPageListPrevious.Enabled = false;
            this.buttonInventoryDetailsPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonInventoryDetailsPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryDetailsPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonInventoryDetailsPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonInventoryDetailsPageListPrevious.Name = "buttonInventoryDetailsPageListPrevious";
            this.buttonInventoryDetailsPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryDetailsPageListPrevious.TabIndex = 14;
            this.buttonInventoryDetailsPageListPrevious.Text = "Previous";
            this.buttonInventoryDetailsPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonInventoryDetailsPageListPrevious.Click += new System.EventHandler(this.buttonInventoryDetailsPageListPrevious_Click);
            // 
            // buttonInventoryDetailsPageListNext
            // 
            this.buttonInventoryDetailsPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryDetailsPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonInventoryDetailsPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryDetailsPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonInventoryDetailsPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonInventoryDetailsPageListNext.Name = "buttonInventoryDetailsPageListNext";
            this.buttonInventoryDetailsPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryDetailsPageListNext.TabIndex = 15;
            this.buttonInventoryDetailsPageListNext.Text = "Next";
            this.buttonInventoryDetailsPageListNext.UseVisualStyleBackColor = false;
            this.buttonInventoryDetailsPageListNext.Click += new System.EventHandler(this.buttonInventoryDetailsPageListNext_Click);
            // 
            // buttonInventoryDetailsPageListLast
            // 
            this.buttonInventoryDetailsPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInventoryDetailsPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonInventoryDetailsPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInventoryDetailsPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonInventoryDetailsPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonInventoryDetailsPageListLast.Name = "buttonInventoryDetailsPageListLast";
            this.buttonInventoryDetailsPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonInventoryDetailsPageListLast.TabIndex = 16;
            this.buttonInventoryDetailsPageListLast.Text = "Last";
            this.buttonInventoryDetailsPageListLast.UseVisualStyleBackColor = false;
            this.buttonInventoryDetailsPageListLast.Click += new System.EventHandler(this.buttonInventoryDetailsPageListLast_Click);
            // 
            // textBoxInventoryDetailsPageNumber
            // 
            this.textBoxInventoryDetailsPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxInventoryDetailsPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxInventoryDetailsPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInventoryDetailsPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxInventoryDetailsPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxInventoryDetailsPageNumber.Name = "textBoxInventoryDetailsPageNumber";
            this.textBoxInventoryDetailsPageNumber.ReadOnly = true;
            this.textBoxInventoryDetailsPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxInventoryDetailsPageNumber.TabIndex = 17;
            this.textBoxInventoryDetailsPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewInventoryDetails
            // 
            this.dataGridViewInventoryDetails.AllowUserToAddRows = false;
            this.dataGridViewInventoryDetails.AllowUserToDeleteRows = false;
            this.dataGridViewInventoryDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInventoryDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventoryDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReferenceNumber,
            this.ColumnReferenceDate,
            this.ColumnRemarks,
            this.ColumnQuantity,
            this.ColumnSpace});
            this.dataGridViewInventoryDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInventoryDetails.Location = new System.Drawing.Point(0, 38);
            this.dataGridViewInventoryDetails.Name = "dataGridViewInventoryDetails";
            this.dataGridViewInventoryDetails.ReadOnly = true;
            this.dataGridViewInventoryDetails.RowTemplate.Height = 24;
            this.dataGridViewInventoryDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInventoryDetails.Size = new System.Drawing.Size(968, 472);
            this.dataGridViewInventoryDetails.TabIndex = 30;
            // 
            // ColumnReferenceNumber
            // 
            this.ColumnReferenceNumber.DataPropertyName = "ColumnReferenceNumber";
            this.ColumnReferenceNumber.HeaderText = "Reference No.";
            this.ColumnReferenceNumber.Name = "ColumnReferenceNumber";
            this.ColumnReferenceNumber.ReadOnly = true;
            this.ColumnReferenceNumber.Width = 150;
            // 
            // ColumnReferenceDate
            // 
            this.ColumnReferenceDate.DataPropertyName = "ColumnReferenceDate";
            this.ColumnReferenceDate.HeaderText = "Date";
            this.ColumnReferenceDate.Name = "ColumnReferenceDate";
            this.ColumnReferenceDate.ReadOnly = true;
            this.ColumnReferenceDate.Width = 130;
            // 
            // ColumnRemarks
            // 
            this.ColumnRemarks.DataPropertyName = "ColumnRemarks";
            this.ColumnRemarks.HeaderText = "Remarks";
            this.ColumnRemarks.Name = "ColumnRemarks";
            this.ColumnRemarks.ReadOnly = true;
            this.ColumnRemarks.Width = 300;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "ColumnQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnQuantity.HeaderText = "Quantity";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 120;
            // 
            // ColumnSpace
            // 
            this.ColumnSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSpace.DataPropertyName = "ColumnSpace";
            this.ColumnSpace.HeaderText = "";
            this.ColumnSpace.Name = "ColumnSpace";
            this.ColumnSpace.ReadOnly = true;
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.BackColor = System.Drawing.Color.White;
            this.textBoxItemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxItemName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemName.Location = new System.Drawing.Point(0, 0);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.ReadOnly = true;
            this.textBoxItemName.Size = new System.Drawing.Size(968, 38);
            this.textBoxItemName.TabIndex = 32;
            this.textBoxItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(968, 563);
            this.panel3.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(670, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 28);
            this.label2.TabIndex = 19;
            this.label2.Text = "TOTAL:";
            // 
            // InventoryDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(968, 619);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InventoryDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Details";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventoryDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceInventoryDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewInventoryDetails;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonInventoryDetailsPageListFirst;
        private System.Windows.Forms.Button buttonInventoryDetailsPageListPrevious;
        private System.Windows.Forms.Button buttonInventoryDetailsPageListNext;
        private System.Windows.Forms.Button buttonInventoryDetailsPageListLast;
        private System.Windows.Forms.TextBox textBoxInventoryDetailsPageNumber;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReferenceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReferenceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpace;
        private System.Windows.Forms.BindingSource bindingSourceInventoryDetails;
        private System.Windows.Forms.TextBox textBoxTotalQuantity;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
    }
}