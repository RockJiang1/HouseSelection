namespace HouseSelection.UI
{
    partial class frmProjectManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectManagement));
            this.btnProjectAdd = new CCWin.SkinControl.SkinButton();
            this.txtSearch = new CCWin.SkinControl.SkinTextBox();
            this.btnSearch = new CCWin.SkinControl.SkinButton();
            this.lblTitle = new CCWin.SkinControl.SkinLabel();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.dgvDataSource = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevelopCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPageSize = new System.Windows.Forms.Panel();
            this.txtSearchPage = new System.Windows.Forms.TextBox();
            this.lblCurPage = new CCWin.SkinControl.SkinLabel();
            this.lblSumPage = new CCWin.SkinControl.SkinLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picRefreshC = new System.Windows.Forms.PictureBox();
            this.picnextPageC = new System.Windows.Forms.PictureBox();
            this.picnextPageB = new System.Windows.Forms.PictureBox();
            this.picprePageC = new System.Windows.Forms.PictureBox();
            this.picprePageB = new System.Windows.Forms.PictureBox();
            this.picRefreshB = new System.Windows.Forms.PictureBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.picnextPageA = new System.Windows.Forms.PictureBox();
            this.picprePageA = new System.Windows.Forms.PictureBox();
            this.cbPage = new CCWin.SkinControl.SkinComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSource)).BeginInit();
            this.pnlPageSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picnextPageC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picnextPageB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picprePageC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picprePageB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picnextPageA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picprePageA)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProjectAdd
            // 
            this.btnProjectAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnProjectAdd.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProjectAdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProjectAdd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnProjectAdd.DownBack = null;
            this.btnProjectAdd.DownBaseColor = System.Drawing.Color.Gray;
            this.btnProjectAdd.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProjectAdd.GlowColor = System.Drawing.Color.Gray;
            this.btnProjectAdd.Location = new System.Drawing.Point(10, 80);
            this.btnProjectAdd.MouseBack = null;
            this.btnProjectAdd.MouseBaseColor = System.Drawing.Color.Silver;
            this.btnProjectAdd.Name = "btnProjectAdd";
            this.btnProjectAdd.NormlBack = null;
            this.btnProjectAdd.Size = new System.Drawing.Size(115, 30);
            this.btnProjectAdd.TabIndex = 5;
            this.btnProjectAdd.Text = "添加项目";
            this.btnProjectAdd.UseVisualStyleBackColor = false;
            this.btnProjectAdd.Click += new System.EventHandler(this.btnProjectAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.DownBack = null;
            this.txtSearch.Icon = null;
            this.txtSearch.IconIsButton = false;
            this.txtSearch.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSearch.IsPasswordChat = '\0';
            this.txtSearch.IsSystemPasswordChar = false;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(610, 80);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSearch.MouseBack = null;
            this.txtSearch.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NormlBack = null;
            this.txtSearch.Padding = new System.Windows.Forms.Padding(5);
            this.txtSearch.ReadOnly = false;
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.Size = new System.Drawing.Size(192, 30);
            // 
            // 
            // 
            this.txtSearch.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.SkinTxt.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.txtSearch.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSearch.SkinTxt.Multiline = true;
            this.txtSearch.SkinTxt.Name = "BaseText";
            this.txtSearch.SkinTxt.Size = new System.Drawing.Size(182, 20);
            this.txtSearch.SkinTxt.TabIndex = 0;
            this.txtSearch.SkinTxt.WaterColor = System.Drawing.Color.Silver;
            this.txtSearch.SkinTxt.WaterText = "";
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.WaterColor = System.Drawing.Color.Silver;
            this.txtSearch.WaterText = "";
            this.txtSearch.WordWrap = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSearch.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSearch.DownBack = null;
            this.btnSearch.DownBaseColor = System.Drawing.Color.Gray;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.GlowColor = System.Drawing.Color.Gray;
            this.btnSearch.Location = new System.Drawing.Point(805, 80);
            this.btnSearch.MouseBack = null;
            this.btnSearch.MouseBaseColor = System.Drawing.Color.Silver;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NormlBack = null;
            this.btnSearch.Size = new System.Drawing.Size(109, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BorderColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(74, 21);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "项目管理";
            // 
            // skinLine1
            // 
            this.skinLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.skinLine1.LineHeight = 2;
            this.skinLine1.Location = new System.Drawing.Point(0, 40);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(926, 12);
            this.skinLine1.TabIndex = 12;
            this.skinLine1.Text = "skinLine1";
            // 
            // dgvDataSource
            // 
            this.dgvDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDataSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataSource.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataSource.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.number,
            this.Name,
            this.DevelopCompany,
            this.IdentityNumber,
            this.ProjectArea,
            this.Operate});
            this.dgvDataSource.Location = new System.Drawing.Point(10, 125);
            this.dgvDataSource.Name = "dgvDataSource";
            this.dgvDataSource.RowTemplate.Height = 23;
            this.dgvDataSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataSource.Size = new System.Drawing.Size(904, 358);
            this.dgvDataSource.TabIndex = 14;
            this.dgvDataSource.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataSource_CellContentClick);
            this.dgvDataSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvDataSource_MouseMove);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ID.HeaderText = "项目ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // number
            // 
            this.number.DataPropertyName = "Number";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.number.DefaultCellStyle = dataGridViewCellStyle3;
            this.number.HeaderText = "项目编号";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name.DefaultCellStyle = dataGridViewCellStyle4;
            this.Name.HeaderText = "项目名称";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // DevelopCompany
            // 
            this.DevelopCompany.DataPropertyName = "DevelopCompany";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevelopCompany.DefaultCellStyle = dataGridViewCellStyle5;
            this.DevelopCompany.HeaderText = "开发企业";
            this.DevelopCompany.Name = "DevelopCompany";
            this.DevelopCompany.ReadOnly = true;
            // 
            // IdentityNumber
            // 
            this.IdentityNumber.DataPropertyName = "IdentityNumber";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IdentityNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.IdentityNumber.HeaderText = "预售证号";
            this.IdentityNumber.Name = "IdentityNumber";
            this.IdentityNumber.ReadOnly = true;
            // 
            // ProjectArea
            // 
            this.ProjectArea.DataPropertyName = "ProjectArea";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProjectArea.DefaultCellStyle = dataGridViewCellStyle7;
            this.ProjectArea.HeaderText = "项目所属区";
            this.ProjectArea.Name = "ProjectArea";
            this.ProjectArea.ReadOnly = true;
            // 
            // Operate
            // 
            this.Operate.DataPropertyName = "Operate";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Operate.DefaultCellStyle = dataGridViewCellStyle8;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            this.Operate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // pnlPageSize
            // 
            this.pnlPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPageSize.Controls.Add(this.txtSearchPage);
            this.pnlPageSize.Controls.Add(this.lblCurPage);
            this.pnlPageSize.Controls.Add(this.lblSumPage);
            this.pnlPageSize.Controls.Add(this.pictureBox1);
            this.pnlPageSize.Controls.Add(this.picRefreshC);
            this.pnlPageSize.Controls.Add(this.picnextPageC);
            this.pnlPageSize.Controls.Add(this.picnextPageB);
            this.pnlPageSize.Controls.Add(this.picprePageC);
            this.pnlPageSize.Controls.Add(this.picprePageB);
            this.pnlPageSize.Controls.Add(this.picRefreshB);
            this.pnlPageSize.Controls.Add(this.skinLabel2);
            this.pnlPageSize.Controls.Add(this.pictureBox4);
            this.pnlPageSize.Controls.Add(this.skinLabel1);
            this.pnlPageSize.Controls.Add(this.pictureBox3);
            this.pnlPageSize.Controls.Add(this.picnextPageA);
            this.pnlPageSize.Controls.Add(this.picprePageA);
            this.pnlPageSize.Controls.Add(this.cbPage);
            this.pnlPageSize.Location = new System.Drawing.Point(10, 500);
            this.pnlPageSize.Name = "pnlPageSize";
            this.pnlPageSize.Size = new System.Drawing.Size(904, 37);
            this.pnlPageSize.TabIndex = 15;
            this.pnlPageSize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPageSize_MouseMove);
            // 
            // txtSearchPage
            // 
            this.txtSearchPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchPage.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearchPage.Location = new System.Drawing.Point(775, 10);
            this.txtSearchPage.Name = "txtSearchPage";
            this.txtSearchPage.Size = new System.Drawing.Size(34, 16);
            this.txtSearchPage.TabIndex = 16;
            this.txtSearchPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPage_KeyPress);
            // 
            // lblCurPage
            // 
            this.lblCurPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurPage.BackColor = System.Drawing.Color.Transparent;
            this.lblCurPage.BorderColor = System.Drawing.Color.White;
            this.lblCurPage.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurPage.Location = new System.Drawing.Point(602, 8);
            this.lblCurPage.Name = "lblCurPage";
            this.lblCurPage.Size = new System.Drawing.Size(35, 20);
            this.lblCurPage.TabIndex = 15;
            this.lblCurPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSumPage
            // 
            this.lblSumPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumPage.BackColor = System.Drawing.Color.Transparent;
            this.lblSumPage.BorderColor = System.Drawing.Color.White;
            this.lblSumPage.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSumPage.Location = new System.Drawing.Point(434, 8);
            this.lblSumPage.Name = "lblSumPage";
            this.lblSumPage.Size = new System.Drawing.Size(74, 20);
            this.lblSumPage.TabIndex = 14;
            this.lblSumPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(428, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // picRefreshC
            // 
            this.picRefreshC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picRefreshC.Image = ((System.Drawing.Image)(resources.GetObject("picRefreshC.Image")));
            this.picRefreshC.Location = new System.Drawing.Point(855, 6);
            this.picRefreshC.Name = "picRefreshC";
            this.picRefreshC.Size = new System.Drawing.Size(40, 25);
            this.picRefreshC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRefreshC.TabIndex = 12;
            this.picRefreshC.TabStop = false;
            this.picRefreshC.Click += new System.EventHandler(this.picRefreshC_Click);
            // 
            // picnextPageC
            // 
            this.picnextPageC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picnextPageC.Image = ((System.Drawing.Image)(resources.GetObject("picnextPageC.Image")));
            this.picnextPageC.Location = new System.Drawing.Point(646, 6);
            this.picnextPageC.Name = "picnextPageC";
            this.picnextPageC.Size = new System.Drawing.Size(75, 25);
            this.picnextPageC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picnextPageC.TabIndex = 11;
            this.picnextPageC.TabStop = false;
            this.picnextPageC.Click += new System.EventHandler(this.picnextPageC_Click);
            // 
            // picnextPageB
            // 
            this.picnextPageB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picnextPageB.Image = ((System.Drawing.Image)(resources.GetObject("picnextPageB.Image")));
            this.picnextPageB.Location = new System.Drawing.Point(646, 6);
            this.picnextPageB.Name = "picnextPageB";
            this.picnextPageB.Size = new System.Drawing.Size(75, 25);
            this.picnextPageB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picnextPageB.TabIndex = 10;
            this.picnextPageB.TabStop = false;
            this.picnextPageB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picnextPageB_MouseMove);
            // 
            // picprePageC
            // 
            this.picprePageC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picprePageC.Image = ((System.Drawing.Image)(resources.GetObject("picprePageC.Image")));
            this.picprePageC.Location = new System.Drawing.Point(519, 6);
            this.picprePageC.Name = "picprePageC";
            this.picprePageC.Size = new System.Drawing.Size(75, 25);
            this.picprePageC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picprePageC.TabIndex = 9;
            this.picprePageC.TabStop = false;
            this.picprePageC.Click += new System.EventHandler(this.picprePageC_Click);
            // 
            // picprePageB
            // 
            this.picprePageB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picprePageB.Image = ((System.Drawing.Image)(resources.GetObject("picprePageB.Image")));
            this.picprePageB.Location = new System.Drawing.Point(519, 6);
            this.picprePageB.Name = "picprePageB";
            this.picprePageB.Size = new System.Drawing.Size(75, 25);
            this.picprePageB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picprePageB.TabIndex = 8;
            this.picprePageB.TabStop = false;
            this.picprePageB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picprePageB_MouseMove);
            // 
            // picRefreshB
            // 
            this.picRefreshB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picRefreshB.Image = ((System.Drawing.Image)(resources.GetObject("picRefreshB.Image")));
            this.picRefreshB.Location = new System.Drawing.Point(855, 6);
            this.picRefreshB.Name = "picRefreshB";
            this.picRefreshB.Size = new System.Drawing.Size(40, 25);
            this.picRefreshB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRefreshB.TabIndex = 7;
            this.picRefreshB.TabStop = false;
            this.picRefreshB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picRefreshB_MouseMove);
            // 
            // skinLabel2
            // 
            this.skinLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(821, 3);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(28, 30);
            this.skinLabel2.TabIndex = 6;
            this.skinLabel2.Text = "页";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(772, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // skinLabel1
            // 
            this.skinLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(721, 3);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(49, 30);
            this.skinLabel1.TabIndex = 4;
            this.skinLabel1.Text = "到第";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(600, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // picnextPageA
            // 
            this.picnextPageA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picnextPageA.Image = ((System.Drawing.Image)(resources.GetObject("picnextPageA.Image")));
            this.picnextPageA.Location = new System.Drawing.Point(646, 6);
            this.picnextPageA.Name = "picnextPageA";
            this.picnextPageA.Size = new System.Drawing.Size(75, 25);
            this.picnextPageA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picnextPageA.TabIndex = 2;
            this.picnextPageA.TabStop = false;
            // 
            // picprePageA
            // 
            this.picprePageA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picprePageA.Image = ((System.Drawing.Image)(resources.GetObject("picprePageA.Image")));
            this.picprePageA.Location = new System.Drawing.Point(519, 6);
            this.picprePageA.Name = "picprePageA";
            this.picprePageA.Size = new System.Drawing.Size(75, 25);
            this.picprePageA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picprePageA.TabIndex = 1;
            this.picprePageA.TabStop = false;
            // 
            // cbPage
            // 
            this.cbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPage.BaseColor = System.Drawing.Color.Silver;
            this.cbPage.BorderColor = System.Drawing.Color.Silver;
            this.cbPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPage.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPage.FormattingEnabled = true;
            this.cbPage.Location = new System.Drawing.Point(331, 6);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(90, 24);
            this.cbPage.TabIndex = 0;
            this.cbPage.WaterText = "";
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
            // 
            // frmProjectManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 571);
            this.Controls.Add(this.pnlPageSize);
            this.Controls.Add(this.dgvDataSource);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnProjectAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "frmProjectManagement";
            this.Load += new System.EventHandler(this.frmProjectManagement_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmProjectManagement_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSource)).EndInit();
            this.pnlPageSize.ResumeLayout(false);
            this.pnlPageSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picnextPageC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picnextPageB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picprePageC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picprePageB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picnextPageA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picprePageA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCWin.SkinControl.SkinButton btnProjectAdd;
        private CCWin.SkinControl.SkinTextBox txtSearch;
        private CCWin.SkinControl.SkinButton btnSearch;
        private CCWin.SkinControl.SkinLabel lblTitle;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.DataGridView dgvDataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevelopCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operate;
        private System.Windows.Forms.Panel pnlPageSize;
        private System.Windows.Forms.PictureBox picRefreshB;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox picnextPageA;
        private System.Windows.Forms.PictureBox picprePageA;
        private CCWin.SkinControl.SkinComboBox cbPage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picRefreshC;
        private System.Windows.Forms.PictureBox picnextPageC;
        private System.Windows.Forms.PictureBox picnextPageB;
        private System.Windows.Forms.PictureBox picprePageC;
        private System.Windows.Forms.PictureBox picprePageB;
        private System.Windows.Forms.TextBox txtSearchPage;
        private CCWin.SkinControl.SkinLabel lblCurPage;
        private CCWin.SkinControl.SkinLabel lblSumPage;
    }
}