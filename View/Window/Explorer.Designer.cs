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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("���ݽӿ�");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Ԥ����");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ԭʼ����", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("�����㷨");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("���ݷ���");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("�汾����");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("��ά����");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("���ݼ���");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("�������");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("ͼ����ʾ");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("֪ʶ����ѧϰ");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.Indent = 19;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "���ݽӿ�.ico";
            treeNode1.Name = "���ݽӿ�";
            treeNode1.SelectedImageKey = "���ݽӿ�.ico";
            treeNode1.Text = "���ݽӿ�";
            treeNode2.ImageKey = "Ԥ����.ico";
            treeNode2.Name = "Ԥ����";
            treeNode2.SelectedImageKey = "Ԥ����.ico";
            treeNode2.Text = "Ԥ����";
            treeNode3.ImageKey = "sln.ico";
            treeNode3.Name = "ԭʼ����";
            treeNode3.SelectedImageKey = "sln.ico";
            treeNode3.Text = "ԭʼ����";
            treeNode4.ImageKey = "�����㷨.ico";
            treeNode4.Name = "�����㷨";
            treeNode4.SelectedImageKey = "�����㷨.ico";
            treeNode4.Text = "�����㷨";
            treeNode5.Name = "���ݷ���";
            treeNode5.Text = "���ݷ���";
            treeNode6.Name = "�汾����";
            treeNode6.Text = "�汾����";
            treeNode7.Name = "��ά����";
            treeNode7.Text = "��ά����";
            treeNode8.Name = "���ݼ���";
            treeNode8.Text = "���ݼ���";
            treeNode9.Name = "�������";
            treeNode9.Text = "�������";
            treeNode10.Name = "ͼ����ʾ";
            treeNode10.Text = "ͼ����ʾ";
            treeNode11.Name = "֪ʶ����ѧϰ";
            treeNode11.Text = "֪ʶ����ѧϰ";
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
            this.imageList2.Images.SetKeyName(1, "�����㷨.ico");
            this.imageList2.Images.SetKeyName(2, "���ݽӿ�.ico");
            this.imageList2.Images.SetKeyName(3, "Ԥ����.ico");
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
            this.TabText = "�������������";
            this.Text = "�������������";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList2;
    }
}