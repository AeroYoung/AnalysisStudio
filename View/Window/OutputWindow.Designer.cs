namespace AnalysisStudio
{
    partial class OutputWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputWindow));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._box = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.���ToolStripMenuItem,
            this.����ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // ���ToolStripMenuItem
            // 
            this.���ToolStripMenuItem.Name = "���ToolStripMenuItem";
            this.���ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.���ToolStripMenuItem.Text = "���";
            this.���ToolStripMenuItem.Click += new System.EventHandler(this.���ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // _box
            // 
            this._box.ContextMenuStrip = this.contextMenuStrip1;
            this._box.Dock = System.Windows.Forms.DockStyle.Fill;
            this._box.Location = new System.Drawing.Point(0, 2);
            this._box.Margin = new System.Windows.Forms.Padding(2);
            this._box.Name = "_box";
            this._box.Size = new System.Drawing.Size(302, 356);
            this._box.TabIndex = 3;
            this._box.Text = "";
            // 
            // OutputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(302, 360);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this._box);
            this.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OutputWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
            this.TabPageContextMenuStrip = this.contextMenuStrip1;
            this.TabText = "�������";
            this.Text = "�������";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox _box;
    }
}