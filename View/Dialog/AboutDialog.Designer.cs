namespace AnalysisStudio
{
    partial class AboutDialog
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
            this.labelAppVersion = new System.Windows.Forms.Label();
            this.labelLibVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAppVersion
            // 
            this.labelAppVersion.AutoSize = true;
            this.labelAppVersion.Location = new System.Drawing.Point(29, 16);
            this.labelAppVersion.Name = "labelAppVersion";
            this.labelAppVersion.Size = new System.Drawing.Size(120, 16);
            this.labelAppVersion.TabIndex = 0;
            this.labelAppVersion.Text = "应用程序版本 :";
            this.labelAppVersion.Click += new System.EventHandler(this.AboutDialog_Click);
            // 
            // labelLibVersion
            // 
            this.labelLibVersion.AutoSize = true;
            this.labelLibVersion.Location = new System.Drawing.Point(29, 51);
            this.labelLibVersion.Name = "labelLibVersion";
            this.labelLibVersion.Size = new System.Drawing.Size(120, 16);
            this.labelLibVersion.TabIndex = 1;
            this.labelLibVersion.Text = "DockPanel    :";
            this.labelLibVersion.Click += new System.EventHandler(this.AboutDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "作        者 : 沈阳航空航天大学";
            this.label1.Click += new System.EventHandler(this.AboutDialog_Click);
            // 
            // AboutDialog
            // 
            this.ClientSize = new System.Drawing.Size(329, 123);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLibVersion);
            this.Controls.Add(this.labelAppVersion);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutDialog_Load);
            this.Click += new System.EventHandler(this.AboutDialog_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label labelAppVersion;
        private System.Windows.Forms.Label labelLibVersion;
        private System.Windows.Forms.Label label1;
    }
}