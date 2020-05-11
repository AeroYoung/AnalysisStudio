using System.Collections.Generic;
using System.Windows.Forms;
using ExpertLib.Dialogs;

namespace AnalysisStudio
{
    public partial class OutputWindow : BaseForm
    {
        public OutputWindow()
        {
            InitializeComponent();
        }

        public void Write(string log)
        {
            var s = Log.i(log);
            _box.AppendText($"{s}\r\n");
            
        }

        public void Write(List<string> log)
        {
            var ss = new List<string>();
            foreach (var l in log)
            {
                ss.Add(Log.i(l));
            }
            _box.Lines = ss.ToArray();
            _box.AppendText("\r\n");
            _box.Select(0, 0);
            _box.ScrollToCaret();//��������괦
        }

        public void Clear()
        {
            _box.Clear();
            Log.Clear();
        }

        private void ���ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Clear();
        }

        private void ����ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var dialog = new SaveFileDialog {FileName = "������־.rtf"};
            if (dialog.ShowDialog() != DialogResult.OK) 
                return;
            _box.SaveFile(dialog.FileName, RichTextBoxStreamType.RichText);
            MessageBox.Show("�ļ��ѳɹ�����");
        }
    }
}