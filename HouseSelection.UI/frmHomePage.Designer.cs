namespace HouseSelection.UI
{
    partial class frmHomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHomePage));
            this.picHomePage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHomePage)).BeginInit();
            this.SuspendLayout();
            // 
            // picHomePage
            // 
            this.picHomePage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picHomePage.Image = ((System.Drawing.Image)(resources.GetObject("picHomePage.Image")));
            this.picHomePage.Location = new System.Drawing.Point(1, 1);
            this.picHomePage.Name = "picHomePage";
            this.picHomePage.Size = new System.Drawing.Size(1022, 625);
            this.picHomePage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHomePage.TabIndex = 0;
            this.picHomePage.TabStop = false;
            this.picHomePage.SizeChanged += new System.EventHandler(this.picHomePage_SizeChanged);
            this.picHomePage.Resize += new System.EventHandler(this.picHomePage_Resize);
            // 
            // frmHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 627);
            this.Controls.Add(this.picHomePage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHomePage";
            this.Text = "frmHomePage";
            ((System.ComponentModel.ISupportInitialize)(this.picHomePage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picHomePage;
    }
}