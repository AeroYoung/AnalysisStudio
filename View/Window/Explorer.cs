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
        
        #region �ڵ���ί���¼�

        public delegate void NodeDoubleClickHandler(object sender, EventArgs e);

        public NodeDoubleClickHandler MachineRefactorNodeClick;

        public NodeDoubleClickHandler PvtSolverNodeClick;

        public NodeDoubleClickHandler Export��ģ���ձ�NodeClick;

        public NodeDoubleClickHandler OpenPressurizeNodeClick;

        public NodeDoubleClickHandler OpenAssessmentDialogClick;

        public NodeDoubleClickHandler OpenMeltingDialogClick;

        public NodeDoubleClickHandler OpenFillingDialogClick;

        //public NodeDoubleClickHandler �ݸ��ٶ�����NodeClick;

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var text = e.Node.Text;
            if(text.Equals("�������ձ�", StringComparison.CurrentCultureIgnoreCase))
                Export��ģ���ձ�NodeClick?.Invoke(null, null);
            else if (text.Equals("����ϵ��", StringComparison.CurrentCultureIgnoreCase))
                MachineRefactorNodeClick?.Invoke(null, null);
            else if (text.Equals("PVT�����", StringComparison.CurrentCultureIgnoreCase))
                PvtSolverNodeClick?.Invoke(null, null);
            else if (text.Equals("��ѹ�׶�", StringComparison.CurrentCultureIgnoreCase))
                OpenPressurizeNodeClick?.Invoke(null, null);
            else if (text.Equals("��������", StringComparison.CurrentCultureIgnoreCase))
                OpenAssessmentDialogClick?.Invoke(null, null);
            else if (text.Equals("Ԥ�ܽ׶�", StringComparison.CurrentCultureIgnoreCase))
                OpenMeltingDialogClick?.Invoke(null, null);
            else if (text.Equals("���׶�", StringComparison.CurrentCultureIgnoreCase))
                OpenFillingDialogClick?.Invoke(null, null);
        }

        #endregion
    }
}