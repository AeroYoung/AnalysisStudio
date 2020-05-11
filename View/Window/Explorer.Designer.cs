namespace AnalysisStudio
{
    partial class Explorer
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("数据接口");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("预处理");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("原始数据", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("分析算法");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("数据分析");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("版本管理");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("多维分析");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("数据计算");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("报表管理");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("图表显示");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("知识归纳学习");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.Indent = 19;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "数据接口.ico";
            treeNode1.Name = "数据接口";
            treeNode1.SelectedImageKey = "数据接口.ico";
            treeNode1.Text = "数据接口";
            treeNode2.ImageKey = "预处理.ico";
            treeNode2.Name = "预处理";
            treeNode2.SelectedImageKey = "预处理.ico";
            treeNode2.Text = "预处理";
            treeNode3.ImageKey = "sln.ico";
            treeNode3.Name = "原始数据";
            treeNode3.SelectedImageKey = "sln.ico";
            treeNode3.Text = "原始数据";
            treeNode4.ImageKey = "分析算法.ico";
            treeNode4.Name = "分析算法";
            treeNode4.SelectedImageKey = "分析算法.ico";
            treeNode4.Text = "分析算法";
            treeNode5.Name = "数据分析";
            treeNode5.Text = "数据分析";
            treeNode6.Name = "版本管理";
            treeNode6.Text = "版本管理";
            treeNode7.Name = "多维分析";
            treeNode7.Text = "多维分析";
            treeNode8.Name = "数据计算";
            treeNode8.Text = "数据计算";
            treeNode9.Name = "报表管理";
            treeNode9.Text = "报表管理";
            treeNode10.Name = "图表显示";
            treeNode10.Text = "图表显示";
            treeNode11.Name = "知识归纳学习";
            treeNode11.Text = "知识归纳学习";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(278, 596);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "sln.ico");
            this.imageList2.Images.SetKeyName(1, "分析算法.ico");
            this.imageList2.Images.SetKeyName(2, "数据接口.ico");
            this.imageList2.Images.SetKeyName(3, "预处理.ico");
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(278, 596);
            this.Controls.Add(this.treeView1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Explorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "解决方案管理器";
            this.Text = "解决方案管理器";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList2;
    }
}