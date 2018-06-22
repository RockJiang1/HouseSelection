namespace HouseSelection.UI
{
    partial class FrmPromptWarning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPromptWarning));
            this.picPage = new System.Windows.Forms.PictureBox();
            this.picbtnSubCancel = new System.Windows.Forms.PictureBox();
            this.picbtnMainCancel = new System.Windows.Forms.PictureBox();
            this.picbtnSubYes = new System.Windows.Forms.PictureBox();
            this.picbtnMainYes = new System.Windows.Forms.PictureBox();
            this.lblPrompt = new CCWin.SkinControl.SkinLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnSubCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnMainCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnSubYes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnMainYes)).BeginInit();
            this.SuspendLayout();
            // 
            // picPage
            // 
            this.picPage.Image = ((System.Drawing.Image)(resources.GetObject("picPage.Image")));
            this.picPage.Location = new System.Drawing.Point(0, 0);
            this.picPage.Name = "picPage";
            this.picPage.Size = new System.Drawing.Size(480, 300);
            this.picPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPage.TabIndex = 0;
            this.picPage.TabStop = false;
            this.picPage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPage_MouseMove);
            // 
            // picbtnSubCancel
            // 
            this.picbtnSubCancel.Image = ((System.Drawing.Image)(resources.GetObject("picbtnSubCancel.Image")));
            this.picbtnSubCancel.Location = new System.Drawing.Point(109, 228);
            this.picbtnSubCancel.Name = "picbtnSubCancel";
            this.picbtnSubCancel.Size = new System.Drawing.Size(97, 42);
            this.picbtnSubCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbtnSubCancel.TabIndex = 1;
            this.picbtnSubCancel.TabStop = false;
            this.picbtnSubCancel.Click += new System.EventHandler(this.picbtnSubCancel_Click);
            // 
            // picbtnMainCancel
            // 
            this.picbtnMainCancel.Image = ((System.Drawing.Image)(resources.GetObject("picbtnMainCancel.Image")));
            this.picbtnMainCancel.Location = new System.Drawing.Point(109, 228);
            this.picbtnMainCancel.Name = "picbtnMainCancel";
            this.picbtnMainCancel.Size = new System.Drawing.Size(97, 42);
            this.picbtnMainCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbtnMainCancel.TabIndex = 2;
            this.picbtnMainCancel.TabStop = false;
            this.picbtnMainCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbtnMainCancel_MouseMove);
            // 
            // picbtnSubYes
            // 
            this.picbtnSubYes.Image = ((System.Drawing.Image)(resources.GetObject("picbtnSubYes.Image")));
            this.picbtnSubYes.Location = new System.Drawing.Point(212, 228);
            this.picbtnSubYes.Name = "picbtnSubYes";
            this.picbtnSubYes.Size = new System.Drawing.Size(161, 42);
            this.picbtnSubYes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbtnSubYes.TabIndex = 3;
            this.picbtnSubYes.TabStop = false;
            this.picbtnSubYes.Click += new System.EventHandler(this.picbtnSubYes_Click);
            // 
            // picbtnMainYes
            // 
            this.picbtnMainYes.Image = ((System.Drawing.Image)(resources.GetObject("picbtnMainYes.Image")));
            this.picbtnMainYes.Location = new System.Drawing.Point(212, 228);
            this.picbtnMainYes.Name = "picbtnMainYes";
            this.picbtnMainYes.Size = new System.Drawing.Size(161, 42);
            this.picbtnMainYes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbtnMainYes.TabIndex = 4;
            this.picbtnMainYes.TabStop = false;
            this.picbtnMainYes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbtnMainYes_MouseMove);
            // 
            // lblPrompt
            // 
            this.lblPrompt.BackColor = System.Drawing.Color.White;
            this.lblPrompt.BorderColor = System.Drawing.Color.White;
            this.lblPrompt.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrompt.Location = new System.Drawing.Point(56, 182);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(373, 31);
            this.lblPrompt.TabIndex = 5;
            this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPromptWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 300);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.picbtnMainYes);
            this.Controls.Add(this.picbtnSubYes);
            this.Controls.Add(this.picbtnMainCancel);
            this.Controls.Add(this.picbtnSubCancel);
            this.Controls.Add(this.picPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPromptWarning";
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnSubCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnMainCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnSubYes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnMainYes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPage;
        private System.Windows.Forms.PictureBox picbtnSubCancel;
        private System.Windows.Forms.PictureBox picbtnMainCancel;
        private System.Windows.Forms.PictureBox picbtnSubYes;
        private System.Windows.Forms.PictureBox picbtnMainYes;
        private CCWin.SkinControl.SkinLabel lblPrompt;
    }
}