﻿namespace HouseSelection.UI
{
    partial class frmSelectTimePeriodManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectGpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(736, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(571, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(298, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectID,
            this.ProjectNumber,
            this.ProjectName,
            this.ProjectGpId,
            this.ProjectGroupName,
            this.Operate1,
            this.Operate2,
            this.Operate3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 155);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(892, 448);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ProjectID
            // 
            this.ProjectID.DataPropertyName = "ProjectID";
            this.ProjectID.HeaderText = "项目ID";
            this.ProjectID.Name = "ProjectID";
            // 
            // ProjectNumber
            // 
            this.ProjectNumber.DataPropertyName = "ProjectNumber";
            this.ProjectNumber.HeaderText = "项目编号";
            this.ProjectNumber.Name = "ProjectNumber";
            // 
            // ProjectName
            // 
            this.ProjectName.DataPropertyName = "ProjectName";
            this.ProjectName.HeaderText = "项目名称";
            this.ProjectName.Name = "ProjectName";
            // 
            // ProjectGpId
            // 
            this.ProjectGpId.DataPropertyName = "ProjectGroupID";
            this.ProjectGpId.HeaderText = "项目分组ID";
            this.ProjectGpId.Name = "ProjectGpId";
            // 
            // ProjectGroupName
            // 
            this.ProjectGroupName.DataPropertyName = "ProjectGroupName";
            this.ProjectGroupName.HeaderText = "项目分组名称";
            this.ProjectGroupName.Name = "ProjectGroupName";
            // 
            // Operate1
            // 
            this.Operate1.DataPropertyName = "Operate1";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.Operate1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Operate1.HeaderText = "创建时段";
            this.Operate1.Name = "Operate1";
            // 
            // Operate2
            // 
            this.Operate2.DataPropertyName = "Operate2";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            this.Operate2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Operate2.HeaderText = "修改时段";
            this.Operate2.Name = "Operate2";
            // 
            // Operate3
            // 
            this.Operate3.DataPropertyName = "Operate3";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
            this.Operate3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Operate3.HeaderText = "查看详情";
            this.Operate3.Name = "Operate3";
            // 
            // frmSelectTimePeriodManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 615);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "frmSelectTimePeriodManagement";
            this.Text = "frmSelectTimePeriodManagement";
            this.Load += new System.EventHandler(this.frmSelectTimePeriodManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectGpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate3;
    }
}