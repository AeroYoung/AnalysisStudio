using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace AnalysisStudio
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            labelAppVersion.Text = $"应用程序版本 : {typeof(MainForm).Assembly.GetName().Version}";
            labelLibVersion.Text = $"引用控件版本 : {typeof(DockPanel).Assembly.GetName().Version}";
        }
        
        private void AboutDialog_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}