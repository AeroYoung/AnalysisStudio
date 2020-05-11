using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WeifenLuo.WinFormsUI.Docking;
using static AnalysisStudio.PublicFunctions;

namespace AnalysisStudio
{
    [Serializable]
    public class Setting
    {
        private Setting()
        {
            ThemeSchema = ThemeSchema.VS2015Blue;
            ShowDocIcon = true;
            DbFilePath = "";
            DbPassword = "";
        }

        public static string SettingPath => Path.Combine(Application.UserAppDataPath, "setting.bin");

        public bool ShowDocIcon { get; set; }

        public ThemeSchema ThemeSchema { get; set; }

        public string DbFilePath { get; set; }

        public string DbPassword { get; set; }

        public static Setting Instance;

        public static Setting Read()
        {
            try
            {
                var setting = ReadSerializable<Setting>(SettingPath) ?? new Setting();

                return setting;
            }
            catch (Exception)
            {
                return new Setting();
            }
        }
    }

    public static class PublicFunctions
    {
        #region 序列化

        /// <summary>
        /// 采用序列化的方法克隆对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T SerialClone<T>(this T obj)
        {
            T result;
            //将对象序列化成内存中的二进制流
            var inputFormatter = new BinaryFormatter();
            MemoryStream inputStream;
            using (inputStream = new MemoryStream())
            {
                inputFormatter.Serialize(inputStream, obj);
            }
            //将二进制流反序列化为对象
            using (var outputStream = new MemoryStream(inputStream.ToArray()))
            {
                var outputFormatter = new BinaryFormatter();
                result = (T)outputFormatter.Deserialize(outputStream);
            }

            return result;
        }

        /// <summary>
        /// 读取序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<T> ReadListSerializable<T>(string filePath)
        {
            List<T> result = new List<T>();

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = bf.Deserialize(fs) as List<T>;
            }
            fs.Close();

            return result;
        }

        public static List<T> ReadListSerializableStream<T>(Stream fs)
        {
            List<T> result = new List<T>();

            if (fs == null)
                return result;

            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = bf.Deserialize(fs) as List<T>;
            }
            fs.Close();

            return result;
        }

        public static Dictionary<T, TV> ReadDicSerializable<T, TV>(string filePath)
        {
            var result = new Dictionary<T, TV>();

            var fs = new FileStream(filePath, FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                var bf = new BinaryFormatter();
                result = bf.Deserialize(fs) as Dictionary<T, TV>;
            }
            fs.Close();

            return result;
        }

        public static T ReadSerializable<T>(string filePath)
        {
            T result = default(T);
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = (T)bf.Deserialize(fs);
            }
            fs.Close();

            return result;

        }

        public static T ReadSerializableStream<T>(Stream fs)
        {
            T result = default(T);

            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = (T)bf.Deserialize(fs);
            }
            fs.Close();

            return result;
        }

        /// <summary>
        /// 写序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        public static void WriteSerializable<T>(this List<T> obj, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, obj);
            fs.Close();
        }

        public static void WriteSerializable<T, TV>(this Dictionary<T, TV> obj, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, obj);
            fs.Close();
        }

        public static void WriteSerializable<T>(this T obj, string filePath)
        {
            var fs = new FileStream(filePath, FileMode.Create);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, obj);
            fs.Close();
        }

        #endregion
        
        #region NPOI

        public static bool CheckFile(string file, out bool isXlsx)
        {
            isXlsx = true;

            if (!File.Exists(file))
                return false;

            if (file.ToLower().EndsWith(".xlsx"))
                isXlsx = true;
            else if (file.ToLower().EndsWith(".xls"))
                isXlsx = false;
            else
                return false;

            return true;
        }

        public static IWorkbook OpenWorkbook(this FileStream stream, bool isXlsx)
        {
            if (isXlsx)
                return new XSSFWorkbook(stream);
            else
                return new HSSFWorkbook(stream);
        }

        ///// <summary>
        ///// 试模工艺表
        ///// </summary>
        ///// <param name="sln"></param>
        ///// <param name="tempPath"></param>
        ///// <param name="filePath"></param>
        //public static void ExportToXlsx(this CaeSln sln, string tempPath, string filePath)
        //{
        //    try
        //    {
        //        XSSFWorkbook wk;
        //        using (var fs = File.Open(tempPath, FileMode.Open,
        //            FileAccess.Read, FileShare.ReadWrite))
        //        {
        //            wk = new XSSFWorkbook(fs);
        //            fs.Close();
        //        }

        //        //读取当前表数据
        //        var sheet = wk.GetSheetAt(0);

        //        for (var i = 0; i <= sheet.LastRowNum; i++)
        //        {
        //            var row = sheet.GetRow(i);  //读取当前行数据
        //            if (row == null) continue;
        //            for (var j = 0; j < row.LastCellNum; j++)
        //            {
        //                var cell = row.GetCell(j);
        //                if (cell == null)
        //                    continue;

        //                var maskValue = cell.ToString().TrimStart().TrimEnd();
        //                if (!maskValue.StartsWith("{") || !maskValue.EndsWith("}"))
        //                    continue;

        //                var obj = sln.GetValueByDisplayNameList(maskValue);
        //                if (obj != null)
        //                {
        //                    if (!double.IsNaN(obj.ToString().ToDouble()))
        //                        cell.SetCellValue(obj.ToString().ToDouble());
        //                    else
        //                        cell.SetCellValue(obj.ToString());
        //                }
        //            }
        //        }

        //        using (var fs = File.Open(filePath, FileMode.Create,
        //            FileAccess.ReadWrite, FileShare.ReadWrite))
        //        {
        //            wk.Write(fs);
        //            fs.Close();
        //        }
        //    }

        //    catch
        //    {
        //        //
        //    }
        //}

        public static void ExportToXlsx(this ListView view, string filePath)
        {
            try
            {
                var wk = new XSSFWorkbook();
                var sheet = wk.CreateSheet();

                var colCount = view.Columns.Count;
                var headerRow = sheet.CreateRow(0);
                for (var i = 0; i < colCount; i++)
                {
                    var viewCol = view.Columns[i];
                    var cell = headerRow.CreateCell(i, CellType.String);
                    cell.SetCellValue(viewCol.Text);
                }

                var rowIndex = 1;
                foreach (ListViewItem item in view.Items)
                {
                    var row = sheet.CreateRow(rowIndex++);
                    for (var i = 0; i < colCount; i++)
                    {
                        if (i >= item.SubItems.Count)
                            break;
                        var cell = row.CreateCell(i, CellType.String);
                        cell.SetCellValue(item.SubItems[i].Text);
                    }
                }

                using (var fs = File.Open(filePath, FileMode.Create,
                    FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    wk.Write(fs);
                    fs.Close();
                }

            }
            catch
            {
                //
            }
        }

        #endregion

        #region Other

        public static string GetExeFolder
        {
            get
            {
                var path = Assembly.GetExecutingAssembly().Location.ToLower();
                var fileInfo = new FileInfo(path);
                var dir = fileInfo.Directory;
                return dir?.FullName;
            }
        }

        public static string ProjFileExt = "caesln";

        public static string InjectionMachineFileExt = "ijm";

        /// <summary>
        /// 去除多余和首尾空格
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveMultiSpace(this string text)
        {
            text = text.TrimStart().TrimEnd().Replace('\t', ' ');
            while (text.Contains("  "))//去除多余空格
            {
                text = text.Replace("  ", " ");
            }

            return text;
        }

        /// <summary>
        /// 去掉字符串中的数字
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RemoveNumber(this string key)
        {
            return string.IsNullOrEmpty(key) ? "" : Regex.Replace(key, @"\d", "");
        }

        /// <summary>
        /// 去掉字符串中的非数字
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RemoveNotNumber(this string key)
        {
            return Regex.Replace(key, @"[^\d]*", "");
        }

        public static int GetHanNumFromString(this string str)
        {
            var regex = new Regex(@"^[\u4E00-\u9FA5]{0,}$");
            return str.Count(t => regex.IsMatch(t.ToString()));
        }

        public static double ToDouble(this ICell cell)
        {
            if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
            {
                return cell.NumericCellValue;
            }
            else
            {
                return cell.ToString().ToDouble();
            }
        }

        public static double ToDouble(this string s)
        {
            double value;
            var bl = double.TryParse(s, NumberStyles.Any, null, out value);
            if (bl)
                return value;
            else
                return double.NaN;
        }

        public static void SetValue(this NumericUpDown box, double value)
        {
            decimal dec;
            var min = box.Minimum;
            var max = box.Maximum;

            if (double.IsPositiveInfinity(value))
                dec = max;
            else if (double.IsNegativeInfinity(value))
                dec = min;
            else if (double.IsNaN(value))
                dec = min;
            else
                dec = (decimal)value;

            if (dec > max)
                dec = max;
            else if (dec < min)
                dec = min;

            box.Value = dec;
        }

        public static void WriteListToTextFile(this List<string> list, string txtFile)
        {

            //创建一个文件流，用以写入或者创建一个StreamWriter

            FileStream fs = new FileStream(txtFile, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs, Encoding.Default);

            sw.Flush();

            // 使用StreamWriter来往文件中写入内容

            sw.BaseStream.Seek(0, SeekOrigin.Begin);

            foreach (var t in list)
                sw.WriteLine(t);

            //关闭此文件

            sw.Flush();

            sw.Close();

            fs.Close();

        }

        /// <summary>
        /// 按指定数量对List分组
        /// </summary>
        /// <param name="list"></param>
        /// <param name="groupNum"></param>
        /// <returns></returns>
        public static List<List<T>> GetListGroup<T>(this List<T> list, int groupNum)
        {
            if (list == null)
                return new List<List<T>>();
            List<List<T>> listGroup = new List<List<T>>();
            for (int i = 0; i < list.Count(); i += groupNum)
            {
                listGroup.Add(list.Skip(i).Take(groupNum).ToList());
            }
            return listGroup;
        }

        #endregion

        [System.Runtime.InteropServices.DllImport("user32.dll",
            CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow(); //获得本窗体的句柄

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体

    }

}


