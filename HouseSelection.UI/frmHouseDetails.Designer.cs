namespace HouseSelection.UI
{
    partial class frmHouseDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Block = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Building = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Toward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimateBuiltUpArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimateLivingArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubscriberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubscriberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubscriberStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(780, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(780, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(501, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 21);
            this.textBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HouseID,
            this.SerialNumber,
            this.Group,
            this.Block,
            this.Building,
            this.Unit,
            this.RoomNumber,
            this.Toward,
            this.RoomType,
            this.EstimateBuiltUpArea,
            this.EstimateLivingArea,
            this.AreaUnitPrice,
            this.TotalPrice,
            this.SubscriberID,
            this.SubscriberName,
            this.SubscriberStatus,
            this.Operate});
            this.dataGridView1.Location = new System.Drawing.Point(12, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(861, 428);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // HouseID
            // 
            this.HouseID.DataPropertyName = "HouseID";
            this.HouseID.HeaderText = "房源ID";
            this.HouseID.Name = "HouseID";
            this.HouseID.Visible = false;
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "序号";
            this.SerialNumber.Name = "SerialNumber";
            // 
            // Group
            // 
            this.Group.DataPropertyName = "Group";
            this.Group.HeaderText = "组别";
            this.Group.Name = "Group";
            // 
            // Block
            // 
            this.Block.DataPropertyName = "Block";
            this.Block.HeaderText = "地块";
            this.Block.Name = "Block";
            // 
            // Building
            // 
            this.Building.DataPropertyName = "Building";
            this.Building.HeaderText = "楼号";
            this.Building.Name = "Building";
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "单元";
            this.Unit.Name = "Unit";
            // 
            // RoomNumber
            // 
            this.RoomNumber.DataPropertyName = "RoomNumber";
            this.RoomNumber.HeaderText = "房号";
            this.RoomNumber.Name = "RoomNumber";
            // 
            // Toward
            // 
            this.Toward.DataPropertyName = "Toward";
            this.Toward.HeaderText = "朝向";
            this.Toward.Name = "Toward";
            // 
            // RoomType
            // 
            this.RoomType.DataPropertyName = "RoomType";
            this.RoomType.HeaderText = "居室";
            this.RoomType.Name = "RoomType";
            // 
            // EstimateBuiltUpArea
            // 
            this.EstimateBuiltUpArea.DataPropertyName = "EstimateBuiltUpArea";
            this.EstimateBuiltUpArea.HeaderText = "预测建筑面积";
            this.EstimateBuiltUpArea.Name = "EstimateBuiltUpArea";
            // 
            // EstimateLivingArea
            // 
            this.EstimateLivingArea.DataPropertyName = "EstimateLivingArea";
            this.EstimateLivingArea.HeaderText = "预测套内面积";
            this.EstimateLivingArea.Name = "EstimateLivingArea";
            // 
            // AreaUnitPrice
            // 
            this.AreaUnitPrice.DataPropertyName = "AreaUnitPrice";
            this.AreaUnitPrice.HeaderText = "建筑单价";
            this.AreaUnitPrice.Name = "AreaUnitPrice";
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "总价";
            this.TotalPrice.Name = "TotalPrice";
            // 
            // SubscriberID
            // 
            this.SubscriberID.DataPropertyName = "SubscriberID";
            this.SubscriberID.HeaderText = "认购人ID";
            this.SubscriberID.Name = "SubscriberID";
            // 
            // SubscriberName
            // 
            this.SubscriberName.DataPropertyName = "SubscriberName";
            this.SubscriberName.HeaderText = "认购人姓名";
            this.SubscriberName.Name = "SubscriberName";
            // 
            // SubscriberStatus
            // 
            this.SubscriberStatus.DataPropertyName = "SubscriberStatus";
            this.SubscriberStatus.HeaderText = "认购状态";
            this.SubscriberStatus.Name = "SubscriberStatus";
            // 
            // Operate
            // 
            this.Operate.DataPropertyName = "Operate";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.Operate.DefaultCellStyle = dataGridViewCellStyle1;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            // 
            // frmHouseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 576);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "frmHouseDetails";
            this.Text = "frmHouseDetails";
            this.Load += new System.EventHandler(this.frmHouseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Block;
        private System.Windows.Forms.DataGridViewTextBoxColumn Building;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Toward;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimateBuiltUpArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimateLivingArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubscriberID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubscriberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubscriberStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate;
    }
}