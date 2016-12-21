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
using AurelienRibon.Ui.SyntaxHighlightBox;
using MahApps.Metro.Controls;

namespace DesignHelper
{
    /// <summary>
    /// Interaction logic for ListProps.xaml
    /// </summary>
    public partial class ListProps : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public string FileNameText { get; set; }
        public ObservableCollection<ListPropsEntity> PropsList { get; set; }

        private string[] ignoreList = new string[] { "void", };
        private string[] keyWords = new string[] { "command", "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "in (generic modifier)", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "out (generic modifier)", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };

        public ListProps()
        {
            DataContext = this;
            PropsList = new ObservableCollection<ListPropsEntity>();
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".cs";
            dlg.Filter = "C# Files (*.cs)|*.cs";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result.HasValue && result.Value)
            {
                // Open document 
                string filename = dlg.FileName;
                FileNameText = filename;
                OnPropertyChanged("FileNameText");
            }
        }

        private void GeneratePropsList_Click(object sender, RoutedEventArgs e)
        {
            // read source code
            string readContents;
            using (StreamReader streamReader = new StreamReader(FileNameText, Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd();
            }

            // display to highlight box
            HighlightBox.CurrentHighlighter = HighlighterManager.Instance.Highlighters["VDHL"];
            HighlightBox.Text = readContents;

            HighlightBoxDetail.CurrentHighlighter = HighlighterManager.Instance.Highlighters["VDHL"];
            HighlightBoxDetail.Text = readContents;

            // analyze properties
            Generate(readContents);

        }

        private void Generate(string sourceText)
        {
            bool isRemarks = false;
            string remarks = "";
            string line = "";

            if (!string.IsNullOrEmpty(sourceText))
            {
                PropsList.Clear();
                foreach (string text in sourceText.Split('\n'))
                {

                    line = text.Trim();

                    // is remark, add text
                    if (isRemarks && line.StartsWith("///") && !line.StartsWith("/// </summary>") && line.Length > 4)
                    {
                        remarks = remarks + line.Substring(4) + ' ';
                    }

                    // cache the summary start with /// <summary> end with /// </summary>
                    if (line.Contains("<summary>"))
                    {
                        isRemarks = true;
                    }
                    else if (line.Contains("</summary>"))
                    {
                        isRemarks = false;
                    }
                    //if (remarks.Contains("Close delegate "))
                    //{
                    //    var a = 1;
                    //}

                    // is it a property?
                    // public [type] [name] 
                    if (line.StartsWith("public") && !line.EndsWith(")") && !line.EndsWith(";") && !ignoreList.Any(o => line.Contains(o)))
                    {
                        string[] stats = line.Trim().Split(' ');
                        if (stats.Length >= 3)
                        {
                            string dataType = stats[1];
                            string title = stats[2];
                            string modelField = stats[1];

                            // extract type from <> pair
                            if (modelField.Contains('<') && modelField.Contains('>'))
                            {
                                modelField = modelField.Substring(modelField.LastIndexOf('<') + 1,
                                    modelField.IndexOf('>') - modelField.LastIndexOf('<') - 1);
                            }

                            // set non-Model field to to 'None'
                            if (keyWords.Contains(modelField.ToLower()) || modelField.Contains("Command"))
                            {
                                modelField = "None";
                            }

                            PropsList.Add(new ListPropsEntity(title, dataType, modelField, remarks));
                        }
                        remarks = "";
                    }
                    else if (line.StartsWith("private")) // not a property
                    {
                        remarks = "";
                    }



                }
            }

        }

        private void SourceDetail_Click(object sender, RoutedEventArgs e)
        {
            var flyout = this.Flyouts.Items[0] as Flyout;
            if (flyout == null)
            {
                return;
            }
            flyout.Position = Position.Left;
            flyout.IsOpen = !flyout.IsOpen;
        }
    }

    public class ListPropsEntity
    {
        public ListPropsEntity(string title, string dataType, string modelField, string remarks)
        {
            Title = title;
            DataType = dataType;
            ModelField = modelField;
            Remarks = remarks;
        }

        public string Title { get; set; }
        public string DataType { get; set; }
        public string ModelField { get; set; }
        public string Remarks { get; set; }
    }
}
