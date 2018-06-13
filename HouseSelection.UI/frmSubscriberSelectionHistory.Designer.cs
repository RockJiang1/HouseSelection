namespace HouseSelection.UI
{
    partial class frmSubscriberSelectionHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoticeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectionStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShakingResultID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectID,
            this.ProjectNumber,
            this.ProjectName,
            this.NoticeStatus,
            this.AuthStatus,
            this.SelectionStatus,
            this.ConfirmStatus,
            this.ShakingResultID,
            this.Operate1,
            this.Operate2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(959, 431);
            this.dataGridView1.TabIndex = 3;
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
            // NoticeStatus
            // 
            this.NoticeStatus.DataPropertyName = "NoticeStatus";
            this.NoticeStatus.HeaderText = "通知状态";
            this.NoticeStatus.Name = "NoticeStatus";
            // 
            // AuthStatus
            // 
            this.AuthStatus.DataPropertyName = "AuthStatus";
            this.AuthStatus.HeaderText = "验证状态";
            this.AuthStatus.Name = "AuthStatus";
            // 
            // SelectionStatus
            // 
            this.SelectionStatus.DataPropertyName = "SelectionStatus";
            this.SelectionStatus.HeaderText = "选房状态";
            this.SelectionStatus.Name = "SelectionStatus";
            // 
            // ConfirmStatus
            // 
            this.ConfirmStatus.DataPropertyName = "ConfirmStatus";
            this.ConfirmStatus.HeaderText = "确认状态";
            this.ConfirmStatus.Name = "ConfirmStatus";
            // 
            // ShakingResultID
            // 
            this.ShakingResultID.DataPropertyName = "ShakingResultID";
            this.ShakingResultID.HeaderText = "摇号结果ID";
            this.ShakingResultID.Name = "ShakingResultID";
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
            // frmSubscriberSelectionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 649);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSubscriberSelectionHistory";
            this.Text = "frmSubscriberSelectionHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoticeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShakingResultID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate2;
    }
}