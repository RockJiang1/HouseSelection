namespace HouseSelection.UI
{
    partial class frmSelectRoleManagement
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevelopCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(745, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(745, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(426, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 21);
            this.textBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.number,
            this.Name,
            this.DevelopCompany,
            this.IdentityNumber,
            this.ProjectArea,
            this.Operate1,
            this.Operate2,
            this.Operate3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(878, 427);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "项目ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // number
            // 
            this.number.DataPropertyName = "number";
            this.number.HeaderText = "项目编号";
            this.number.Name = "number";
            this.number.Width = 150;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "项目名称";
            this.Name.Name = "Name";
            this.Name.Width = 150;
            // 
            // DevelopCompany
            // 
            this.DevelopCompany.DataPropertyName = "DevelopCompany";
            this.DevelopCompany.HeaderText = "开发企业";
            this.DevelopCompany.Name = "DevelopCompany";
            this.DevelopCompany.Width = 300;
            // 
            // IdentityNumber
            // 
            this.IdentityNumber.DataPropertyName = "IdentityNumber";
            this.IdentityNumber.HeaderText = "预售证号";
            this.IdentityNumber.Name = "IdentityNumber";
            // 
            // ProjectArea
            // 
            this.ProjectArea.DataPropertyName = "ProjectArea";
            this.ProjectArea.HeaderText = "项目所属区";
            this.ProjectArea.Name = "ProjectArea";
            this.ProjectArea.Width = 150;
            // 
            // Operate1
            // 
            this.Operate1.DataPropertyName = "Operate1";
            this.Operate1.HeaderText = "操作1";
            this.Operate1.Name = "Operate1";
            // 
            // Operate2
            // 
            this.Operate2.DataPropertyName = "Operate2";
            this.Operate2.HeaderText = "操作2";
            this.Operate2.Name = "Operate2";
            // 
            // Operate3
            // 
            this.Operate3.DataPropertyName = "Operate3";
            this.Operate3.HeaderText = "操作3";
            this.Operate3.Name = "Operate3";
            // 
            // frmSelectRoleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 607);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            //this.Name = "frmSelectRoleManagement";
            //this.Text = "frmSelectRoleManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevelopCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate3;
    }
}