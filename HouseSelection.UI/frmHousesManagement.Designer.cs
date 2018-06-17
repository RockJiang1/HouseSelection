namespace HouseSelection.UI
{
    partial class frmHousesManagement
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
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HouseEstateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseEstateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(843, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(843, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(576, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 21);
            this.textBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HouseEstateID,
            this.ProjectNumber,
            this.ProjectName,
            this.HouseEstateName,
            this.Operate});
            this.dataGridView1.Location = new System.Drawing.Point(12, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(957, 423);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // HouseEstateID
            // 
            this.HouseEstateID.DataPropertyName = "HouseEstateID";
            this.HouseEstateID.HeaderText = "楼盘ID";
            this.HouseEstateID.Name = "HouseEstateID";
            this.HouseEstateID.Visible = false;
            // 
            // ProjectNumber
            // 
            this.ProjectNumber.DataPropertyName = "ProjectNumber";
            this.ProjectNumber.HeaderText = "项目编号";
            this.ProjectNumber.Name = "ProjectNumber";
            this.ProjectNumber.Width = 150;
            // 
            // ProjectName
            // 
            this.ProjectName.DataPropertyName = "ProjectName";
            this.ProjectName.HeaderText = "项目名称";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Width = 200;
            // 
            // HouseEstateName
            // 
            this.HouseEstateName.DataPropertyName = "HouseEstateName";
            this.HouseEstateName.HeaderText = "楼盘名称";
            this.HouseEstateName.Name = "HouseEstateName";
            this.HouseEstateName.Width = 250;
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
            // frmHousesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 617);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmHousesManagement";
            this.Text = "frmHousesManagement";
            this.Load += new System.EventHandler(this.frmHousesManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseEstateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseEstateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate;
    }
}