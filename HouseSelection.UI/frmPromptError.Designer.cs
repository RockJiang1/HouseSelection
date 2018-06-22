namespace HouseSelection.UI
{
    partial class frmPromptError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromptError));
            this.picPage = new System.Windows.Forms.PictureBox();
            this.picbtnSubOK = new System.Windows.Forms.PictureBox();
            this.picbtnMainOK = new System.Windows.Forms.PictureBox();
            this.lblPrompt = new CCWin.SkinControl.SkinLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnSubOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnMainOK)).BeginInit();
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
            // picbtnSubOK
            // 
            this.picbtnSubOK.Image = ((System.Drawing.Image)(resources.GetObject("picbtnSubOK.Image")));
            this.picbtnSubOK.Location = new System.Drawing.Point(197, 237);
            this.picbtnSubOK.Name = "picbtnSubOK";
            this.picbtnSubOK.Size = new System.Drawing.Size(91, 43);
            this.picbtnSubOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbtnSubOK.TabIndex = 4;
            this.picbtnSubOK.TabStop = false;
            this.picbtnSubOK.Click += new System.EventHandler(this.picbtnSubOK_Click);
            // 
            // picbtnMainOK
            // 
            this.picbtnMainOK.Image = ((System.Drawing.Image)(resources.GetObject("picbtnMainOK.Image")));
            this.picbtnMainOK.Location = new System.Drawing.Point(197, 237);
            this.picbtnMainOK.Name = "picbtnMainOK";
            this.picbtnMainOK.Size = new System.Drawing.Size(91, 43);
            this.picbtnMainOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbtnMainOK.TabIndex = 3;
            this.picbtnMainOK.TabStop = false;
            this.picbtnMainOK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbtnMainOK_MouseMove);
            // 
            // lblPrompt
            // 
            this.lblPrompt.BackColor = System.Drawing.Color.White;
            this.lblPrompt.BorderColor = System.Drawing.Color.White;
            this.lblPrompt.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrompt.Location = new System.Drawing.Point(61, 194);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(357, 27);
            this.lblPrompt.TabIndex = 5;
            this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPromptError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 300);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.picbtnSubOK);
            this.Controls.Add(this.picbtnMainOK);
            this.Controls.Add(this.picPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPromptError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnSubOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbtnMainOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPage;
        private System.Windows.Forms.PictureBox picbtnSubOK;
        private System.Windows.Forms.PictureBox picbtnMainOK;
        private CCWin.SkinControl.SkinLabel lblPrompt;
    }
}