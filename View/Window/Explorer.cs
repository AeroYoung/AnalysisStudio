using System;
using System.Windows.Forms;

namespace AnalysisStudio
{
    public partial class Explorer : BaseForm
    {
        public Explorer()
        {
            InitializeComponent();

            treeView1.ExpandAll();
        }
        
        #region 节点点击委托事件

        public delegate void NodeDoubleClickHandler(object sender, EventArgs e);

        public NodeDoubleClickHandler MachineRefactorNodeClick;

        public NodeDoubleClickHandler PvtSolverNodeClick;

        public NodeDoubleClickHandler Export试模工艺表NodeClick;

        public NodeDoubleClickHandler OpenPressurizeNodeClick;

        public NodeDoubleClickHandler OpenAssessmentDialogClick;

        public NodeDoubleClickHandler OpenMeltingDialogClick;

        public NodeDoubleClickHandler OpenFillingDialogClick;

        //public NodeDoubleClickHandler 螺杆速度曲线NodeClick;

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var text = e.Node.Text;
            if(text.Equals("导出工艺表", StringComparison.CurrentCultureIgnoreCase))
                Export试模工艺表NodeClick?.Invoke(null, null);
            else if (text.Equals("修正系数", StringComparison.CurrentCultureIgnoreCase))
                MachineRefactorNodeClick?.Invoke(null, null);
            else if (text.Equals("PVT求解器", StringComparison.CurrentCultureIgnoreCase))
                PvtSolverNodeClick?.Invoke(null, null);
            else if (text.Equals("保压阶段", StringComparison.CurrentCultureIgnoreCase))
                OpenPressurizeNodeClick?.Invoke(null, null);
            else if (text.Equals("评估因子", StringComparison.CurrentCultureIgnoreCase))
                OpenAssessmentDialogClick?.Invoke(null, null);
            else if (text.Equals("预塑阶段", StringComparison.CurrentCultureIgnoreCase))
                OpenMeltingDialogClick?.Invoke(null, null);
            else if (text.Equals("填充阶段", StringComparison.CurrentCultureIgnoreCase))
                OpenFillingDialogClick?.Invoke(null, null);
        }

        #endregion
    }
}