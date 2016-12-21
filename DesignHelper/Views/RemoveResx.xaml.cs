using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using MahApps.Metro.Controls;

namespace DesignHelper
{
    /// <summary>
    /// Interaction logic for RemoveResx.xaml
    /// </summary>
    public partial class RemoveResx : MetroWindow, INotifyPropertyChanged
    {
        private string _resxPath;
        private string _xamlPath;
        private StringBuilder _log;
        public string ResxPath
        {
            get { return _resxPath; }
            set
            {
                _resxPath = value;
                OnPropertyChanged("ResxPath");
            }
        }

        public string XamlPath
        {
            get { return _xamlPath; }
            set
            {
                _xamlPath = value;
                OnPropertyChanged("XamlPath");
            }
        }

        public string Log
        {
            get { return _log.ToString(); }
            set
            {
                _log.AppendLine(value);
                OnPropertyChanged("Log");
            }
        }


        public RemoveResx()
        {
            _log = new StringBuilder("Start");
            DataContext = this;
            InitializeComponent();

            ResxPath = @"C:\Working\ResourcesClient.Merged\Common\ResourcesClient.Infrastructure\Resources";
            XamlPath = @"C:\Working\ResourcesClient.Merged\Modules\ResourcesClient.Modules.Stand\Views\Stands";
        }


        private void RemoveResx_Click(object sender, RoutedEventArgs e)
        {
            _log = new StringBuilder("Start");
            // resx file
            XElement xe = XElement.Load(ResxPath + @"\StringResources.resx");
            IEnumerable<XElement> elements = from ele in xe.Elements("data")
                                             select ele;

            BackupAllFiles(XamlPath);
            List<FileInfo> xamlFiles = GetFiles(XamlPath + @"\Backup\", "xaml");
            if (xamlFiles.Count > 0)
            {
                foreach (FileInfo xamlFile in xamlFiles)
                {
                    RemoveResxFromXaml(xamlFile, elements);
                }
            }

        }

        private void BackupAllFiles(string xamlPath)
        {
            Directory.CreateDirectory(xamlPath + @"\Backup\");
            List<FileInfo> xamlFiles = GetFiles(XamlPath, "xaml");
            foreach (FileInfo xamlFile in xamlFiles)
            {

                xamlFile.MoveTo(xamlPath + @"\Backup\" + xamlFile.Name);

            }
        }

        private void RemoveResxFromXaml(FileInfo xamlFile, IEnumerable<XElement> resxContent)
        {
            using (StreamReader xamlReader = new StreamReader(xamlFile.OpenRead()))
            {
                string strWriteFilePath = xamlFile.FullName.Replace(@"\Backup", "");
                StreamWriter swWriteFile = File.CreateText(strWriteFilePath);

                string xamlLine;
                while (!xamlReader.EndOfStream)
                {
                    xamlLine = xamlReader.ReadLine();

                    if (xamlLine.Contains("{Resx "))
                    {
                        if (!xamlLine.Contains("Common.")) // TODO ignore list
                        {
                            var resxName = new ResxRow(xamlLine).Name;
                            var bindingString = new ResxRow(xamlLine).BindingString;

                            // find resxValue from resx file
                            string resxValue = GetResxValue(resxName, resxContent);

                            if (resxValue != string.Empty)
                            {
                                xamlLine = xamlLine.Replace(bindingString, resxValue);
                            }
                            else
                            {

                            }
                        }
                    }
                    swWriteFile.WriteLine(xamlLine); //写入读取的每行数据
                }
                swWriteFile.Close();
            }
        }

        private string GetResxValue(string resxName, IEnumerable<XElement> resxContent)
        {
            var ele = resxContent.FirstOrDefault(r => r.Attribute("name").Value == resxName);
            if (ele == null)
            {
                Log = resxName + " Not found";
                return string.Empty;
            }
            else
            {
                string resxLine = ele.Element("value").Value;
                Log = resxName + "==>" + resxLine;
                return resxLine;
            }
        }

        private List<FileInfo> GetFiles(string path, string extName)
        {
            var lst = new List<FileInfo>();
            if (Directory.Exists(path))
            {
                string[] dir = Directory.GetDirectories(path);
                var fdir = new DirectoryInfo(path);
                FileInfo[] file = fdir.GetFiles();
                if (file.Length != 0 || dir.Length != 0)
                {
                    foreach (FileInfo f in file)
                    {
                        if (f.Name.ToLower().Contains(extName.ToLower()))
                        {
                            lst.Add(f);
                        }
                    }
                }
            }
            return lst;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
