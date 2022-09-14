namespace RSJadeUtilities.Forms.Software
{
    partial class UserPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPriceForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonUserPricePageListFirst = new System.Windows.Forms.Button();
            this.buttonUserPricePageListPrevious = new System.Windows.Forms.Button();
            this.buttonUserPricePageListNext = new System.Windows.Forms.Button();
            this.buttonUserPricePageListLast = new System.Windows.Forms.Button();
            this.textBoxUserPricePageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewUserPrice = new System.Windows.Forms.DataGridView();
            this.UserPriceButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UserPriceListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPriceListPriceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceUserPrice = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserPrice)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserPrice)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(977, 700);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.comboBoxUsers);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.dataGridViewUserPrice);
            this.panel4.Controls.Add(this.buttonAdd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(977, 542);
            this.panel4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "User:";
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(12, 32);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(368, 31);
            this.comboBoxUsers.TabIndex = 23;
            this.comboBoxUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsers_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.buttonUserPricePageListFirst);
            this.panel5.Controls.Add(this.buttonUserPricePageListPrevious);
            this.panel5.Controls.Add(this.buttonUserPricePageListNext);
            this.panel5.Controls.Add(this.buttonUserPricePageListLast);
            this.panel5.Controls.Add(this.textBoxUserPricePageNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 489);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(977, 53);
            this.panel5.TabIndex = 22;
            // 
            // buttonUserPricePageListFirst
            // 
            this.buttonUserPricePageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserPricePageListFirst.Enabled = false;
            this.buttonUserPricePageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonUserPricePageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserPricePageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserPricePageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonUserPricePageListFirst.Name = "buttonUserPricePageListFirst";
            this.buttonUserPricePageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonUserPricePageListFirst.TabIndex = 13;
            this.buttonUserPricePageListFirst.Text = "First";
            this.buttonUserPricePageListFirst.UseVisualStyleBackColor = false;
            this.buttonUserPricePageListFirst.Click += new System.EventHandler(this.buttonUserPricePageListFirst_Click);
            // 
            // buttonUserPricePageListPrevious
            // 
            this.buttonUserPricePageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserPricePageListPrevious.Enabled = false;
            this.buttonUserPricePageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonUserPricePageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserPricePageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserPricePageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonUserPricePageListPrevious.Name = "buttonUserPricePageListPrevious";
            this.buttonUserPricePageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonUserPricePageListPrevious.TabIndex = 14;
            this.buttonUserPricePageListPrevious.Text = "Previous";
            this.buttonUserPricePageListPrevious.UseVisualStyleBackColor = false;
            this.buttonUserPricePageListPrevious.Click += new System.EventHandler(this.buttonUserPricePageListPrevious_Click);
            // 
            // buttonUserPricePageListNext
            // 
            this.buttonUserPricePageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserPricePageListNext.FlatAppearance.BorderSize = 0;
            this.buttonUserPricePageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserPricePageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserPricePageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonUserPricePageListNext.Name = "buttonUserPricePageListNext";
            this.buttonUserPricePageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonUserPricePageListNext.TabIndex = 15;
            this.buttonUserPricePageListNext.Text = "Next";
            this.buttonUserPricePageListNext.UseVisualStyleBackColor = false;
            this.buttonUserPricePageListNext.Click += new System.EventHandler(this.buttonUserPricePageListNext_Click);
            // 
            // buttonUserPricePageListLast
            // 
            this.buttonUserPricePageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUserPricePageListLast.FlatAppearance.BorderSize = 0;
            this.buttonUserPricePageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserPricePageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonUserPricePageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonUserPricePageListLast.Name = "buttonUserPricePageListLast";
            this.buttonUserPricePageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonUserPricePageListLast.TabIndex = 16;
            this.buttonUserPricePageListLast.Text = "Last";
            this.buttonUserPricePageListLast.UseVisualStyleBackColor = false;
            this.buttonUserPricePageListLast.Click += new System.EventHandler(this.buttonUserPricePageListLast_Click);
            // 
            // textBoxUserPricePageNumber
            // 
            this.textBoxUserPricePageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxUserPricePageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxUserPricePageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUserPricePageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxUserPricePageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxUserPricePageNumber.Name = "textBoxUserPricePageNumber";
            this.textBoxUserPricePageNumber.ReadOnly = true;
            this.textBoxUserPricePageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxUserPricePageNumber.TabIndex = 17;
            this.textBoxUserPricePageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewUserPrice
            // 
            this.dataGridViewUserPrice.AllowUserToAddRows = false;
            this.dataGridViewUserPrice.AllowUserToDeleteRows = false;
            this.dataGridViewUserPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUserPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUserPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserPriceButtonDelete,
            this.UserPriceListId,
            this.UserPriceListPriceDescription});
            this.dataGridViewUserPrice.Location = new System.Drawing.Point(12, 73);
            this.dataGridViewUserPrice.Name = "dataGridViewUserPrice";
            this.dataGridViewUserPrice.ReadOnly = true;
            this.dataGridViewUserPrice.RowHeadersWidth = 51;
            this.dataGridViewUserPrice.RowTemplate.Height = 24;
            this.dataGridViewUserPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserPrice.Size = new System.Drawing.Size(953, 410);
            this.dataGridViewUserPrice.TabIndex = 8;
            this.dataGridViewUserPrice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUserPrice_CellClick);
            // 
            // UserPriceButtonDelete
            // 
            this.UserPriceButtonDelete.DataPropertyName = "UserPriceButtonDelete";
            this.UserPriceButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserPriceButtonDelete.HeaderText = "Delete";
            this.UserPriceButtonDelete.MinimumWidth = 6;
            this.UserPriceButtonDelete.Name = "UserPriceButtonDelete";
            this.UserPriceButtonDelete.ReadOnly = true;
            this.UserPriceButtonDelete.Width = 125;
            // 
            // UserPriceListId
            // 
            this.UserPriceListId.DataPropertyName = "UserPriceListId";
            this.UserPriceListId.HeaderText = "Id";
            this.UserPriceListId.MinimumWidth = 6;
            this.UserPriceListId.Name = "UserPriceListId";
            this.UserPriceListId.ReadOnly = true;
            this.UserPriceListId.Visible = false;
            this.UserPriceListId.Width = 125;
            // 
            // UserPriceListPriceDescription
            // 
            this.UserPriceListPriceDescription.DataPropertyName = "UserPriceListPriceDescription";
            this.UserPriceListPriceDescription.HeaderText = "Price Description";
            this.UserPriceListPriceDescription.MinimumWidth = 6;
            this.UserPriceListPriceDescription.Name = "UserPriceListPriceDescription";
            this.UserPriceListPriceDescription.ReadOnly = true;
            this.UserPriceListPriceDescription.Width = 350;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(850, 8);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(115, 57);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 598);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(977, 102);
            this.panel3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(116, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Developer: Easyfis Corporation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(116, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Version: 1.202209141645.NOR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(115, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "RS Jade Utilities";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RSJadeUtilities.Properties.Resources.easypos_cropped;
            this.pictureBox1.Location = new System.Drawing.Point(12, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(977, 56);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Price";
            // 
            // UserPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(977, 700);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "UserPriceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Price";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserPriceForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserPrice)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonUserPricePageListFirst;
        private System.Windows.Forms.Button buttonUserPricePageListPrevious;
        private System.Windows.Forms.Button buttonUserPricePageListNext;
        private System.Windows.Forms.Button buttonUserPricePageListLast;
        private System.Windows.Forms.TextBox textBoxUserPricePageNumber;
        private System.Windows.Forms.DataGridView dataGridViewUserPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.BindingSource bindingSourceUserPrice;
        private System.Windows.Forms.DataGridViewButtonColumn UserPriceButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPriceListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPriceListPriceDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}