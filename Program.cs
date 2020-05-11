using System;
using System.Windows.Forms;
using ExpertLib.DataBase;
using ExpertLib.Dialogs;

namespace AnalysisStudio
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Setting.Instance = Setting.Read();

            Log.Start();

            var sql = new SqlHelper();
            if (!sql.TestConnection(1, out _))
            {
                var frmDataBase = new DbConnectDialog();
                frmDataBase.ShowDialog();
                if (frmDataBase.DialogResult != DialogResult.OK)
                    return;
            }

            var signIn = new SignDialog();
            signIn.ShowDialog();
            if (signIn.DialogResult != DialogResult.OK)
                return;

            SplashScreen.ShowSplashScreen("数据分析平台", "");
            SplashScreen.SetStatus("正在启动...");
            
            Log.i("初始化");

            var form = new MainForm();

            Log.i("初始化完成");
            SplashScreen.CloseForm();

            Application.Run(form);


            
        }
    }
}
