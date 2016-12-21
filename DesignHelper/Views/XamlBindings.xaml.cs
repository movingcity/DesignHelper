using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using MahApps.Metro.Controls;

namespace DesignHelper
{
    /// <summary>
    /// Interaction logic for XamlBindings.xaml
    /// </summary>
    public partial class XamlBindings : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _xamlText;
        private string _resxText;

        /// <summary>
        /// Input xaml text
        /// </summary>
        public string XAMLText
        {
            get { return _xamlText; }
            set { _xamlText = value; }
        }

        public string ResxText
        {
            get { return _resxText; }
            set
            {
                _resxText = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ResxText"));
                }
            }
        }

        public bool IsCommonIncluded { get; set; }

        public ObservableCollection<NameValue> ResxList { get; set; }

        public XamlBindings()
        {
            ResxList = new ObservableCollection<NameValue>();
            IsCommonIncluded = true;

            DataContext = this;
            InitializeComponent();
        }

        private void XamlToGrid_Click(object sender, RoutedEventArgs e)
        {
            ResxList.Clear();
            if (!string.IsNullOrEmpty(XAMLText))
            {
                foreach (string line in XAMLText.Split('\n'))
                {
                    string keyWord = "{Binding ";
                    List<string> excludeWord = new List<string>();
                    excludeWord.Add("ElementName");
                    //find out all Resx tags
                    if (line.Contains(keyWord))
                    {
                        //Exclude useless lines
                        if (excludeWord.Any(word => line.Contains(word)))
                        {
                            //Excluded 
                            continue;
                        }
                        else
                        {
                            string name;
                            // index of binding end
                            int endIndex;
                            endIndex = line.IndexOf(",");
                            if (endIndex < 0)
                                endIndex = line.IndexOf("}\"");

                            // index of binding start
                            int startIndex = line.IndexOf(keyWord);
                            name = line.Substring(startIndex + keyWord.Length, endIndex - startIndex - keyWord.Length);

                            ResxList.Add(new NameValue() { Name = name });
                        }
                    }
                }
            }
        }


        private void GridToResx_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var NameValue in ResxList)
            {
                sb.Append("  <data name=\"");
                sb.Append(NameValue.Name);
                sb.AppendLine("\" xml:space=\"preserve\">");

                sb.Append("    <value>");
                sb.Append(NameValue.Value);
                sb.AppendLine("</value>");

                sb.AppendLine("  </data>");

            }
            ResxText = sb.ToString();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ResxText);
            MessageBox.Show("Text copied.");
        }
    }

    public class NameValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
