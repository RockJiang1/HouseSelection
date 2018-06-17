namespace HouseSelection.UI
{
    partial class frmSubscribePersonManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZipCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaritalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResidenceArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(791, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(600, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 21);
            this.textBox1.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(843, 166);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 25);
            this.button3.TabIndex = 13;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ID,
            this.Name,
            this.IdentityNumber,
            this.Telephone,
            this.Address,
            this.ZipCode,
            this.MaritalStatus,
            this.ResidenceArea,
            this.WorkArea,
            this.Operate});
            this.dataGridView1.Location = new System.Drawing.Point(12, 216);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(928, 349);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "序号";
            this.No.Name = "No";
            this.No.Width = 80;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "认购人ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "姓名";
            this.Name.Name = "Name";
            this.Name.Width = 120;
            // 
            // IdentityNumber
            // 
            this.IdentityNumber.DataPropertyName = "IdentityNumber";
            this.IdentityNumber.HeaderText = "身份证";
            this.IdentityNumber.Name = "IdentityNumber";
            this.IdentityNumber.Width = 150;
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "Telephone";
            this.Telephone.HeaderText = "电话号码";
            this.Telephone.Name = "Telephone";
            this.Telephone.Width = 120;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "联系地址";
            this.Address.Name = "Address";
            this.Address.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Address.Width = 300;
            // 
            // ZipCode
            // 
            this.ZipCode.DataPropertyName = "ZipCode";
            this.ZipCode.HeaderText = "邮编";
            this.ZipCode.Name = "ZipCode";
            // 
            // MaritalStatus
            // 
            this.MaritalStatus.DataPropertyName = "MaritalStatus";
            this.MaritalStatus.HeaderText = "婚姻情况";
            this.MaritalStatus.Name = "MaritalStatus";
            // 
            // ResidenceArea
            // 
            this.ResidenceArea.DataPropertyName = "ResidenceArea";
            this.ResidenceArea.HeaderText = "户籍所在区县";
            this.ResidenceArea.Name = "ResidenceArea";
            // 
            // WorkArea
            // 
            this.WorkArea.DataPropertyName = "WorkArea";
            this.WorkArea.HeaderText = "工作所在区县";
            this.WorkArea.Name = "WorkArea";
            // 
            // Operate
            // 
            this.Operate.DataPropertyName = "Operate";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.Operate.DefaultCellStyle = dataGridViewCellStyle1;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            this.Operate.Width = 150;
            // 
            // frmSubscribePersonManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 581);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZipCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaritalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResidenceArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate;
    }
}