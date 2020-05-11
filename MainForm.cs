using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ExpertLib.Dialogs;
using WeifenLuo.WinFormsUI.Docking;
using static AnalysisStudio.PublicFunctions;

namespace AnalysisStudio
{
    public sealed partial class MainForm : Form
    {
        #region 字段属性

        private bool _saveLayout = true;
        private DeserializeDockContent _mDeserializeDockContent;
        //TODO 
        public Explorer Explorer;
        //public PropertyWindow PropertyWindow;
        public OutputWindow OutputWindow;
        //public PressurizeDoc PressurizeDoc;
        //public FillingDoc FillingDoc;
        //public FittingForm FittingForm;
        //public PicDoc PicDoc;

        //public PvtSolverDoc PvtSolverDoc; //以下文档窗口没有构造函数中初始化，所以无法应用保存好的布局

        private static string ConfigFilePath => Path.Combine(Application.UserAppDataPath, "AnalysisStudio.config");
        private static string ConfigTempPath => Path.Combine(Application.UserAppDataPath, "AnalysisStudio.temp.config");

        public bool Saved = true;

        #endregion

        #region 构造函数

        public MainForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            InitWindow();
            InitTheme();

            Log($"用户登录 : {SignDialog.CurrentUser.Id}");

            if (Handle != GetForegroundWindow())
                SetForegroundWindow(Handle);
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitWindow()
        {
            SplashScreen.SetStatus("初始化界面...");

            //TODO
            //PicDoc = new PicDoc(Solution);
            //PressurizeDoc = new PressurizeDoc(Solution, RefreshObj);
            //FillingDoc = new FillingDoc(Solution, RefreshObj);
            //FittingForm = new FittingForm(Solution,Setting, SimpleRefresh, RefreshObj);
            OutputWindow = new OutputWindow();
            //PropertyWindow = new PropertyWindow(Solution, RefreshObj);
            Explorer = new Explorer();
            // TODO 
            //{ 
            //    MachineRefactorNodeClick = OpenMachineRefactorDoc,
            //    PvtSolverNodeClick = OpenPvtSolverDoc,
            //    OpenPressurizeNodeClick = OpenPressurizeNodeClick,
            //    Export试模工艺表NodeClick = Export试模工艺表Click,
            //    OpenMeltingDialogClick = OpenMeltingDialogClick,
            //    OpenFillingDialogClick = OpenFillingDoc,
            //    OpenAssessmentDialogClick = OpenAssessmentDialog
            //};
            Log("初始化界面...");
            dockPanel.ShowDocumentIcon = Setting.Instance.ShowDocIcon;
            _mDeserializeDockContent = GetContentFromPersistString;
        }

        /// <summary>
        /// 初始化主题
        /// </summary>
        private void InitTheme()
        {
            SplashScreen.SetStatus("初始化主题...");
            OutputWindow.Write("初始化主题...");

            dockPanel.SuspendLayout(true);

            SetSchema(Setting.Instance.ThemeSchema, true);

            if (!File.Exists(ConfigFilePath))
            {
                // TODO 
                //PropertyWindow.Show(dockPanel, DockState.DockRight);
                Explorer.Show(dockPanel, DockState.DockRight);
                //Explorer.Show(PropertyWindow.Pane, PropertyWindow);
                OutputWindow.Show(dockPanel, DockState.DockBottom);
                //PressurizeDoc.Show(dockPanel);
                //PicDoc.Show(dockPanel);
                //FillingDoc.Show(dockPanel);
                //FittingForm.Show(dockPanel);
            }

            dockPanel.ResumeLayout(true, true);

            statusBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            labelDb.Text = $"数据库地址:{Setting.Instance.DbFilePath}";
            labelUser.Text = $"用户名:{SignDialog.CurrentUser.Id}";
            labelVersion.Text = $"版本号:{Assembly.GetAssembly(typeof(MainForm)).GetName().Version}";
            labelVersion.Alignment = ToolStripItemAlignment.Right;

        }

        #endregion

        #region 新建|打开|保存

        #region 按钮

        /// <summary>
        /// 新建按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemNew_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                CheckPathExists = true,
                //Filter = $"CAE解决方案(*.{ProjFileExt})|*.{ProjFileExt}",
                DereferenceLinks = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            Log($"打开 {dialog.FileName}");
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存SToolStripMenuItem_Click");
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("另存为ToolStripMenuItem_Click");
        }

        #endregion

        #endregion

        #region 布局记忆|界面风格

        /// <summary>
        /// 退出时候保存布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            if (_saveLayout)
                dockPanel.SaveAsXml(ConfigFilePath);
            else if (File.Exists(ConfigFilePath))
                File.Delete(ConfigFilePath);

            //保存记忆文件
            Setting.Instance.WriteSerializable(Setting.SettingPath);
        }

        /// <summary>
        /// 根据persistString返回Doc或者Window
        /// </summary>
        /// <param name="persistString"></param>
        /// <returns></returns>
        private IDockContent GetContentFromPersistString(string persistString)
        {
            // TODO 
            if (persistString == typeof(Explorer).ToString())
                return Explorer;
            //else if (persistString == typeof(PropertyWindow).ToString())
            //    return PropertyWindow;
            else if (persistString == typeof(OutputWindow).ToString())
                return OutputWindow;
            //else if (persistString == typeof(FittingForm).ToString())
            //    return FittingForm;
            //else if (persistString == typeof(PvtSolverDoc).ToString())
            //    return PvtSolverDoc;
            //else if (persistString == typeof (PressurizeDoc).ToString())
            //    return PressurizeDoc;
            //else if (persistString == typeof(FillingDoc).ToString())
            //    return FillingDoc;
            //else if (persistString == typeof(PicDoc).ToString())
            //    return PicDoc;
            //else
            return null;
        }

        #region 关闭文档

        /// <summary>
        /// 关闭或者隐藏Doc
        /// </summary>
        /// <param name="doc"></param>
        private static void CloseOrHideDoc(IDockContent doc)
        {
            if (doc == null)
                return;

            if (doc.DockHandler.HideOnClose)
                doc.DockHandler.Hide();
            else
            {
                // IMPORANT: dispose all panes.
                doc.DockHandler.DockPanel = null;
                doc.DockHandler.Close();
            }
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            CloseOrHideDoc(dockPanel.ActiveDocument);
        }

        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            foreach (var document in dockPanel.DocumentsToArray())
            {
                CloseOrHideDoc(document);
            }
        }

        private void menuItemCloseAllButThisOne_Click(object sender, EventArgs e)
        {
            foreach (var document in dockPanel.DocumentsToArray().Where(document => !document.DockHandler.IsActivated))
            {
                CloseOrHideDoc(document);
            }
        }

        #endregion

        #region 界面风格

        public ThemeSchema ThemeSchema;

        /// <summary>
        /// 设置界面风格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSchema(object sender, EventArgs e)
        {
            if (sender == menuItemSchemaVS2005)
                ThemeSchema = ThemeSchema.VS2005;
            else if (sender == menuItemSchemaVS2003)
                ThemeSchema = ThemeSchema.VS2003;
            else if (sender == menuItemSchemaVS2012Light)
                ThemeSchema = ThemeSchema.VS2012Light;
            else if (sender == menuItemSchemaVS2012Blue)
                ThemeSchema = ThemeSchema.VS2012Blue;
            else if (sender == menuItemSchemaVS2012Dark)
                ThemeSchema = ThemeSchema.VS2012Dark;
            else if (sender == menuItemSchemaVS2013Blue)
                ThemeSchema = ThemeSchema.VS2013Blue;
            else if (sender == menuItemSchemaVS2013Light)
                ThemeSchema = ThemeSchema.VS2013Light;
            else if (sender == menuItemSchemaVS2013Dark)
                ThemeSchema = ThemeSchema.VS2013Dark;
            else if (sender == menuItemSchemaVS2015Blue)
                ThemeSchema = ThemeSchema.VS2015Blue;
            else if (sender == menuItemSchemaVS2015Light)
                ThemeSchema = ThemeSchema.VS2015Light;
            else if (sender == menuItemSchemaVS2015Dark)
                ThemeSchema = ThemeSchema.VS2015Dark;
            else
                ThemeSchema = ThemeSchema.VS2015Blue;

            Setting.Instance.ThemeSchema = ThemeSchema;
            SetSchema(Setting.Instance.ThemeSchema);
        }

        /// <summary>
        /// 设置界面风格
        /// </summary>
        private void SetSchema(ThemeSchema theme, bool init = false)
        {
            dockPanel.SaveAsXml(ConfigTempPath);
            CloseAllContents();

            #region 设置主题

            if (theme == ThemeSchema.VS2005)
            {
                dockPanel.Theme = vS2005Theme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2005, vS2005Theme1);
            }
            else if (theme == ThemeSchema.VS2003)
            {
                dockPanel.Theme = vS2003Theme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2003, vS2003Theme1);
            }
            else if (theme == ThemeSchema.VS2012Light)
            {
                dockPanel.Theme = vS2012LightTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2012, vS2012LightTheme1);
            }
            else if (theme == ThemeSchema.VS2012Blue)
            {
                dockPanel.Theme = vS2012BlueTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2012, vS2012BlueTheme1);
            }
            else if (theme == ThemeSchema.VS2012Dark)
            {
                dockPanel.Theme = vS2012DarkTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2012, vS2012DarkTheme1);
            }
            else if (theme == ThemeSchema.VS2013Blue)
            {
                dockPanel.Theme = vS2013BlueTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2013, vS2013BlueTheme1);
            }
            else if (theme == ThemeSchema.VS2013Light)
            {
                dockPanel.Theme = vS2013LightTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2013, vS2013LightTheme1);
            }
            else if (theme == ThemeSchema.VS2013Dark)
            {
                dockPanel.Theme = vS2013DarkTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2013, vS2013DarkTheme1);
            }
            else if (theme == ThemeSchema.VS2015Blue)
            {
                dockPanel.Theme = vS2015BlueTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015BlueTheme1);
            }
            else if (theme == ThemeSchema.VS2015Light)
            {
                dockPanel.Theme = vS2015LightTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1);
            }
            else if (theme == ThemeSchema.VS2015Dark)
            {
                dockPanel.Theme = vS2015DarkTheme1;
                EnableVsRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015DarkTheme1);
            }

            #endregion

            #region 界面颜色和勾选

            menuItemSchemaVS2005.Checked = (theme == ThemeSchema.VS2005);
            menuItemSchemaVS2003.Checked = (theme == ThemeSchema.VS2003);
            menuItemSchemaVS2012Light.Checked = (theme == ThemeSchema.VS2012Light);
            menuItemSchemaVS2012Blue.Checked = (theme == ThemeSchema.VS2012Blue);
            menuItemSchemaVS2012Dark.Checked = (theme == ThemeSchema.VS2012Dark);
            menuItemSchemaVS2013Light.Checked = (theme == ThemeSchema.VS2013Light);
            menuItemSchemaVS2013Blue.Checked = (theme == ThemeSchema.VS2013Blue);
            menuItemSchemaVS2013Dark.Checked = (theme == ThemeSchema.VS2013Dark);
            menuItemSchemaVS2015Light.Checked = (theme == ThemeSchema.VS2015Light);
            menuItemSchemaVS2015Blue.Checked = (theme == ThemeSchema.VS2015Blue);
            menuItemSchemaVS2015Dark.Checked = (theme == ThemeSchema.VS2015Dark);
            if (dockPanel.Theme.ColorPalette != null)
            {
                statusBar.BackColor = dockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
                statusBar.ForeColor = dockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Text;
            }

            #endregion

            if (init)
            {
                if (File.Exists(ConfigFilePath))
                    dockPanel.LoadFromXml(ConfigFilePath, _mDeserializeDockContent);
            }
            else
            {
                if (File.Exists(ConfigTempPath))
                    dockPanel.LoadFromXml(ConfigTempPath, _mDeserializeDockContent);
            }
        }

        /// <summary>
        /// 切换界面风格的时候会用到
        /// </summary>
        private void CloseAllContents()
        {
            // we don't want to create another instance of tool window, set DockPanel to null
            // TODO
            Explorer.DockPanel = null;
            //PropertyWindow.DockPanel = null;
            OutputWindow.DockPanel = null;

            // Close Or Hide all other document windows
            foreach (var doc in dockPanel.DocumentsToArray())
            {
                // IMPORANT: dispose all panes.
                doc.DockHandler.DockPanel = null;
                if (!doc.DockHandler.HideOnClose)
                    doc.DockHandler.Close();
            }

            // IMPORTANT: dispose all float windows.
            foreach (var window in dockPanel.FloatWindows.ToList())
                window.Dispose();

            System.Diagnostics.Debug.Assert(dockPanel.Panes.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel.Contents.Count == 0);
            System.Diagnostics.Debug.Assert(dockPanel.FloatWindows.Count == 0);
        }

        private void EnableVsRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
            vsToolStripExtender1.SetStyle(mainMenu, version, theme);
            vsToolStripExtender1.SetStyle(toolBar, version, theme);
            vsToolStripExtender1.SetStyle(statusBar, version, theme);
            vsToolStripExtender1.SetStyle(contextMenuStrip1, version, theme);

            if (OutputWindow != null)
                vsToolStripExtender1.SetStyle(OutputWindow.ContextMenuStrip, version, theme);

        }

        private void SetDocumentStyle(object sender, EventArgs e)
        {
            var oldStyle = dockPanel.DocumentStyle;
            DocumentStyle newStyle;
            if (sender == menuItemDockingMdi)
                newStyle = DocumentStyle.DockingMdi;
            else if (sender == menuItemDockingWindow)
                newStyle = DocumentStyle.DockingWindow;
            else if (sender == menuItemDockingSdi)
                newStyle = DocumentStyle.DockingSdi;
            else
                newStyle = DocumentStyle.DockingMdi;//newStyle = DocumentStyle.SystemMdi; SystemMdi太麻烦,不要用

            if (oldStyle == newStyle)
                return;

            dockPanel.DocumentStyle = newStyle;
            menuItemDockingMdi.Checked = (newStyle == DocumentStyle.DockingMdi);
            menuItemDockingWindow.Checked = (newStyle == DocumentStyle.DockingWindow);
            menuItemDockingSdi.Checked = (newStyle == DocumentStyle.DockingSdi);
            //menuItemLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
            //menuItemLayoutByXml.Enabled = (newStyle != DocumentStyle.SystemMdi);
        }

        #endregion

        #endregion

        #region 菜单栏点击

        private void menuItemSolutionExplorer_Click(object sender, EventArgs e)
        {
            Explorer.Show(dockPanel);
        }

        private void menuItemPropertyWindow_Click(object sender, EventArgs e)
        {
            //PropertyWindow.Show(dockPanel);
        }

        /// <summary>
        /// 运行日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemOutputWindow_Click(object sender, EventArgs e)
        {
            OutputWindow.Show(dockPanel, DockState.DockBottom);
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            var aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog(this);
        }

        private void menuItemFile_Popup(object sender, EventArgs e)
        {
            menuItemClose.Enabled = dockPanel.ActiveDocument != null;
            menuItemCloseAll.Enabled =
                menuItemCloseAllButThisOne.Enabled = (dockPanel.DocumentsCount > 0);
        }

        private void menuItemToolBar_Click(object sender, EventArgs e)
        {
            toolBar.Visible = menuItemToolBar.Checked = !menuItemToolBar.Checked;
        }

        private void menuItemStatusBar_Click(object sender, EventArgs e)
        {
            statusBar.Visible = menuItemStatusBar.Checked = !menuItemStatusBar.Checked;
        }

        private void menuItemTools_Popup(object sender, EventArgs e)
        {
            menuItemLockLayout.Checked = !this.dockPanel.AllowEndUserDocking;
        }

        private void menuItemLockLayout_Click(object sender, EventArgs e)
        {
            dockPanel.AllowEndUserDocking = !dockPanel.AllowEndUserDocking;
        }

        private void menuItemShowDocumentIcon_Click(object sender, EventArgs e)
        {
            dockPanel.ShowDocumentIcon = menuItemShowDocumentIcon.Checked = !menuItemShowDocumentIcon.Checked;
            Setting.Instance.ShowDocIcon = menuItemShowDocumentIcon.Checked;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 退出且不保存布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
        {
            _saveLayout = false;
            Close();
            _saveLayout = true;
        }

        private void 重置布局ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(ConfigFilePath))
                File.Delete(ConfigFilePath);

            MessageBox.Show("重启软件后生效,请选择退出且不保存布局");
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new DbConnectDialog();
            dialog.ShowDialog();
            if (dialog.DialogResult != DialogResult.OK)
            {
                return;
            }

            MessageBox.Show("重启软件生效", "提示");
        }

        private void btnPics_Click(object sender, EventArgs e)
        {
            // TODO PicDoc.Show(dockPanel);
        }

        #endregion

        #region 工具栏点击事件

        /// <summary>
        /// 导入注塑机信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportInject(object sender, EventArgs e)
        {
            // TODO 
            //var dialog = new MachineForm(Setting);
            //dialog.ShowDialog();
            //if (dialog.DialogResult != DialogResult.OK)
            //    return;

            //var obj = dialog.SelectedMachine;
            //if (obj == null)
            //    return;

            //Solution.Machine = obj;
            //Solution.HasMachineInfo = true;

            ////刷新界面, 添加恢复点
            //RefreshObj(this.GetType(), false, true);
        }

        /// <summary>
        /// 导入标准工艺参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("toolStripButton5_Click");
        }

        /// <summary>
        /// 单独导入MoldFlow日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("toolStripButton8_Click");
        }

        /// <summary>
        /// 数据拟合-评估因子对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAssessmentDialog(object sender, EventArgs e)
        {
            MessageBox.Show("OpenAssessmentDialog");
        }

        /// <summary>
        /// 数据拟合-修正系数窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMachineRefactorDoc(object sender, EventArgs e)
        {
            //FittingForm.Show(dockPanel);
        }

        /// <summary>
        /// 数据转换-PVT求解器窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPvtSolverDoc(object sender, EventArgs e)
        {
            //if (PvtSolverDoc == null)
            //    PvtSolverDoc = new PvtSolverDoc(Solution, WriteLog);

            //PvtSolverDoc.Show(dockPanel);
        }

        /// <summary>
        /// 数据转换-预塑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMeltingDialogClick(object sender, EventArgs e)
        {
            //var dialog = new MeltingDialog(Solution);
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    RefreshObj(GetType(), false, true);
            //}
        }

        /// <summary>
        /// 数据转换-填充窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFillingDoc(object sender, EventArgs e)
        {
            //FillingDoc.Show(dockPanel);
        }

        /// <summary>
        /// 试模工艺表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPressurizeNodeClick(object sender, EventArgs e)
        {
            //PressurizeDoc.Show(dockPanel);
        }

        /// <summary>
        /// 生成试模工艺表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Export试模工艺表Click(object sender, EventArgs e)
        {
            //var dialog = new SaveFileDialog
            //{
            //    //FileName = $"{Solution.ProjInfo.ProjNo}-试模工艺表",
            //    AutoUpgradeEnabled = true,
            //    CheckPathExists = true,
            //    Filter = "试模工艺表(*.xlsx)|*.xlsx",
            //    DereferenceLinks = true,
            //    FilterIndex = 1
            //};

            //if (dialog.ShowDialog() != DialogResult.OK)
            //    return;

            //var tempPath = GetExeFolder + "\\DataBase\\1-模板\\试模工艺表.xlsx";

            //Solution.ExportToXlsx(tempPath, dialog.FileName);

            //WriteLog($"生成试模工艺表:{dialog.FileName}");
        }

        #endregion

        #region 其他

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.S) && e.Control)
            {
                保存SToolStripMenuItem_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.S) && e.Control)
            {
                menuItemNew_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.Z) && e.Control)
            {
                //undoBtn_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.Y) && e.Control)
            {
                //redoBtn_Click(sender, e);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Saved)
                return;

            e.Cancel = MessageBox.Show("未保存,是否继续关闭?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK;
        }

        /// <summary>
        /// 合并工具栏和状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            // TODO
            ////CTools为MDI窗体工具栏
            //var doc = dockPanel.ActiveDocument;

            //ToolStripManager.RevertMerge(toolBar);
            //ToolStripManager.RevertMerge(statusBar);

            //if ((doc as CaeDoc)?.CipherToolStrip != null)
            //    ToolStripManager.Merge((doc as CaeDoc).CipherToolStrip, toolBar);
            //if ((doc as CaeDoc)?.CipherStatusStrip != null)
            //    ToolStripManager.Merge((doc as CaeDoc).CipherStatusStrip, statusBar);

            ////若子窗体无工具栏时,隐藏该工具栏
            //toolBar.Visible = toolBar.Items.Count > 0;
            //statusBar.Visible = statusBar.Items.Count > 0;
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void 最大化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        public void Log(string s)
        {
            OutputWindow?.Write(s);
        }

        #endregion
    }
}